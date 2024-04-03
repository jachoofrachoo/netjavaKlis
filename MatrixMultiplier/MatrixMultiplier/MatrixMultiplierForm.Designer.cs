namespace MatrixMultiplier
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
            matrixSizeTextBox = new TextBox();
            label1 = new Label();
            threadCountTextBox = new TextBox();
            label2 = new Label();
            calculateButton = new Button();
            resultLabel = new Label();
            SuspendLayout();
            // 
            // matrixSizeTextBox
            // 
            matrixSizeTextBox.Location = new Point(219, 62);
            matrixSizeTextBox.Name = "matrixSizeTextBox";
            matrixSizeTextBox.Size = new Size(244, 39);
            matrixSizeTextBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 65);
            label1.Name = "label1";
            label1.Size = new Size(200, 32);
            label1.TabIndex = 1;
            label1.Text = "Rozmiar macierzy";
            // 
            // threadCountTextBox
            // 
            threadCountTextBox.Location = new Point(219, 162);
            threadCountTextBox.Name = "threadCountTextBox";
            threadCountTextBox.Size = new Size(244, 39);
            threadCountTextBox.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 169);
            label2.Name = "label2";
            label2.Size = new Size(148, 32);
            label2.TabIndex = 3;
            label2.Text = "Ilość watkow";
            // 
            // calculateButton
            // 
            calculateButton.Location = new Point(763, 80);
            calculateButton.Name = "calculateButton";
            calculateButton.Size = new Size(212, 96);
            calculateButton.TabIndex = 4;
            calculateButton.Text = "Calculate";
            calculateButton.UseVisualStyleBackColor = true;
            calculateButton.Click += new System.EventHandler(this.MultiplyButton_Click);
            // 
            // resultLabel
            // 
            resultLabel.AutoSize = true;
            resultLabel.Location = new Point(819, 228);
            resultLabel.Name = "resultLabel";
            resultLabel.Size = new Size(56, 32);
            resultLabel.TabIndex = 5;
            resultLabel.Text = "N/A";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1254, 738);
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

        private TextBox matrixSizeTextBox;
        private Label label1;
        private TextBox threadCountTextBox;
        private Label label2;
        private Button calculateButton;
        private Label resultLabel;
    }
}
