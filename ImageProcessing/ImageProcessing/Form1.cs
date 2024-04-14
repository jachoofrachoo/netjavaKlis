using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class Form1 : Form
    {
        private Bitmap img;

        public Form1()
        {
            InitializeComponent();
        }

        private void OpenImageButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string file = openFileDialog1.FileName;
            if (!string.IsNullOrEmpty(file))
            {
                img = new Bitmap(file);
                pictureBox1.Image = img;
            }
        }

        private async void ApplyFiltersButton_Click(object sender, EventArgs e)
        {
            if (img == null)
            {
                MessageBox.Show("Please load an image first.");
                return;
            }

            Bitmap[] processedImages = new Bitmap[4];

            
            await Task.Run(() =>
            {
                Parallel.For(0, 4, i =>
                {
                    switch (i)
                    {
                        case 0: // szarosc
                            processedImages[i] = ApplyGrayscale(new Bitmap(img));
                            break;
                        case 1: // progowanie
                            processedImages[i] = ApplyThreshold(new Bitmap(img));
                            break;
                        case 2: // Negatyw
                            processedImages[i] = ApplyNegative(new Bitmap(img));
                            break;
                        case 3: // lustrzane
                            processedImages[i] = ApplyMirror(new Bitmap(img));
                            break;
                    }
                });
            });

            // wyswietlanie
            pictureBox2.Image = processedImages[0];
            pictureBox3.Image = processedImages[1];
            pictureBox4.Image = processedImages[2];
            pictureBox5.Image = processedImages[3];
        }

        private Bitmap ApplyGrayscale(Bitmap image)
        {
            Bitmap processedImage = new Bitmap(image.Width, image.Height);

            for (int y = 0; y < processedImage.Height; y++)
            {
                for (int x = 0; x < processedImage.Width; x++)
                {
                    Color originalColor = image.GetPixel(x, y);
                    int grayValue = (int)(originalColor.R * 0.3 + originalColor.G * 0.59 + originalColor.B * 0.11);
                    Color grayColor = Color.FromArgb(grayValue, grayValue, grayValue);
                    processedImage.SetPixel(x, y, grayColor);
                }
            }

            return processedImage;
        }

        private Bitmap ApplyThreshold(Bitmap image)
        {
            Bitmap processedImage = new Bitmap(image.Width, image.Height);

            for (int y = 0; y < processedImage.Height; y++)
            {
                for (int x = 0; x < processedImage.Width; x++)
                {
                    Color originalColor = image.GetPixel(x, y);
                    int grayValue = (int)(originalColor.R * 0.3 + originalColor.G * 0.59 + originalColor.B * 0.11);
                    Color thresholdColor = grayValue < 128 ? Color.Black : Color.White;
                    processedImage.SetPixel(x, y, thresholdColor);
                }
            }

            return processedImage;
        }

        private Bitmap ApplyNegative(Bitmap image)
        {
            Bitmap processedImage = new Bitmap(image.Width, image.Height);

            for (int y = 0; y < processedImage.Height; y++)
            {
                for (int x = 0; x < processedImage.Width; x++)
                {
                    Color originalColor = image.GetPixel(x, y);
                    Color negativeColor = Color.FromArgb(255 - originalColor.R, 255 - originalColor.G, 255 - originalColor.B);
                    processedImage.SetPixel(x, y, negativeColor);
                }
            }

            return processedImage;
        }

        private Bitmap ApplyMirror(Bitmap image)
        {
            Bitmap processedImage = new Bitmap(image.Width, image.Height);

            for (int y = 0; y < processedImage.Height; y++)
            {
                for (int x = 0; x < processedImage.Width / 2; x++)
                {
                    Color originalColor = image.GetPixel(x, y);
                    processedImage.SetPixel(x, y, originalColor);
                    processedImage.SetPixel(processedImage.Width - 1 - x, y, originalColor);
                }
            }

            return processedImage;
        }
    }
}
