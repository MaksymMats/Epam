using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Third_task
{
    public delegate void Mydelegate(object value);
    static class Extensions
    {
        public static void InsertItems<T>(this BinaryTree<T> tree, params T[] items) where T : IComparable
        {
            foreach (T item in items)
            {
                tree.Addel(item);
            }
        }
    }
    
    class BinaryTree<T> : IEnumerable<T>
        where T : IComparable
    {
        public Node<T> Root { get; set; }
        public BinaryTree<T> LeftTree { get; set; }
        public BinaryTree<T> RightTree { get; set; }
       
        public event Mydelegate SomeMyEvent;
        public event Mydelegate RemoveEvent;

        public void Addel(T data)
        {
            if (Root == null)
            {
                Root = new Node<T>(data);
                SomeMyEvent?.Invoke($"Element was added: {data}");
                return;
            }
            Root.Addel(data);
            SomeMyEvent?.Invoke($"Element was added: {data}");
        }
        public bool Remove(T data)
        {
            if (Root==null)
            {
                return false;
            }
            Root.Remove(Root,data);
            RemoveEvent?.Invoke($"Element was removed : {data}");
            return true;
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            if (Root.Left != null)
            {
                foreach (T item in this.Root.Left)
                {
                    yield return item;
                }
            }

            yield return this.Root.Data;

            if (this.Root.Right != null)
            {
                foreach (T item in this.Root.Right)
                {
                    yield return item;
                }
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
