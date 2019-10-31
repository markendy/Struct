using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l3
{
    class Node
    {
        public Node rigth = null;
        public Node left = null;
        public Node parent = null;
        public int val;

        public Node(int val_)
        {
            val = val_;
        }

        public int CompareTo(int val_)
        {
            if (val > val_)
            {
                return -1;
            }
            else if (val == val_)
            {
                return 0;
            }
            else return 1;
        }
    }

    class Tree
    {
        public Node root = null;

        public void DelMy(int val_)
        {
            if (root == null)
            {
                Console.WriteLine("root null");
            }
            else DelMyTo(root, val_);
        }
        private void DelMyTo(Node obj, int val_)
        {
            if (obj.CompareTo(val_) == 0)
            {
                //1-3) 
                GoMi(ref obj);
                //4 
                if (obj.left != null & obj.rigth != null)
                {
                    obj.val = FindMin(obj.rigth).val;
                    GoMi(FindMin(obj.rigth));
                    //1.1 
                    if (obj.left == null & obj.rigth == null)
                    {
                        One(ref obj);
                    }
                    //2.1 
                    else if (obj.left != null & obj.rigth == null)
                    {
                        Two(ref obj);
                    }
                }
            }
            else
            {
                if (obj.left != null)
                {
                    DelMyTo(obj.left, val_);
                }
                if (obj.rigth != null)
                {
                    DelMyTo(obj.rigth, val_);
                }
                else
                {
                    return;
                }
            }
        }
        //Для обхода удаления 
        private void GoMi(Node obj)
        {
            if (obj.left == null & obj.rigth == null)
            {
                One(ref obj);
            }
            //2 
            else if (obj.left != null & obj.rigth == null)
            {
                Two(ref obj);
            }
            //3 
            else if (obj.left == null & obj.rigth != null)
            {
                obj.parent.rigth = obj.rigth;
            }
        }
        private void GoMi(ref Node obj)
        {
            if (obj.left == null & obj.rigth == null)
            {
                One(ref obj);
            }
            //2 
            else if (obj.left != null & obj.rigth == null)
            {
                Two(ref obj);
            }
            //3 
            else if (obj.left == null & obj.rigth != null)
            {
                obj.parent.rigth = obj.rigth;
            }
        }
        private void One(ref Node obj)
        {
            if (obj.parent.left == obj)
            {
                obj.parent.left = null;
            }
            else if (obj.parent.rigth == obj)
            {
                obj.parent.rigth = null;
            }
        }
        private void Two(ref Node obj)
        {
            obj.parent.left = obj.left;
        }
        private Node FindMin(Node obj)
        {
            if (obj.left == null)
            {
                return obj;
            }
            else return FindMin(obj.left);
        }

        public void View(Node obj)
        {
            Console.WriteLine(Convert.ToInt32(obj.val));
            if (obj.left != null)
            {
                View(obj.left);
            }
            if (obj.rigth != null)
            {
                View(obj.rigth);
            }
            else
            {
                return;
            }
        }
        public void Add(int val_)
        {
            if (root == null)
            {
                root = new Node(val_);
            }
            else AddTo(root, val_);
        }
        private void AddTo(Node obj, int val_)
        {
            if (obj.CompareTo(val_) < 0)
            {
                if (obj.left == null)
                {
                    obj.left = new Node(val_);
                    obj.left.parent = obj;
                }
                else
                {
                    AddTo(obj.left, val_);
                }
            }
            if (obj.CompareTo(val_) >= 0)
            {
                if (obj.rigth == null)
                {
                    obj.rigth = new Node(val_);
                    obj.rigth.parent = obj;
                }
                else
                {
                    AddTo(obj.rigth, val_);
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Tree tr1 = new Tree();
            tr1.Add(3);
            tr1.Add(6);
            tr1.Add(7);
            tr1.Add(2);
            tr1.Add(5);
            tr1.Add(9);
            tr1.View(tr1.root);
            tr1.DelMy(6);
            Console.WriteLine("razdel");
            tr1.View(tr1.root);
        }
    }
}