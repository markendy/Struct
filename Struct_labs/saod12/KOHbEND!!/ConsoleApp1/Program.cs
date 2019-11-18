using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c____
{
    class Program
    {
        static short an = 0;
        static void Main(string[] args)
        {
            Program ob = new Program();
            short rz = short.Parse(Console.ReadLine());
            short[,] fid = new short[rz, rz];
            for (short i = 0; i < rz; i++)
            {
                for (short j = 0; j < rz; j++)
                {
                    fid[i, j] = -1;
                }
            }
            short kx = short.Parse(Console.ReadLine());
            short ky = short.Parse(Console.ReadLine());
            short px = short.Parse(Console.ReadLine());
            short py = short.Parse(Console.ReadLine());
            px -= 1;
            py -= 1;
            fid[kx - 1, ky - 1] = 0;
            ob.Rec(rz, 1, ref fid, kx, ky, px, py);
            ob.View(fid);
            Console.WriteLine("N = " + an);
            Console.ReadKey();
        }

        void View(short[,] fid_v2)
        {
            for (short k = 0; k < fid_v2.GetLength(0); k++)
            {
                for (short m = 0; m < fid_v2.GetLength(1); m++)
                {
                    if (fid_v2[k, m] < 0)
                        Console.Write(fid_v2[k, m] + " ");
                    else
                        Console.Write(fid_v2[k, m] + " ");
                }
                Console.WriteLine();
            }
        }

        void Rec(short rz, short n, ref short[,] fid_v, short kx, short ky, short px, short py)
        {
            Program ob2 = new Program();
            while (fid_v[px, py] == -1)
            {
                for (short x = 0; x < rz; x++)
                    for (short y = 0; y < rz; y++)
                        if (fid_v[x, y] == n - 1)
                        {
                            if (x < rz - 2 && y < rz - 1 && fid_v[x + 2, y + 1] == -1)
                                fid_v[x + 2, y + 1] = n;
                            if (x < rz - 2 && y > 0 && fid_v[x + 2, y - 1] == -1)
                                fid_v[x + 2, y - 1] = n;
                            if (x > 1 && y < rz - 1 && fid_v[x - 2, y + 1] == -1)
                                fid_v[x - 2, y + 1] = n;
                            if (x > 1 && y > 0 && fid_v[x - 2, y - 1] == -1)
                                fid_v[x - 2, y - 1] = n;
                            if (x < rz - 1 && y > 1 && fid_v[x + 1, y - 2] == -1)
                                fid_v[x + 1, y - 2] = n;
                            if (x < rz - 1 && y < rz - 2 && fid_v[x + 1, y + 2] == -1)
                                fid_v[x + 1, y + 2] = n;
                            if (x > 0 && y > 1 && fid_v[x - 1, y - 2] == -1)
                                fid_v[x - 1, y - 2] = n;
                            if (x > 0 && y < rz - 2 && fid_v[x - 1, y + 2] == -1)
                                fid_v[x - 1, y + 2] = n;
                        }
                n += 1;
                ob2.Rec(rz, n, ref fid_v, kx, ky, px, py);
            }
            an = fid_v[px, py];
        }
    }
}