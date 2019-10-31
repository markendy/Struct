using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    public class Node<T>:IComparer
    {
        public Node<T> left, right, parent = null;
        public T val;

        bool flagProidenLiYzel = false;

        public Node(T val_)
        {
            val = val_;
        }

        public int Compare(object x, object y)
        {
            throw new NotImplementedException();
        }
    }

    public class Tree<T>:IEnumerable
    {
        public Node<T> root = null;
        public bool directDown = true;
        public int counter = 0;

        public void Add(T _val)
        {
            if (root == null)
            {
                root = new Node<T>(_val);
                counter++;
            }
            else
            {
                AddTo(root, _val);
                counter++;
            }
        }

        private void AddTo(Node<T> obj, T _val)
        {
            if (obj.left == null)
            {
                obj.left = new Node<T>(_val);
                obj.left.parent = obj;
            }
            else if (obj.right == null)
            {
                obj.right = new Node<T>(_val);
                obj.right.parent = obj;
            }
            else AddTo(obj, _val);
        }

        public void Delete(T _val)
        {
            if(root.val == null)
            {
                Console.WriteLine("Tree null");
            }
            else
            {
                counter--;
                DeleteTo(root,_val);
            }            
        }

        private void DeleteTo(Node<T> obj, T _val)
        {
            if(obj.Compare(obj.val, _val) == 0)
            {
                obj.parent.left = obj.left;
                obj.right = FindMy(obj.val, obj);
            }
        }

        private Node<T> FindMy(T _val, Node<T> obj1)
        {
            if(obj1.)
            {
                return obj1.left;
            }
            else if (obj1.right == null)
            {
                return obj1.right;
            }
            else
            {
                return FindMy(obj1.left);
            }
        }

        public void PrintAll()
        {
            for(int i =0; i < counter; i++)
            {
                Console.WriteLine();
            }
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}