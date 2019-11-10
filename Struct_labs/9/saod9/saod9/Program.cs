using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace saod9
{
    public class Node<T>
    {
        public Node<T> Left = null;
        public Node<T> Rigth = null;
        public T Value { get; set; }

        public int ID = 0;
        public int lvl = 0;
        public Node<T> parent = null;

        public Node(T v, int l, int i)
        {
            Value = v;
            lvl = l;
            ID = i;
        }

        public int CompareTo(T other)
        {
            if (this.Value.GetHashCode() > other.GetHashCode())
            {
                return 1;
            }
            if (this.Value.GetHashCode() < other.GetHashCode())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }

    public class Tree<T>
    {
        public int Count = 0;
        public string OutS = "";
        private List<Node<T>> OutL = new List<Node<T>>();
        public Node<T> root = null;

        public Tree() { }
     
        //Обходы:      
        
        public void GoToDeep(Node<T> obj)
        {
            if (root == null)
            {
               Console.WriteLine("Tree null");
            }
            else
            {
                OutS += obj.Value + " ";
                if (obj.Left != null) GoToDeep(obj.Left);
                if (obj.Rigth != null) GoToDeep(obj.Rigth);
            }
        }
        public void GoToWeigth(Node<T> root)
        {
            if (root == null)
            {
                Console.WriteLine("Tree null");
            }
            else
            {
                Queue<Node < T >> q = new Queue<Node<T>>();
                //Для начала поместим в очередь корень 
                q.Enqueue(root);
                while (q.Count != 0)
                {
                    Node<T> tmp = (Node<T>)q.Dequeue();
                    OutS += (" " + tmp.Value);
                    //Если есть левый наследник, то помещаем его в очередь для дальнейшей обработки 
                    if (tmp.Left != null)
                    {
                        q.Enqueue(tmp.Left);
                    }
                    //Если есть правый наследник, то помещаем его в очередь для дальнейшей обработки 
                    if (tmp.Rigth != null)
                    {
                        q.Enqueue(tmp.Rigth);
                    }
                }
            }
        }
        //Задачи: 
        //-->Поиск значения 
        public Node<T> SearchValue(Node<T> obj, T v)
        {
            Node<T> b = new Node<T>(v, obj.lvl, obj.ID);
            if (obj == null)
                return null;
            if (obj.CompareTo(v)==0)
                b = obj;
            else
            {
                if (obj.CompareTo(v) == 1)
                    b = SearchValue(obj.Left, v);
                else
                    b = SearchValue(obj.Rigth, v);
            }
            return b;
        }
        //Работа со структурой: 
        public void Add(T v)
        {
            if (root == null)
            {
                root = new Node<T>(v, 0, 0);
            }
            else
            {
                AddC(root, v);
            }
            Count++;
        }
        private void AddC(Node<T> obj, T v)
        {
            if (obj.CompareTo(v) == 1)
            {
                if (obj.Left == null)
                {
                    obj.Left = new Node<T>(v, obj.lvl + 1, Count);
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
                    obj.Rigth = new Node<T>(v, obj.lvl + 1, Count);
                    obj.Rigth.parent = obj;
                }
                else
                {
                    AddC(obj.Rigth, v);
                }
            }
        }
        public void Delete(T v)
        {
            if (root == null)
            {
                OutS = "Root null";
            }
            else
            {
                DelC(root, v);
            }
            Count--;
        }
        private void DelC(Node<T> obj, T v)
        {
            if (obj.CompareTo(v) == 0)
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
                        obj.parent.Rigth = obj.Left;
                        obj.Left.parent = obj.parent;
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
                        obj.parent = null;
                    }
                    else if (PerevParnt(obj) == 2)
                    {
                        obj.parent.Left = null;
                        obj.parent = null;
                    }
                }
            }
            else if (obj.CompareTo(v) == 1)
            {
                if (obj.Left != null)
                    DelC(obj.Left, v);
                else
                {
                    OutS = "not found";
                }
            }
            else if (obj.CompareTo(v) == -1 || obj.CompareTo(v) == 0)
            {
                if (obj.Rigth != null)
                    DelC(obj.Rigth, v);
                else
                {
                    OutS = "not found";
                }
            }
        }
        //Аналитические функции: 
        //-->Определение кем элемент является для родителя 
        private int PerevParnt(Node<T> obj)
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
        private T FindMin(Node<T> obj)
        {
            T i = obj.Value;
            if (obj.Left != null)
            {
                i = FindMin(obj.Left);
            }
            return i;
        }
        public void FindLvlDeep(Node<T> obj, ref int max_lvl)
        {
            if (root == null)
            {
                Console.WriteLine("Tree null");
            }
            else
            {
                if (max_lvl < obj.lvl)
                {
                    max_lvl = obj.lvl;
                }
                if (obj.Left != null)
                {
                    FindLvlDeep(obj.Left, ref max_lvl);
                }
                if (obj.Rigth != null)
                {
                    FindLvlDeep(obj.Rigth, ref max_lvl);
                }
            }
        }
        //-->Анализ типа случая(1 - есть правый, 2 - есть левый, нет правого, 3 - нет ни одного) 
        private int AnalyticTypeForMinFindDel(Node<T> obj)
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
            Tree<string> tree = new Tree<string>();
            tree.Add("a");
            tree.Add("b");
            tree.Add("d");
            tree.Add("f");
            tree.Add("g");
            tree.Add("h");
            tree.Delete("b");
            tree.SearchValue(tree.root, "f");
        }
    }
}
