/// <summary>
/// 
/// </summary>
namespace Project1
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using Project1.Ditherers;
    using Project1.Helpers;
    using Project1.Quantizers;
    using Project1.Quantizers.Popularity;
    using Project1.Quantizers.Uniform;

    /// <summary>
    /// This is the main application interface
    /// </summary>
    public partial class MainForm : Form
    {
        private Image sourceImage;
        private Image result;
        private bool turnOnEvents;
        private FileInfo sourceFileInfo;
        private IColorQuantizer activeQuantizer;
        private List<IColorQuantizer> quantizerList;

        public MainForm()
        {
            this.InitializeComponent();
        }
        
        private void UpdateImages()
        {
            this.activeQuantizer.Clear();

            try
            {
                if (listMethod.SelectedIndex <= 1)
                {
                    Image targetImage = this.GetQuantizedImage(this.sourceImage);
                    pictureSource.Image = this.sourceImage;
                    ImageSizeLabel.Text = this.sourceImage.Width + " x " + this.sourceImage.Height;                    
                    pictureTarget.Image = targetImage;
                }
                else
                {
                    Bitmap b = new Bitmap(Ditherhelper.Dithering(this.sourceImage));
                    ColorDistanceBox.Text = ColorDistance.GetColorDistance(this.sourceImage, b).ToString();
                    pictureTarget.Image = b;
                    pictureSource.Image = this.sourceImage;
                    ImageSizeLabel.Text = this.sourceImage.Width + " x " + this.sourceImage.Height;

                    // GetPaletteBitmap(palette);
                }
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ChangeQuantizer()
        {
            if (listMethod.SelectedIndex <= 1)
            {
                this.activeQuantizer = this.quantizerList[listMethod.SelectedIndex];
            }
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
                const string message = "Cannot quantize your file. Please choose a new file.";
                throw new ArgumentNullException(message);
            }

            Bitmap bitmap = (Bitmap)image;
            Rectangle bounds = Rectangle.FromLTRB(0, 0, bitmap.Width, bitmap.Height);
            BitmapData sourceData = bitmap.LockBits(bounds, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

            try
            {
                int[] sourceBuffer = new int[image.Width];

                long sourceOffset = sourceData.Scan0.ToInt64();

                for (int i = 0; i < image.Height; i++)
                {
                    Marshal.Copy(new IntPtr(sourceOffset), sourceBuffer, 0, image.Width);

                    foreach (Color color in sourceBuffer.Select(argb => Color.FromArgb(argb)))
                    {
                        this.activeQuantizer.AddColor(color);
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
                List<Color> palette = this.activeQuantizer.GetPalette(256);
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
                byte[] targetBuffer = new byte[result.Width];
                int[] sourceBuffer = new int[image.Width];

                long sourceOffset = sourceData.Scan0.ToInt64();
                long targetOffset = targetData.Scan0.ToInt64();

                for (int i = 0; i < image.Height; i++)
                {
                    Marshal.Copy(new IntPtr(sourceOffset), sourceBuffer, 0, image.Width);

                    for (int j = 0; j < image.Width; j++)
                    {
                        Color color = Color.FromArgb(sourceBuffer[j]);
                        targetBuffer[j] = (byte) this.activeQuantizer.GetPaletteIndex(color);
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

            this.result = result;
            ColorDistanceBox.Text = ColorDistance.GetColorDistance(this.sourceImage, result).ToString();
            return result;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.quantizerList = new List<IColorQuantizer>
            {
                new UniformQuantizer(),
                new PopularityQuantizer(),
            };

            this.turnOnEvents = false;
            listMethod.SelectedIndex = 0;
            this.ChangeQuantizer();
            this.turnOnEvents = true;
        }

        private void ButtonBrowseClick(object sender, EventArgs e)
        {
            if (this.dialogOpenFile.ShowDialog() == DialogResult.OK)
            {
                buttonBrowse.Text = "convert another image";
                this.sourceFileInfo = new FileInfo(this.dialogOpenFile.FileName);
                FilePathLabel.Text = this.sourceFileInfo.ToString();
                this.sourceImage = Image.FromFile(this.dialogOpenFile.FileName);
                this.EnableChoices();
                this.UpdateImages();
            }
        }

        private void ListMethodSelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.turnOnEvents)
            {
                this.ChangeQuantizer();
                this.UpdateImages();
            }
        }

        private void SaveResult_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "gif file (*.gif)|*.gif|jpg file (*.jpg)|*.jpg|png file (*.png)|*.png|bmp file (*.bmp)|*.bmp";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.result.Save(dialog.FileName, ImageFormat.Gif);
            }
        }
    }
}
