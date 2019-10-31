using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L4
{

    public class Set<T> : IEnumerable<T>
    {
        public List<T> items = new List<T>();

        public int Count => items.Count;

        public void Add(T item_)
        {
            if (item_ == null)
            {
                throw new ArgumentNullException(nameof(item_));
            }
            else
            {
                if (!items.Contains(item_))
                {
                    items.Add(item_);
                }
            }
        }
        public void Del(T item_)
        {
            if (item_ == null)
            {
                throw new ArgumentNullException(nameof(item_));
            }
            else
            {
                if (items.Contains(item_))
                {
                    items.Remove(item_);
                }
                else
                {
                    Console.WriteLine("El not found");
                }
            }
        }
        public Set<T> Unity(Set<T> set1, Set<T> set2)
        {
            if (set1 == null || set2 == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                var resultSet = new Set<T>();
                var itemss = new List<T>();
                if (set1.items != null && set1.items.Count > 0)
                {
                    itemss.AddRange(new List<T>(set1.items));
                }
                if (set2.items != null && set2.items.Count > 0)
                {
                    itemss.AddRange(new List<T>(set2.items));
                }
                resultSet.items = itemss.Distinct().ToList();
                return resultSet;
            }
        }

        public Set<T> Defo(Set<T> set1, Set<T> set2)
        {
            if (set1 == null || set2 == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                var resSet = new Set<T>();
                foreach (var it in set2)
                {
                    if (set1.Contains(it))
                    {
                        resSet.Add(it);
                    }
                }
                return resSet;
            }
        }

        public Set<T> Razn(Set<T> set1, Set<T> set2)
        {
            if (set1 == null || set2 == null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                var resSet = new Set<T>();
                foreach (var it in set2)
                {
                    if (!set1.Contains(it))
                    {
                        resSet.Add(it);
                    }
                }
                return resSet;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Set<string> list = new Set<string>();
            list.items.Add(new Se);

            /*
            //type fish: 1, 2, 3, 4, 5, 6;
            Set<int> fishman1 = new Set<int>();
            Set<int> fishman2 = new Set<int> { 1, 3, 5 };
            Set<int> fishman3 = new Set<int> { 3, 4, 5 };
            Set<int>[] fishmans = { fishman1, fishman2, fishman3 };

            Set<int> ozero = new Set<int> { 1, 2, 3, 4, 5, 6 };

            Set<int> answ1 = new Set<int>();
            Set<int> answ2 = new Set<int>();

            fishman1.Add(2);
            fishman1.Add(4);
            fishman1.Add(6);
            fishman1.Add(5);
            fishman1.Del(5);

            for (int i = 0; i < 1; i++)
            {
                answ1 = fishmans[i].Defo(fishmans[i], ozero);
                answ2 = fishmans[i].Razn(fishmans[i], ozero);
            }*/
        }
    }
}