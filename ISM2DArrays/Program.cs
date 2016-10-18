using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISM2DArrays
{
    class Program
    {
        
        static double[,] MultipleMatr(double[,] matr1, double[,] matr2)
        {
            double[,] matr = new double[matr1.GetLength(0), matr2.GetLength(1)];
            if (matr1.GetLength(1) != matr2.GetLength(0))
                return null;
            for (int i = 0; i < matr1.GetLength(0); i++)
                for (int j = 0; j < matr2.GetLength(1); j++)
                {
                    double rez = 0;
                    for (int k = 0; k < matr2.GetLength(1); k++)
                    {
                        rez += matr1[i, k] * matr2[k, j];
                    }
                    matr[i, j] = rez;
                }
            return matr;
        }
        static void WriteMatr(double[,] matr)
        {
            for (int i = 0; i < matr.GetLength(0); i++)
                for (int j = 0; j < matr.GetLength(1); j++)
                    Console.Write(matr[i, j] + (j == matr.GetLength(1) - 1 ? "\n" : " "));
            Console.WriteLine("\n");
        }
        static double[,] Matrix2(int c, int d, int min2, int max2, int prec2)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            double[,] matr1 = new double[c, d];
            for (int i = 0; i < c; i++)
                for (int j = 0; j < d; j++)
                    matr1[i, j] = Math.Round(rnd.NextDouble() * (max2 - min2) +
                    min2, prec2);
            return matr1;
        }
        static double[,] Matrix1(int a, int b, int min1, int max1, int prec1)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            double[,] matr1 = new double[a, b];
            for (int i = 0; i < a; i++)
                for (int j = 0; j < b; j++)
                    matr1[i, j] = Math.Round(rnd.NextDouble() * (max1 - min1) +
                    min1, prec1);
            return matr1;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Матрица 1:");
            Console.Write("Кол-во строк: ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("Кол-во столбцов: ");
            int b = int.Parse(Console.ReadLine());
            Console.Write("Минимальное значение: ");
            int min1 = int.Parse(Console.ReadLine());
            Console.Write("М ксимальное значение: ");
            int max1 = int.Parse(Console.ReadLine());
            Console.Write("Кол-во знаков после запятой: ");
            int prec1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Матрица 2:");
            Console.Write("Кол-во строк: ");
            int c= int.Parse(Console.ReadLine());
            Console.Write("Кол-во столбцов: ");
            int d = int.Parse(Console.ReadLine());
            Console.Write("Минимальное значение: ");
            int min2 = int.Parse(Console.ReadLine());
            Console.Write("Максимальное значение: ");
            int max2 = int.Parse(Console.ReadLine());
            Console.Write("Кол-во знаков после запятой: ");
            int prec2 = int.Parse(Console.ReadLine());
            double[,] matr1, matr2, matr3;
            matr1 = Matrix1(a, b, min1, max1, prec1);
            matr2 = Matrix2(c, d, min2, max2, prec2);
            WriteMatr(matr1);
            WriteMatr(matr2);
            matr3 = MultipleMatr(matr1, matr2);
            if (matr3 == null)
            Console.WriteLine("Ошибка, невозможно перемножить матрицы!");
            WriteMatr(matr3);
            
        }
    }
}
