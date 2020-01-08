using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Project1.Helpers;
using Project1.Quantizers;
using Project1.Quantizers.Popularity;
using Project1.Quantizers.Uniform;
using Project1.Ditherers;


namespace Project1
{
    public partial class MainForm : Form
    {
        private Image SourceImage;
        private Image Result;
        private Boolean turnOnEvents;
        private FileInfo sourceFileInfo;
        private IColorQuantizer activeQuantizer;
        private List<IColorQuantizer> quantizerList;

        public MainForm()
        {
            InitializeComponent();
        }
        
        private void UpdateImages()
        {
            activeQuantizer.Clear();

            try
            {
                if (listMethod.SelectedIndex <= 1)
                {
                    Image targetImage = GetQuantizedImage(SourceImage);
                    pictureSource.Image = SourceImage;
                    ImageSizeLabel.Text = SourceImage.Width + " x " + SourceImage.Height;                    
                    pictureTarget.Image = targetImage;
                }
                else
                {
                    Bitmap b = new Bitmap(Ditherhelper.Dithering(SourceImage));
                    ColorDistanceBox.Text = ColorDistance.GetColorDistance(this.SourceImage, b).ToString();
                    pictureTarget.Image = b;
                    pictureSource.Image = SourceImage;
                    ImageSizeLabel.Text = SourceImage.Width + " x " + SourceImage.Height;
                    //GetPaletteBitmap(palette);
                }

            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChangeQuantizer()
        {
            if(listMethod.SelectedIndex <= 1)
                activeQuantizer = quantizerList[listMethod.SelectedIndex];
        }

        private void EnableChoices()
        {
            FilePathOLabel.Visible = true;
            FilePathLabel.Visible = true;
            OriginalSizeLabel.Visible = true;
            ImageSizeLabel.Visible = true;
            OriginalImageLabel.Visible = true;
            EditedImageLabel.Visible = true;
            ColorDistanceLabel.Visible = true;
            ColorPaletteLabel.Visible = true;
            labelMethod.Visible = true;
            listMethod.Visible = true;
            SaveResult.Visible = true;
            listMethod.Enabled = true;
        }

        private Image GetQuantizedImage(Image image)
        {
            if (image == null)
            {
                const String message = "Cannot quantize your file. Please choose a new file.";
                throw new ArgumentNullException(message);
            }

            Bitmap bitmap = (Bitmap)image;
            Rectangle bounds = Rectangle.FromLTRB(0, 0, bitmap.Width, bitmap.Height);
            BitmapData sourceData = bitmap.LockBits(bounds, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            try
            {
                int[] sourceBuffer = new int[image.Width];

                Int64 sourceOffset = sourceData.Scan0.ToInt64();

                for (int i = 0; i < image.Height; i++)
                {
                    Marshal.Copy(new IntPtr(sourceOffset), sourceBuffer, 0, image.Width);

                    foreach (Color color in sourceBuffer.Select(argb => Color.FromArgb(argb)))
                    {
                        activeQuantizer.AddColor(color);
                    }

                    sourceOffset += sourceData.Stride;
                }
            }
            catch
            {
                bitmap.UnlockBits(sourceData);
                throw;
            }

            Bitmap result = new Bitmap(image.Width, image.Height, PixelFormat.Format8bppIndexed);

            try
            {
                List<Color> palette = activeQuantizer.GetPalette(256);
                ColorPalette imagePalette = result.Palette;

                for (Int32 index = 0; index < palette.Count; index++)
                {
                    imagePalette.Entries[index] = palette[index];
                }

                PaletteBox.Image = GetPalette.GetPaletteBitmap(palette);
                result.Palette = imagePalette;
            }
            catch (Exception)
            {
                bitmap.UnlockBits(sourceData);
                throw;
            }

            BitmapData targetData = result.LockBits(bounds, ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);

            try
            {
                Byte[] targetBuffer = new Byte[result.Width];
                int[] sourceBuffer = new int[image.Width];

                Int64 sourceOffset = sourceData.Scan0.ToInt64();
                Int64 targetOffset = targetData.Scan0.ToInt64();

                for (int i = 0; i < image.Height; i++)
                {
                    Marshal.Copy(new IntPtr(sourceOffset), sourceBuffer, 0, image.Width);

                    for (int j = 0; j < image.Width; j++)
                    {
                        Color color = Color.FromArgb(sourceBuffer[j]);
                        targetBuffer[j] = (Byte)activeQuantizer.GetPaletteIndex(color);
                    }

                    Marshal.Copy(targetBuffer, 0, new IntPtr(targetOffset), result.Width);

                    sourceOffset += sourceData.Stride;
                    targetOffset += targetData.Stride;
                }
            }
            finally
            {
                bitmap.UnlockBits(sourceData);
                result.UnlockBits(targetData);
            }

            this.Result = result;
            ColorDistanceBox.Text = ColorDistance.GetColorDistance(this.SourceImage, result).ToString();
            return result;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            quantizerList = new List<IColorQuantizer>
            {
                new UniformQuantizer(),
                new PopularityQuantizer(),
            };

            turnOnEvents = false;
            listMethod.SelectedIndex = 0;
            ChangeQuantizer();
            turnOnEvents = true;
        }

        private void ButtonBrowseClick(object sender, EventArgs e)
        {
            if (dialogOpenFile.ShowDialog() == DialogResult.OK)
            {
                buttonBrowse.Text = "convert another image";
                sourceFileInfo = new FileInfo(dialogOpenFile.FileName);
                FilePathLabel.Text = sourceFileInfo.ToString();
                SourceImage = Image.FromFile(dialogOpenFile.FileName);
                EnableChoices();
                UpdateImages();
            }
        }

        private void ListMethodSelectedIndexChanged(object sender, EventArgs e)
        {
            if (turnOnEvents)
            {
                ChangeQuantizer();
                UpdateImages();
            }
        }

        private void SaveResult_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "gif file (*.gif)|*.gif|jpg file (*.jpg)|*.jpg|png file (*.png)|*.png|bmp file (*.bmp)|*.bmp";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Result.Save(dialog.FileName, ImageFormat.Gif);
            }
        }
    }
}
