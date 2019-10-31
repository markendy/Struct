using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l6
{
    public class Node
    {
        public Node Left = null;
        public Node Rigth = null;
        public int Value = 0;

        public Node parent = null;

        public Node(int v)
        {
            Value = v;
        }
    }

    public class Tree
    {
        public Node root = null;

        public void AddDef()
        {
            Add(2);
            Add(1);
            Add(4);
            Add(3);
            Add(5);
        }

        public void GoToDeep(Node obj)
        {
            Console.WriteLine(obj.Value);
            if (obj.Left != null) GoToDeep(obj.Left);
            if (obj.Rigth != null) GoToDeep(obj.Rigth);
        }

        public void Add(int v)
        {
            if (root == null)
            {
                root = new Node(v);
            }
            else
            {
                AddC(root, v);
            }
        }
        private void AddC(Node obj, int v)
        {
            if (obj.Value > v)
            {
                if (obj.Left == null)
                {
                    obj.Left = new Node(v);
                    obj.Left.parent = obj;
                }
                else
                {
                    AddC(obj.Left, v);
                }
            }
            else
            {
                if (obj.Rigth == null)
                {
                    obj.Rigth = new Node(v);
                    obj.Rigth.parent = obj;
                }
                else
                {
                    AddC(obj.Rigth, v);
                }
            }

        }

        public void Delete(int v)
        {
            if (root == null)
            {
                Console.WriteLine("Root null");
            }
            else
            {
                DelC(root, v);
            }
        }
        private void DelC(Node obj, int v)
        {
            if (obj.Value == v)
            {
                if (AnalyticTypeForMinFindDel(obj) == 1)
                {
                    obj.Value = FindMin(obj.Rigth);
                    DelC(obj.Rigth, FindMin(obj.Rigth));
                }
                else if (AnalyticTypeForMinFindDel(obj) == 2)
                {
                    if (obj == root)
                    {
                        obj.Left.parent = null;
                        root = obj.Left;
                    }
                    else
                    {
                        obj.parent.Left = obj.Left;
                    }
                }
                else
                {
                    if (obj == root)
                    {
                        root = null;
                    }
                    else if (PerevParnt(obj) == 1)
                    {
                        obj.parent.Rigth = null;
                    }
                    else if (PerevParnt(obj) == 2)
                    {
                        obj.parent.Left = null;
                    }
                }
            }
            else if (obj.Value > v)
            {
                if (obj.Left != null)
                    DelC(obj.Left, v);
                else
                {
                    Console.WriteLine("not found");
                }
            }
            else if (obj.Value <= v)
            {
                if (obj.Rigth != null)
                    DelC(obj.Rigth, v);
                else
                {
                    Console.WriteLine("not found");
                }
            }
        }

        private int PerevParnt(Node obj)
        {
            if (obj.parent.Left == obj)
            {
                return 2;
            }
            else if (obj.parent.Rigth == obj)
            {
                return 1;
            }
            return -1;
        }
        private int FindMin(Node obj)
        {
            int i = obj.Value;
            if (obj.Left != null)
            {
                i = FindMin(obj.Left);
            }
            return i;
        }
        private int AnalyticTypeForMinFindDel(Node obj)
        {
            if (obj.Rigth != null)
            {
                return 1;
            }
            else if (obj.Left == null)
            {
                return 0;
            }
            return 2;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Program op = new Program();
            Tree MyTree = new Tree();
            string[] m = Console.ReadLine().Split();
            int[] tm = new int[m.Length];
            for(int i =0; i < tm.Length; i++)
            {
                tm[i] = Convert.ToInt32(m[i]);
            }
            Array.Sort(tm);
            for (int i = 0; i < m.Length; i++)
            {
                MyTree.Add(Convert.ToInt32(tm[i]));
            }
            op.GoSearch(MyTree);
        }

        void GoSearch(Tree MyTree)
        {
            Program op_t = new Program();
            int g1 = 0;
            int g2 = 0;
            Quest6(MyTree.root, ref g1, ref g2);
            Console.WriteLine(g1+ " " + g2);
        }

        void Quest6(Node obj, ref int g1, ref int g2)
        {
            int temp = 0;
            if (obj.Rigth != null)
            {
                Quest6(obj.Rigth, ref g1, ref g2);
            }
            if (obj.Left != null)
            {
                Quest6(obj.Left, ref g1, ref g2);
            }
            temp = obj.Value;
            if (g1 < g2)
            {
                g1 += temp;
            }
            else
            {
                g2 += temp;
            }
        }
    }
}
