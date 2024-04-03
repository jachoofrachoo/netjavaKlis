using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace MatrixMultiplier
{
    public partial class MatrixMultiplierForm : Form
    {
        public MatrixMultiplierForm()
        {
            InitializeComponent();
        }

        private void MultiplyButton_Click(object sender, EventArgs e)
        {
            // Sprawd�, czy wprowadzone warto�ci w TextBoxach s� liczbami
            if (!int.TryParse(matrixSizeTextBox.Text, out int matrixSize) ||
                !int.TryParse(threadCountTextBox.Text, out int threadCount))
            {
                MessageBox.Show("Wprowad� poprawne warto�ci dla rozmiaru macierzy i liczby w�tk�w.");
                return;
            }

            Random random = new Random();

            int[,] matrixA = MatrixOperations.GenerateRandomMatrix(matrixSize, matrixSize, random);
            int[,] matrixB = MatrixOperations.GenerateRandomMatrix(matrixSize, matrixSize, random);

            // Wy�wietl macierze wej�ciowe (mo�esz zakomentowa�, gdy nie jest potrzebne)
            //ShowMatrix(matrixA, "Macierz A:");
            //ShowMatrix(matrixB, "Macierz B:");

            Stopwatch stopwatchSequential = Stopwatch.StartNew();
            int[,] resultSequential = MatrixOperations.MultiplyMatricesSequential(matrixA, matrixB);
            stopwatchSequential.Stop();

            Stopwatch stopwatchParallel = Stopwatch.StartNew();
            int[,] resultParallel = MatrixOperations.MultiplyMatricesParallel(matrixA, matrixB, threadCount);
            stopwatchParallel.Stop();

            bool isValid = MatrixOperations.CheckMatrixEquality(resultSequential, resultParallel);

            // Wy�wietl macierz wynikow� (mo�esz zakomentowa�, gdy nie jest potrzebne)
            //ShowMatrix(resultParallel, "Macierz wynikowa:");

            MessageBox.Show($"Czas oblicze� sekwencyjnych: {stopwatchSequential.ElapsedMilliseconds} ms\n" +
                            $"Czas oblicze� r�wnoleg�ych z {threadCount} w�tkami: {stopwatchParallel.ElapsedMilliseconds} ms\n" +
                            $"Poprawno�� oblicze�: {isValid}");
        }

        // Metoda do wy�wietlania macierzy
        private void ShowMatrix(int[,] matrix, string caption)
        {
            string matrixString = caption + "\n";
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrixString += matrix[i, j] + "\t";
                }
                matrixString += "\n";
            }

            MessageBox.Show(matrixString);
        }
    }
}
