using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temp
{
    public class StructList
    {
        public List<Struct> AllList = new List<Struct>();
    }

    public class Struct {
        public Struct Next = null;
        public Struct Prev = null;
        public int Val = 0;

        public Struct(Struct Next_, Struct Prev_, int val_)
        {
            this.Next = Next_;
            this.Prev = Prev_;
            this.Val = val_;
        }

        public void Paste_after(int number, List <Struct> allist)
        { 
            this.Next = allist[number].Next;
            this.Prev = allist[number + 1].Prev;
            allist[number].Next = this;
            allist[number + 1].Prev = this;
            allist.Insert(number+1, this);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            StructList test = new StructList();
            test.AllList.Add(new Struct(null, null, 2));
            test.AllList.Add(new Struct(null,test.AllList[0], 3));
            test.AllList[0].Next = test.AllList[1];
            Struct vlo = new Struct(null, null, 4);
            vlo.Paste_after(0, test.AllList);
        }
    }
}
