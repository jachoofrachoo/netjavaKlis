namespace apiGUI
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
            btnGetWeather = new Button();
            txtCity = new TextBox();
            lblResult = new Label();
            SuspendLayout();
            // 
            // btnGetWeather
            // 
            btnGetWeather.Location = new Point(485, 40);
            btnGetWeather.Name = "btnGetWeather";
            btnGetWeather.Size = new Size(210, 90);
            btnGetWeather.TabIndex = 0;
            btnGetWeather.Text = "Pokaz";
            btnGetWeather.UseVisualStyleBackColor = true;
            // 
            // txtCity
            // 
            txtCity.Location = new Point(61, 66);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(200, 39);
            txtCity.TabIndex = 1;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(387, 240);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(80, 32);
            lblResult.TabIndex = 2;
            lblResult.Text = "Wynik";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblResult);
            Controls.Add(txtCity);
            Controls.Add(btnGetWeather);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGetWeather;
        private TextBox txtCity;
        private Label lblResult;
    }
}
