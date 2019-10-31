using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Tree
    {
        public int count = 0;
        Node root = null;

        public void Del(int _val)
        {
            if(root == null)
            {
                Console.WriteLine("Root null");
            }
            else
            {
             
            }
        }

        private void DelTo(Node obj, int _val)
        {
        }

        public Node FindMy(int _val, Node obj)
        {
            if (obj.val == _val)
            {
                return obj;
            }
            if (obj.val < _val)
            {
                if (obj.left == null)
                    return null;
                return FindMy(_val, obj);
            }
            else
            {
                if (obj.rigth == null)
                    return null;
                return FindMy(_val, obj);
            }
        }

        public void Add(int _val)
        {
            if (root == null)
            {
                root = new Node(_val);
            }
            else
            {
                AddTo(root, _val);
            }
        }
        private void AddTo(Node obj, int _val)
        {
            if (obj.val < _val)
            {
                if (obj.left == null)
                {
                    obj.left.val = _val;
                }
                else
                {
                    AddTo(obj.left, _val);
                }
            }
            else
            {
                if (obj.rigth == null)
                {
                    obj.rigth.val = _val;
                }
                else
                {
                    AddTo(obj.rigth, _val);
                }
            }
        }
    }

    class Node
    {
        public Node rigth;
        public Node left;
        public int val;

        public Node(int _val)
        {
            val = _val;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}