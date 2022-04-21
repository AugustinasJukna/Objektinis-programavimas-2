using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LAB4_ConsoleApp
{
    public sealed class LinkList<T> : ICollection<T> where T : IEquatable<T>, IComparable<T>
    {
        private sealed class Node<Type>
        {
            public Type Value { get; set; }
            public Node<Type> Link { get; set; }

            public Node(Type value, Node<Type> link)
            {
                Value = value;
                Link = link;
            }

            public Node() { }
        }

        private Node<T> Head;
        private Node<T> Tail;

        public int Count()
        {
            int count = 0;
            foreach(T type in this)
            {
                count++;
            }
            return count;
        }

        public bool IsReadOnly => true;

        int ICollection<T>.Count => Count();

        public LinkList()
        {
            Head = null;
            Tail = null;
        }

        public void Add(T item)
        {
            Node<T> node = new Node<T>(item, null);

            if (Head == null)
            {
                Head = node;
                Tail = node;
            }

            else
            {
                Tail.Link = node;
                Tail = node;
            }

        }

        public T Get(int index)
        {
            int count = 0;
            for (Node<T> d = Head; d != null; d = d.Link)
            {
                if (count == index)
                {
                    return d.Value;
                }
            }
            return default(T);
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
        }

        public bool Contains(T item)
        {
            for (Node <T> d = Head; d != null; d = d.Link)
            {
                if (d.Value.Equals(item)) return true;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {

            try
            {
                for (Node<T> d = Head; d != null; d = d.Link)
                {
                    array[arrayIndex++] = d.Value;
                }
            }

            catch (Exception)
            {
                throw;
            }
        }
    
        private void AddLinkList(LinkList<T> toAdd)
        {
            foreach(T value in toAdd)
            {
                Add(value);
            }
        }

        private void ReplaceThisList(LinkList<T> toReplace)
        {
            Clear();
            foreach (T value in toReplace)
            {
                Add(value);
            }
        }

        public bool Remove(T item)
        {
            for (Node<T> d = Head; d != null; d = d.Link)
            {
                if (d.Value.Equals(item) && d == Head)
                {
                    Head = d.Link;
                    return true;
                }

                else if (d.Value.Equals(item) && d != Head)
                {
                    Node<T> chargeNode;
                    for (chargeNode = Head; chargeNode.Link != d; chargeNode = chargeNode.Link) ;
                    chargeNode.Link = d.Link;
                    return true;
                }
            }
            return false;
        }

        public LinkList<T> ExtractClassList<Type>() where Type : IComparable<Type>, IEquatable<Type>
        {
            LinkList<T> extracted = new LinkList<T>();
            for (Node<T> d = Head; d != null; d = d.Link)
            {
                if (d.Value is Type)
                {
                    extracted.Add(d.Value);
                }
            }
            return extracted;
        }


        private void SortByClass<Type>() where Type : class, IComparable<Type>, IEquatable<Type>
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (Node<T> d = Head; d.Link != null; d = d.Link)
                {
                    Type value = d.Value as Type;
                    Type valueLink = d.Link.Value as Type;
                    if (value.CompareTo(valueLink) < 0)
                    {
                        T holder = d.Value;
                        d.Value = d.Link.Value;
                        d.Link.Value = holder;
                    }
                }
            }
        }

        public void CustomSort()
        {
            LinkList<T> museums = ExtractClassList<Museum>();
            LinkList<T> statues = ExtractClassList<Statue>();

            museums.SortByClass<Museum>();
            statues.SortByClass<Statue>();

            ReplaceThisList(museums + statues);
        }

        //public void Sort()
        //{
        //    for (Node<T> d = Head; d != null; d = d.Link)
        //    {
        //        Node<T> max = d;
        //        for (Node<T> dd = d.Link; dd != null; dd = dd.Link)
        //        {
        //            if (max.Value.GetType() == dd.Value.GetType())
        //            {
        //                switch (max.Value)
        //                {
        //                    case Museum museum:
        //                        if (museum.CompareTo(dd.Value as Museum) > 0)
        //                        {
        //                            Node<T> holder = max;
        //                            max = dd;
        //                            dd = holder;
        //                        }
        //                        break;
        //                    case Statue statue:
        //                        if (statue.CompareTo(dd.Value as Statue) > 0)
        //                        {
        //                            Node<T> holder = max;
        //                            max = dd;
        //                            dd = holder;
        //                        }
        //                        break;
        //                }
        //            }
        //        }
        //    }
        //}

        public static LinkList<T> operator +(LinkList<T> one, LinkList<T> second)
        {
            LinkList<T> merged = new LinkList<T>();
            merged.AddLinkList(one);
            merged.AddLinkList(second);
            return merged;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (Node<T> d = Head; d != null; d = d.Link)
            {
                yield return d.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
