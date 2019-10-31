using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace Dcoder
{
    public class StOp
    {
        public string TEMP = "";

        public List<St> StList = new List<St>();

        public void Clone(StOp list1, StOp list2)
        {
            for (int i = 0, f = 0; i < list1.StList.Count(); i++)
            {
                if (list1.StList[i].comp == TEMP || list1.StList[i].comp == TEMP)
                {
                    list2.StList.Add(new St(null, null, "", ""));
                    list2.StList[f].val = list1.StList[i].val;
                    list2.StList[f].comp = list1.StList[i].comp;
                    f++;
                }
            }
            list2.Sybm(list2);
        }

        public void CreateRoundSymbList(StOp listN)
        {
            int count_elemants_list1 = 0;
            Console.WriteLine("count element:");
            count_elemants_list1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What copy?");
            TEMP = Console.ReadLine();
            for (int i = 0; i < count_elemants_list1; i++)
            {
                listN.StList.Add(new St(null, null, "", ""));
                Console.WriteLine($"Comp el №{i + 1}");
                listN.StList[i].comp = Console.ReadLine();
                Console.WriteLine($"Val el №{i + 1}?");
                listN.StList[i].val = Console.ReadLine();
            }
            this.Sybm(this);
        }

        public override string ToString()
        {
            string outt = "";
            for (int i = 0; i < this.StList.Count(); i++)
            {
                outt += $"{this.StList[i].val}" + " ";
            }
            return outt;
        }

        public void Sybm(StOp listN)
        {
            for (int i = 0; i < listN.StList.Count(); i++)
            {
                if (i + 1 == listN.StList.Count())
                {
                    listN.StList[i].nex = listN.StList[0];
                    listN.StList[i].pre = listN.StList[i - 1];
                }
                else if (i - 1 < 0)
                {
                    listN.StList[i].nex = listN.StList[i + 1];
                    listN.StList[i].pre = listN.StList[listN.StList.Count() - 1];
                }
                else
                {
                    listN.StList[i].nex = listN.StList[i + 1];
                    listN.StList[i].pre = listN.StList[i - 1];
                }
            }
        }
    }

    public class St
    {
        public St nex = null;
        public St pre = null;
        public string val = "";
        public string comp = "";

        public St(St nx, St pr, string v, string c)
        {
            nex = nx;
            pre = pr;
            val = v;
            comp = c;
        }      
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            StOp op1 = new StOp();
            op1.CreateRoundSymbList(op1);
            StOp op2 = new StOp();
            op1.Clone(op1, op2);
            Console.WriteLine(op2.ToString());
        }
    }
}