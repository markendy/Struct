using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> cl1 = new Dictionary<int, int>();
            for (int i = 0; i < 5; i++)
            {
                cl1.Add(i, i + 2);
            }
            Random r = new Random();
            for (int i = 0; i < cl1.Count; i++)
            {
                Console.WriteLine(cl1[r.Next(0, cl1.Count)]);
            }
        }
    }
}
