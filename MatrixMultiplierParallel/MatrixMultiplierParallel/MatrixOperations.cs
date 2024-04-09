using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixMultiplierParallel
{
    public class MatrixOperations
    {
        public static int[,] GenerateRandomMatrix(int rows, int columns, int seed)
        {
            int[,] matrix = new int[rows, columns];
            Random random = new Random(seed);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = random.Next(10); // Przykładowe zakres wartości od 0 do 9
                }
            }
            return matrix;
        }

        public static int[,] MultiplyMatricesSequential(int[,] matrixA, int[,] matrixB)
        {
            int rowsA = matrixA.GetLength(0);
            int columnsB = matrixB.GetLength(1);
            int[,] result = new int[rowsA, columnsB];

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < columnsB; j++)
                {
                    for (int k = 0; k < matrixA.GetLength(1); k++)
                    {
                        result[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }

            return result;
        }

        public static int[,] MultiplyMatricesParallel(int[,] matrixA, int[,] matrixB, int threadCount)
        {
            int rowsA = matrixA.GetLength(0);
            int columnsB = matrixB.GetLength(1);
            int[,] result = new int[rowsA, columnsB];

            Parallel.For(0, rowsA, i =>
            {
                for (int j = 0; j < columnsB; j++)
                {
                    for (int k = 0; k < matrixA.GetLength(1); k++)
                    {
                        result[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            });

            return result;
        }

        public static bool CheckMatrixEquality(int[,] matrixA, int[,] matrixB)
        {
            int rowsA = matrixA.GetLength(0);
            int columnsA = matrixA.GetLength(1);
            int rowsB = matrixB.GetLength(0);
            int columnsB = matrixB.GetLength(1);

            if (rowsA != rowsB || columnsA != columnsB)
            {
                return false;
            }

            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < columnsA; j++)
                {
                    if (matrixA[i, j] != matrixB[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}

