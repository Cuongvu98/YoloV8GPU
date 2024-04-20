namespace WinFormsApp1
{
    partial class YoloV8Gpu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnBrowseImage = new Button();
            btnRunYolo = new Button();
            pictureBoxInput = new PictureBox();
            pictureBoxResult = new PictureBox();
            timeprocess = new Button();
            Load_model = new Button();
            btnBrowseFolder = new Button();
            btnProcessImages = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxResult).BeginInit();
            SuspendLayout();
            // 
            // btnBrowseImage
            // 
            btnBrowseImage.Location = new Point(29, 12);
            btnBrowseImage.Name = "btnBrowseImage";
            btnBrowseImage.Size = new Size(131, 55);
            btnBrowseImage.TabIndex = 0;
            btnBrowseImage.Text = "Load picture";
            btnBrowseImage.UseVisualStyleBackColor = true;
            btnBrowseImage.Click += btnBrowseImage_Click;
            // 
            // btnRunYolo
            // 
            btnRunYolo.Location = new Point(29, 73);
            btnRunYolo.Name = "btnRunYolo";
            btnRunYolo.Size = new Size(126, 55);
            btnRunYolo.TabIndex = 1;
            btnRunYolo.Text = "Run model";
            btnRunYolo.UseVisualStyleBackColor = true;
            btnRunYolo.Click += btnRunYolo_Click;
            // 
            // pictureBoxInput
            // 
            pictureBoxInput.BackColor = SystemColors.ActiveCaptionText;
            pictureBoxInput.Location = new Point(12, 158);
            pictureBoxInput.Name = "pictureBoxInput";
            pictureBoxInput.Size = new Size(383, 431);
            pictureBoxInput.TabIndex = 2;
            pictureBoxInput.TabStop = false;
            // 
            // pictureBoxResult
            // 
            pictureBoxResult.BackColor = SystemColors.ActiveCaptionText;
            pictureBoxResult.Location = new Point(401, 158);
            pictureBoxResult.Name = "pictureBoxResult";
            pictureBoxResult.Size = new Size(518, 431);
            pictureBoxResult.TabIndex = 3;
            pictureBoxResult.TabStop = false;
            // 
            // timeprocess
            // 
            timeprocess.Location = new Point(303, 1);
            timeprocess.Name = "timeprocess";
            timeprocess.Size = new Size(338, 151);
            timeprocess.TabIndex = 0;
            timeprocess.Text = "Time Process";
            timeprocess.UseCompatibleTextRendering = true;
            timeprocess.UseVisualStyleBackColor = true;
            // 
            // Load_model
            // 
            Load_model.Location = new Point(166, 12);
            Load_model.Name = "Load_model";
            Load_model.Size = new Size(131, 55);
            Load_model.TabIndex = 0;
            Load_model.Text = "Load model";
            Load_model.UseVisualStyleBackColor = true;
            Load_model.Click += btnloadModel;
            // 
            // btnBrowseFolder
            // 
            btnBrowseFolder.Location = new Point(647, 12);
            btnBrowseFolder.Name = "btnBrowseFolder";
            btnBrowseFolder.Size = new Size(131, 55);
            btnBrowseFolder.TabIndex = 0;
            btnBrowseFolder.Text = "Load more picture";
            btnBrowseFolder.UseVisualStyleBackColor = true;
            btnBrowseFolder.Click += btnBrowseFolder_Click;
            // 
            // btnProcessImages
            // 
            btnProcessImages.Location = new Point(647, 73);
            btnProcessImages.Name = "btnProcessImages";
            btnProcessImages.Size = new Size(131, 55);
            btnProcessImages.TabIndex = 1;
            btnProcessImages.Text = "Run more picture";
            btnProcessImages.UseVisualStyleBackColor = true;
            btnProcessImages.Click += btnProcessImages_Click;
            // 
            // YoloV8Gpu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(954, 615);
            Controls.Add(pictureBoxResult);
            Controls.Add(pictureBoxInput);
            Controls.Add(btnProcessImages);
            Controls.Add(btnRunYolo);
            Controls.Add(timeprocess);
            Controls.Add(Load_model);
            Controls.Add(btnBrowseFolder);
            Controls.Add(btnBrowseImage);
            Name = "YoloV8Gpu";
            ShowIcon = false;
            Text = "YoloV8 GPU";
            ((System.ComponentModel.ISupportInitialize)pictureBoxInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxResult).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnBrowseImage;
        private Button btnRunYolo;
        private PictureBox pictureBoxInput;
        private PictureBox pictureBoxResult;
        private Button timeprocess;
        private Button button1;
        private Button Load_model;
        private Button btnBrowseFolder;
        private Button btnProcessImages;
    }
}
