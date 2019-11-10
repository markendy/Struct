using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace saod8
{
    class Program
    {
        static string[] inputString;
        static Dictionary<string, float> masVal;
        static Dictionary<string, float> masValOut;
        static void Main(string[] args)
        {
            masVal = new Dictionary<string, float>();
            masValOut = new Dictionary<string, float>();

            inputString = Console.ReadLine().ToLower().Split();
            Nu();
            View();
        }
        static void Nu()
        {
            for (int i = 0; i < inputString.Length; i++)
            {
                bool et = false;
                if (masVal.Values.Count != 0)
                {
                    foreach (var t in masVal.Keys)
                    {
                        if (t == inputString[i])
                        {
                            masVal[t]++;
                            masValOut[t] = masVal[t] / inputString.Length;
                            et = true;
                            break;
                        }
                    }
                    if(et == false)
                    {
                        masVal.Add(inputString[i], 1.0f);
                        masValOut.Add(inputString[i], (1.0f / inputString.Length));
                        et = true;
                    }
                }
                else
                {
                    masVal.Add(inputString[i], 1.0f);
                    masValOut.Add(inputString[i], (1.0f / inputString.Length));
                }
            }
        }

        static void View()
        {
            foreach(var t in masValOut)
            {
                Console.WriteLine("v (" + t.Key + ") = " + t.Value +" <::> ");
            }
        }
    }
}