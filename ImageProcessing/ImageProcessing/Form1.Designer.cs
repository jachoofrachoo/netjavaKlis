namespace ImageProcessing
{
    partial class Form1
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
            openImageButton = new Button();
            applyFiltersButton = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox5 = new PictureBox();
            openFileDialog1 = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
            // 
            // openImageButton
            // 
            openImageButton.Location = new Point(641, 226);
            openImageButton.Name = "openImageButton";
            openImageButton.Size = new Size(172, 160);
            openImageButton.TabIndex = 0;
            openImageButton.Text = "Load";
            openImageButton.UseVisualStyleBackColor = true;
            openImageButton.Click += OpenImageButton_Click;
            // 
            // applyFiltersButton
            // 
            applyFiltersButton.Location = new Point(641, 408);
            applyFiltersButton.Name = "applyFiltersButton";
            applyFiltersButton.Size = new Size(172, 160);
            applyFiltersButton.TabIndex = 1;
            applyFiltersButton.Text = "Zastosuj";
            applyFiltersButton.UseVisualStyleBackColor = true;
            applyFiltersButton.Click += ApplyFiltersButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(25, 30);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(602, 726);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(863, 42);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(290, 282);
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Location = new Point(1186, 42);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(290, 282);
            pictureBox3.TabIndex = 4;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Location = new Point(863, 445);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(290, 282);
            pictureBox4.TabIndex = 5;
            pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Location = new Point(1186, 445);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(290, 282);
            pictureBox5.TabIndex = 6;
            pictureBox5.TabStop = false;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1522, 848);
            Controls.Add(pictureBox5);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(applyFiltersButton);
            Controls.Add(openImageButton);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button openImageButton;
        private Button applyFiltersButton;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private OpenFileDialog openFileDialog1;
    }
}
