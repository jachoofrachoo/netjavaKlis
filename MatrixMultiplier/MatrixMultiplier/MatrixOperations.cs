using System;
using System.Threading;

namespace MatrixMultiplier
{
    public class MatrixOperations
    {
        public static int[,] GenerateRandomMatrix(int rows, int columns, Random random)
        {
            int[,] matrix = new int[rows, columns];
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
            Thread[] threads = new Thread[threadCount];

            for (int i = 0; i < threadCount; i++)
            {
                threads[i] = new Thread((object obj) =>
                {
                    int threadIndex = (int)obj;
                    MultiplyMatricesPartial(matrixA, matrixB, result, threadCount, threadIndex);
                });
                threads[i].Start(i);
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            return result;`                 
        }

        public static void MultiplyMatricesPartial(int[,] matrixA, int[,] matrixB, int[,] result, int threadCount, int threadIndex)
        {
            int rowsA = matrixA.GetLength(0);
            int columnsB = matrixB.GetLength(1);
            int columnsA = matrixA.GetLength(1);

            int rowsPerThread = rowsA / threadCount;
            int startRow = threadIndex * rowsPerThread;
            int endRow = (threadIndex == threadCount - 1) ? rowsA : (threadIndex + 1) * rowsPerThread;

            for (int i = startRow; i < endRow; i++)
            {
                for (int j = 0; j < columnsB; j++)
                {
                    for (int k = 0; k < columnsA; k++)
                    {
                        result[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }
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
