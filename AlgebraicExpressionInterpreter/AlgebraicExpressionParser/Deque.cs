using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgebraicExpressionParser
{
    public class Deque<T>
    {
        private List<T> list = new List<T>();

        public int Count => list.Count;

        public void PushBack(T item)
        {
            list.Add(item);
        }

        public T PeekBack()
        {
            return list.Last();
        }
        
        public T PopBack()
        {
            T item = list.Last();
            list.RemoveAt(list.Count - 1);
            return item;
        }

        public T PopFront()
        {
            T item = list.First();
            list.RemoveAt(0);
            return item;
        }

        public void Clear()
        {
            list.Clear();
        }
    }
}
