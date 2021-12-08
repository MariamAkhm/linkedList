using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linkedList
{
    class Program
    {
        static void PrintMatrix(LinkedList<int[]> matrix)
        {
            foreach (var i in matrix)
            {
                foreach (var j in i)
                {
                    Console.Write(j.ToString() + ' ');
                }
                Console.Write('\n');
            }
        }
        static LinkedList<int[]> MultiplyMatrix(LinkedList<int[]> matrix1, LinkedList<int[]> matrix2)
        {
            if (matrix2.First().Length != matrix1.Count)
            {
                Console.WriteLine("Количество строк первой матрице не соответствует количеству столбцов второй матрице\nУмножение невозможно");
            }
            int amountLines1 = matrix1.First().Length;
            int amountColumn2 = matrix2.Count;
            int amount_lines_2 = matrix2.First().Length;
            var matrix = new LinkedList<int[]>();

            for (int i = 0; i < amountColumn2; i++)
            {
                int[] mat = new int[amountLines1];
                for (int j = 0; j < amountLines1; j++)
                {
                    int sum = 0;
                    LinkedList<int[]> matrixEnd = new LinkedList<int[]>(matrix2);
                    for (int k = 0; k < amountColumn2; k++)
                    {
                        sum += matrix1.First()[k] * matrixEnd.First()[j];
                        matrixEnd.RemoveFirst();
                    }
                    mat[j] = sum;
                }
                matrix1.RemoveFirst();
                matrix.AddLast(mat);
            }
            return matrix;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Упражнение 2");
            LinkedList<int[]> matrix1 = new LinkedList<int[]>();
            matrix1.AddLast(new int[] { 1, 2, 3 });
            matrix1.AddLast(new int[] { 4, 5, 6 });
            matrix1.AddLast(new int[] { 7, 8, 9 });
            LinkedList<int[]> matrix2 = new LinkedList<int[]>();
            matrix2.AddLast(new int[] { 3, 2, 1 });
            matrix2.AddLast(new int[] { 6, 5, 4 });
            matrix2.AddLast(new int[] { 9, 8, 7 });
            var matrix = MultiplyMatrix(matrix1, matrix2);
            PrintMatrix(matrix);
        }
    }
   
}
