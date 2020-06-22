using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Third_task
{
    class Node<T> :IEnumerable<T>
        where T :IComparable
    {
        public T Data { get; set; }
        public Node<T> Left { get; set; }
        public Node <T> Right { get; set; }
        public event Mydelegate SomeMyEvent;
        public Node(T data)
        {
            Data = data;
        }
        public Node (T data, Node<T> left,Node<T> right)
        {
            Data = data;
            Left = left;
            Right = right;
        }
        public int CompareTo(object obj)
        {
            if(obj is Node<T> item)
            {
                return Data.CompareTo(item);
            }
            else
            {
                throw new  ArgumentException("wrong types");
            }
        }
        public void Addel(T data)
        {
            var node = new Node<T>(data);
            if (node.Data.CompareTo(Data) == -1)
            {
                if (Left == null)
                {
                    Left = node;
                    SomeMyEvent?.Invoke($"Element was added: {data}");
                }
                else
                {
                    Left.Addel(data);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = node;
                    SomeMyEvent?.Invoke($"Element was added: {data}");
                }
                else
                {
                    Right.Addel(data);
                }
            }
            
        }
        public Node<T> Remove(Node <T> root,T data)
        {
            if (root == null)
                return root;
            if (data.CompareTo(root.Data)<0)
                {
                root.Left = Remove(root.Left, data);
                }
            else if (data.CompareTo(root.Data)>0) 
            {
                root.Right = Remove(root.Right, data);
            }
            else
            {
                if (root.Left == null)
                    return root.Right;
                else if (root.Right==null) { return root.Left; }
                root.Data = minValue(root.Right);
                root.Right = Remove(root.Right,root.Data);
            }
            return root;
        }
        T  minValue(Node<T> root)
        {
            var minv = root.Data;
            while (root.Left != null)
            {
                minv = root.Left.Data;
                root = root.Left;
            }
            return minv;
        }
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            if (Left != null)
            {
                foreach (T item in this.Left)
                {
                    yield return item;
                }
            }

            yield return this.Data;

            if (this.Right != null)
            {
                foreach (T item in this.Right)
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
