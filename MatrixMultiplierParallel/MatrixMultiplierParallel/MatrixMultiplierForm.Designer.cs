namespace MatrixMultiplierParallel
{
    partial class MatrixMultiplierForm
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
            label3 = new Label();
            seedTextBox = new TextBox();
            resultLabel = new Label();
            calculateButton = new Button();
            label2 = new Label();
            threadCountTextBox = new TextBox();
            label1 = new Label();
            matrixSizeTextBox = new TextBox();
            SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(108, 314);
            label3.Name = "label3";
            label3.Size = new Size(82, 32);
            label3.TabIndex = 15;
            label3.Text = "Ziarno";
            // 
            // seedTextBox
            // 
            seedTextBox.Location = new Point(274, 311);
            seedTextBox.Name = "seedTextBox";
            seedTextBox.Size = new Size(244, 39);
            seedTextBox.TabIndex = 14;
            // 
            // resultLabel
            // 
            resultLabel.AutoSize = true;
            resultLabel.Location = new Point(874, 257);
            resultLabel.Name = "resultLabel";
            resultLabel.Size = new Size(56, 32);
            resultLabel.TabIndex = 13;
            resultLabel.Text = "N/A";
            // 
            // calculateButton
            // 
            calculateButton.Location = new Point(818, 109);
            calculateButton.Name = "calculateButton";
            calculateButton.Size = new Size(212, 96);
            calculateButton.TabIndex = 12;
            calculateButton.Text = "Calculate";
            calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.MultiplyButton_Click);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(84, 198);
            label2.Name = "label2";
            label2.Size = new Size(148, 32);
            label2.TabIndex = 11;
            label2.Text = "Ilość watkow";
            // 
            // threadCountTextBox
            // 
            threadCountTextBox.Location = new Point(274, 191);
            threadCountTextBox.Name = "threadCountTextBox";
            threadCountTextBox.Size = new Size(244, 39);
            threadCountTextBox.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(67, 94);
            label1.Name = "label1";
            label1.Size = new Size(200, 32);
            label1.TabIndex = 9;
            label1.Text = "Rozmiar macierzy";
            // 
            // matrixSizeTextBox
            // 
            matrixSizeTextBox.Location = new Point(274, 91);
            matrixSizeTextBox.Name = "matrixSizeTextBox";
            matrixSizeTextBox.Size = new Size(244, 39);
            matrixSizeTextBox.TabIndex = 8;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1260, 716);
            Controls.Add(label3);
            Controls.Add(seedTextBox);
            Controls.Add(resultLabel);
            Controls.Add(calculateButton);
            Controls.Add(label2);
            Controls.Add(threadCountTextBox);
            Controls.Add(label1);
            Controls.Add(matrixSizeTextBox);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label3;
        private TextBox seedTextBox;
        private Label resultLabel;
        private Button calculateButton;
        private Label label2;
        private TextBox threadCountTextBox;
        private Label label1;
        private TextBox matrixSizeTextBox;
    }
}
