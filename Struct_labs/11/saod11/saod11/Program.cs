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
            Console.WriteLine(So(time,N));
        }

        static int So(int[]time, int N)
        {
            int res = 0;
            Array.Sort(time);
            bool ex = false;
            int i = 0;

            while (!ex)
            {
                if (N-time[i] < 0)
                {
                    ex = true;
                }
                if (i >= time.Length)
                {
                    ex = true;
                }
                N -= time[i];
                i++;
                res++;
            }
            return res-1;
        }
    }
}
