namespace Project1
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.dialogOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.panelStatistics = new System.Windows.Forms.Panel();
            this.PaletteBox = new System.Windows.Forms.PictureBox();
            this.pictureSource = new System.Windows.Forms.PictureBox();
            this.ColorPaletteLabel = new System.Windows.Forms.Label();
            this.ColorDistanceLabel = new System.Windows.Forms.Label();
            this.ColorDistanceBox = new System.Windows.Forms.Label();
            this.SaveResult = new System.Windows.Forms.Button();
            this.FilePathOLabel = new System.Windows.Forms.Label();
            this.FilePathLabel = new System.Windows.Forms.Label();
            this.OriginalSizeLabel = new System.Windows.Forms.Label();
            this.ImageSizeLabel = new System.Windows.Forms.Label();
            this.panelMethod = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.listMethod = new System.Windows.Forms.ComboBox();
            this.OriginalImageLabel = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.pictureTarget = new System.Windows.Forms.PictureBox();
            this.EditedImageLabel = new System.Windows.Forms.Label();
            this.labelMethod = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PaletteBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSource)).BeginInit();
            this.panelMethod.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureTarget)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonBrowse.Location = new System.Drawing.Point(10, 1185);
            this.buttonBrowse.Margin = new System.Windows.Forms.Padding(6);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(2213, 83);
            this.buttonBrowse.TabIndex = 0;
            this.buttonBrowse.Text = "Browse for a file image...";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.ButtonBrowseClick);
            // 
            // dialogOpenFile
            // 
            this.dialogOpenFile.Filter = "Supported images|*.png;*.jpg;*.gif;*.jpeg;*.bmp;*.tiff";
            // 
            // panelStatistics
            // 
            this.panelStatistics.AutoSize = true;
            this.panelStatistics.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelStatistics.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelStatistics.Location = new System.Drawing.Point(10, 1185);
            this.panelStatistics.Margin = new System.Windows.Forms.Padding(6);
            this.panelStatistics.Name = "panelStatistics";
            this.panelStatistics.Size = new System.Drawing.Size(2213, 0);
            this.panelStatistics.TabIndex = 4;
            // 
            // PaletteBox
            // 
            this.PaletteBox.Location = new System.Drawing.Point(870, 756);
            this.PaletteBox.Name = "PaletteBox";
            this.PaletteBox.Size = new System.Drawing.Size(435, 68);
            this.PaletteBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PaletteBox.TabIndex = 9;
            this.PaletteBox.TabStop = false;
            // 
            // pictureSource
            // 
            this.pictureSource.Location = new System.Drawing.Point(0, 0);
            this.pictureSource.Margin = new System.Windows.Forms.Padding(6);
            this.pictureSource.Name = "pictureSource";
            this.pictureSource.Size = new System.Drawing.Size(871, 824);
            this.pictureSource.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureSource.TabIndex = 8;
            this.pictureSource.TabStop = false;
            // 
            // ColorPaletteLabel
            // 
            this.ColorPaletteLabel.Location = new System.Drawing.Point(870, 697);
            this.ColorPaletteLabel.Name = "ColorPaletteLabel";
            this.ColorPaletteLabel.Size = new System.Drawing.Size(435, 65);
            this.ColorPaletteLabel.TabIndex = 11;
            this.ColorPaletteLabel.Text = "Colors Palette:";
            this.ColorPaletteLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ColorPaletteLabel.Visible = false;
            // 
            // ColorDistanceLabel
            // 
            this.ColorDistanceLabel.Location = new System.Drawing.Point(870, 469);
            this.ColorDistanceLabel.Name = "ColorDistanceLabel";
            this.ColorDistanceLabel.Size = new System.Drawing.Size(435, 65);
            this.ColorDistanceLabel.TabIndex = 12;
            this.ColorDistanceLabel.Text = "Color distance:";
            this.ColorDistanceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ColorDistanceLabel.Visible = false;
            // 
            // ColorDistanceBox
            // 
            this.ColorDistanceBox.Location = new System.Drawing.Point(870, 534);
            this.ColorDistanceBox.Name = "ColorDistanceBox";
            this.ColorDistanceBox.Size = new System.Drawing.Size(435, 65);
            this.ColorDistanceBox.TabIndex = 13;
            this.ColorDistanceBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SaveResult
            // 
            this.SaveResult.Location = new System.Drawing.Point(876, 830);
            this.SaveResult.Name = "SaveResult";
            this.SaveResult.Size = new System.Drawing.Size(435, 81);
            this.SaveResult.TabIndex = 14;
            this.SaveResult.Text = "Save result";
            this.SaveResult.UseVisualStyleBackColor = true;
            this.SaveResult.Visible = false;
            this.SaveResult.Click += new System.EventHandler(this.SaveResult_Click);
            // 
            // FilePathOLabel
            // 
            this.FilePathOLabel.Location = new System.Drawing.Point(870, 0);
            this.FilePathOLabel.Name = "FilePathOLabel";
            this.FilePathOLabel.Size = new System.Drawing.Size(435, 65);
            this.FilePathOLabel.TabIndex = 15;
            this.FilePathOLabel.Text = "FilePath:";
            this.FilePathOLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.FilePathOLabel.Visible = false;
            // 
            // FilePathLabel
            // 
            this.FilePathLabel.Location = new System.Drawing.Point(870, 65);
            this.FilePathLabel.Name = "FilePathLabel";
            this.FilePathLabel.Size = new System.Drawing.Size(435, 65);
            this.FilePathLabel.TabIndex = 16;
            this.FilePathLabel.Text = "FilePath:";
            this.FilePathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.FilePathLabel.Visible = false;
            // 
            // OriginalSizeLabel
            // 
            this.OriginalSizeLabel.Location = new System.Drawing.Point(870, 145);
            this.OriginalSizeLabel.Name = "OriginalSizeLabel";
            this.OriginalSizeLabel.Size = new System.Drawing.Size(435, 65);
            this.OriginalSizeLabel.TabIndex = 17;
            this.OriginalSizeLabel.Text = "Original Image Size";
            this.OriginalSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.OriginalSizeLabel.Visible = false;
            // 
            // ImageSizeLabel
            // 
            this.ImageSizeLabel.Location = new System.Drawing.Point(870, 210);
            this.ImageSizeLabel.Name = "ImageSizeLabel";
            this.ImageSizeLabel.Size = new System.Drawing.Size(435, 65);
            this.ImageSizeLabel.TabIndex = 18;
            this.ImageSizeLabel.Text = "FilePath:";
            this.ImageSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ImageSizeLabel.Visible = false;
            // 
            // panelMethod
            // 
            this.panelMethod.Controls.Add(this.comboBox1);
            this.panelMethod.Controls.Add(this.listMethod);
            this.panelMethod.Location = new System.Drawing.Point(883, 356);
            this.panelMethod.Margin = new System.Windows.Forms.Padding(6);
            this.panelMethod.Name = "panelMethod";
            this.panelMethod.Padding = new System.Windows.Forms.Padding(0, 0, 10, 10);
            this.panelMethod.Size = new System.Drawing.Size(422, 48);
            this.panelMethod.TabIndex = 10;
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Uniform quantization",
            "Popularity algorithm",
            "Atkinson Dithering"});
            this.comboBox1.Location = new System.Drawing.Point(0, 0);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(412, 33);
            this.comboBox1.TabIndex = 14;
            this.comboBox1.Visible = false;
            // 
            // listMethod
            // 
            this.listMethod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listMethod.Enabled = false;
            this.listMethod.FormattingEnabled = true;
            this.listMethod.Items.AddRange(new object[] {
            "Uniform quantization",
            "Popularity algorithm",
            "Atkinson Dithering"});
            this.listMethod.Location = new System.Drawing.Point(0, 0);
            this.listMethod.Margin = new System.Windows.Forms.Padding(6);
            this.listMethod.Name = "listMethod";
            this.listMethod.Size = new System.Drawing.Size(412, 33);
            this.listMethod.TabIndex = 13;
            this.listMethod.Visible = false;
            this.listMethod.SelectedIndexChanged += new System.EventHandler(this.ListMethodSelectedIndexChanged);
            // 
            // OriginalImageLabel
            // 
            this.OriginalImageLabel.Location = new System.Drawing.Point(3, 839);
            this.OriginalImageLabel.Name = "OriginalImageLabel";
            this.OriginalImageLabel.Size = new System.Drawing.Size(871, 81);
            this.OriginalImageLabel.TabIndex = 11;
            this.OriginalImageLabel.Text = "Original Image";
            this.OriginalImageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.OriginalImageLabel.Visible = false;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.pictureTarget);
            this.panelMain.Controls.Add(this.EditedImageLabel);
            this.panelMain.Controls.Add(this.labelMethod);
            this.panelMain.Controls.Add(this.OriginalImageLabel);
            this.panelMain.Controls.Add(this.panelMethod);
            this.panelMain.Controls.Add(this.ImageSizeLabel);
            this.panelMain.Controls.Add(this.OriginalSizeLabel);
            this.panelMain.Controls.Add(this.FilePathLabel);
            this.panelMain.Controls.Add(this.FilePathOLabel);
            this.panelMain.Controls.Add(this.SaveResult);
            this.panelMain.Controls.Add(this.ColorDistanceBox);
            this.panelMain.Controls.Add(this.ColorDistanceLabel);
            this.panelMain.Controls.Add(this.ColorPaletteLabel);
            this.panelMain.Controls.Add(this.pictureSource);
            this.panelMain.Controls.Add(this.PaletteBox);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(10, 10);
            this.panelMain.Margin = new System.Windows.Forms.Padding(6);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.panelMain.Size = new System.Drawing.Size(2213, 1175);
            this.panelMain.TabIndex = 5;
            // 
            // pictureTarget
            // 
            this.pictureTarget.Location = new System.Drawing.Point(1310, 0);
            this.pictureTarget.Margin = new System.Windows.Forms.Padding(6);
            this.pictureTarget.Name = "pictureTarget";
            this.pictureTarget.Size = new System.Drawing.Size(871, 824);
            this.pictureTarget.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureTarget.TabIndex = 20;
            this.pictureTarget.TabStop = false;
            // 
            // EditedImageLabel
            // 
            this.EditedImageLabel.Location = new System.Drawing.Point(1310, 830);
            this.EditedImageLabel.Name = "EditedImageLabel";
            this.EditedImageLabel.Size = new System.Drawing.Size(871, 81);
            this.EditedImageLabel.TabIndex = 19;
            this.EditedImageLabel.Text = "Edited Image";
            this.EditedImageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.EditedImageLabel.Visible = false;
            // 
            // labelMethod
            // 
            this.labelMethod.Location = new System.Drawing.Point(870, 275);
            this.labelMethod.Name = "labelMethod";
            this.labelMethod.Size = new System.Drawing.Size(435, 65);
            this.labelMethod.TabIndex = 19;
            this.labelMethod.Text = "Choose Algorithm";
            this.labelMethod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelMethod.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2233, 1278);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelStatistics);
            this.Controls.Add(this.buttonBrowse);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project 1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PaletteBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSource)).EndInit();
            this.panelMethod.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureTarget)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.OpenFileDialog dialogOpenFile;
        private System.Windows.Forms.Panel panelStatistics;
        private System.Windows.Forms.PictureBox PaletteBox;
        private System.Windows.Forms.PictureBox pictureSource;
        private System.Windows.Forms.Label ColorPaletteLabel;
        private System.Windows.Forms.Label ColorDistanceLabel;
        private System.Windows.Forms.Label ColorDistanceBox;
        private System.Windows.Forms.Button SaveResult;
        private System.Windows.Forms.Label FilePathOLabel;
        private System.Windows.Forms.Label FilePathLabel;
        private System.Windows.Forms.Label OriginalSizeLabel;
        private System.Windows.Forms.Label ImageSizeLabel;
        private System.Windows.Forms.Panel panelMethod;
        private System.Windows.Forms.ComboBox listMethod;
        private System.Windows.Forms.Label OriginalImageLabel;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label labelMethod;
        private System.Windows.Forms.Label EditedImageLabel;
        public System.Windows.Forms.PictureBox pictureTarget;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

