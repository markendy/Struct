using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace saod11
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = Convert.ToInt32(Console.ReadLine());
            int n = Convert.ToInt32(Console.ReadLine());
            int[] time = new int[n];
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine($"val {i+1}? = ");
                time[i]= Convert.ToInt32(Console.ReadLine());
            }
            Array.Sort(time);
            Console.WriteLine(So(time,N));
        }

        static int So(int[]time, int N)
        {
            int res = 0;         
            bool ex = false;
            int i = 0;

            while (!ex)
            {
                if (i > time.Length-1)
                {
                    ex = true;
                    break;
                }
                if (N-time[i] < 0)
                {
                    ex = true;
                    break;
                }
                N -= time[i];
                i++;
                res++;
            }
            return res;
        }
    }
}
