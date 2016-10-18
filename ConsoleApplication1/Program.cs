using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static double[,] Minor(double[,] matr, double[,] matr2, int n) 
        {
            int di = 0, dj;
            for (int ki = 0; ki < n; ki++)
            {
                if (ki == n) 
                    di = 1;
                dj = 0;
                for (int kj = 0; kj < n; kj++)
                {
                    if (kj == n) 
                        dj = 1;
                    matr2[ki, kj] = matr[ki + di, kj + dj];
                }
            }
            return matr2;
        }
        static double Determinant(double[,] matr, int n) 
        {
            int k = 1; 
            double d = 0; 
            double[,] matr2 = new double[n, n];
            if (n < 1) return 0;
            if (n == 1) return matr[0, 0];
            if (n == 2) return matr[0, 0] * matr[1, 1] - matr[0, 1] * matr[1, 0];
            for (int i = 0; i < n; i++)
            {
                matr2 = Minor(matr, matr2, n); 
                d += k * matr[i, 0] * Determinant(matr2, n - 1);
                k *= -1;
            }
            return d;
        }
        static void WriteMatr(double[,] matr)
        {
            for (int i = 0; i < matr.GetLength(0); i++)
                for (int j = 0; j < matr.GetLength(1); j++)
                    Console.Write(matr[i, j] + (j == matr.GetLength(1) - 1 ? "\n" : " "));
            Console.WriteLine("\n");
        }
        static double[,] Matrix(int n, int min, int max, int prec)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            double[,] matr = new double[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    matr[i, j] = Math.Round(rnd.NextDouble() * (max - min) +
                    min, prec);
            return matr;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Квадратная матрица с количеством столбцов и строк: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Минимальное значение: ");
            int min = int.Parse(Console.ReadLine());
            Console.WriteLine("Максимальное значение: ");
            int max = int.Parse(Console.ReadLine());
            Console.WriteLine("Кол-во знаков после запятой: ");
            int prec = int.Parse(Console.ReadLine());
            double[,] matr = Matrix(n, min, max, prec);
            WriteMatr(matr);
            double D = Determinant(matr, n);
            Console.WriteLine("Детерминант = {0}", D);
        }
    }
}
