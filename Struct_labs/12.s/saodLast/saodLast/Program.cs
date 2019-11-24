using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace saodLast
{
    class Program
    {
        static int[,] valMas;
        static void Main(string[] args)
        {
            int M = 3;
            int N = 3;
            valMas = new int[M, N];
            F(M, N);
            Console.ReadKey();
        }

        static void F(int M, int N)
        {
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        valMas[i, j] = 1;
                    }
                    else
                    {
                        valMas[i, j] = valMas[i - 1, j] + valMas[i, j - 1];
                    }
                }
            }
            Console.WriteLine(valMas[M - 1, N - 1]);
        }
    }
}
