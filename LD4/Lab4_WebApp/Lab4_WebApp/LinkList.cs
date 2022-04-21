using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lab4_WebApp
{
    public sealed class LinkList<T> : ICollection<T> where T : IEquatable<T>, IComparable<T>
    {
        private sealed class Node<Type> //Private generic Node class
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

        //Constructor
        public LinkList()
        {
            Head = null;
            Tail = null;
        }

        /// <summary>
        /// Outputs how many objects are in the list
        /// </summary>
        /// <returns>amount of objects</returns>
        public int Count()
        {
            int count = 0;
            foreach(T type in this)
            {
                count++;
            }
            return count;
        }

        /// <summary>
        /// Tells if this list is read only
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// ICollection interface .Count property
        /// </summary>
        int ICollection<T>.Count => Count();

        /// <summary>
        /// Adds a new object to the list
        /// </summary>
        /// <param name="item"></param>
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

        /// <summary>
        /// Gets an object by index
        /// </summary>
        /// <param name="index">object index to return</param>
        /// <returns>object by index in the list</returns>
        public T Get(int index)
        {
            int count = 0;
            for (Node<T> d = Head; d != null; d = d.Link)
            {
                if (count == index)
                {
                    return d.Value;
                }
                count++;
            }
            return default(T);
        }

        /// <summary>
        /// Resets list
        /// </summary>
        public void Clear()
        {
            Head = null;
            Tail = null;
        }

        /// <summary>
        /// Checks if a list contains a specific object
        /// </summary>
        /// <param name="item">object to check for</param>
        /// <returns>true or false, depending on the outcome</returns>
        public bool Contains(T item)
        {
            for (Node <T> d = Head; d != null; d = d.Link)
            {
                if (d.Value.Equals(item)) return true;
            }
            return false;
        }

        /// <summary>
        /// Copies this list to the same type array
        /// </summary>
        /// <param name="array">array to copy to</param>
        /// <param name="arrayIndex">array's index (free space to assign data)</param>
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
        
        /// <summary>
        /// Adds LinkList to this Linklist
        /// </summary>
        /// <param name="toAdd">list to add</param>
        private void AddLinkList(LinkList<T> toAdd)
        {
            foreach(T value in toAdd)
            {
                Add(value);
            }
        }

        /// <summary>
        /// Replaces this list with another list
        /// </summary>
        /// <param name="toReplace">list to replace this list</param>
        private void ReplaceThisList(LinkList<T> toReplace) 
        {
            Clear();
            foreach (T value in toReplace)
            {
                Add(value);
            }
        }

        /// <summary>
        /// Removes a particular object
        /// </summary>
        /// <param name="item">object to remove</param>
        /// <returns>true if remove succeeded, else - false</returns>
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

        /// <summary>
        /// Extracts a particular inherited class from parent's list
        /// </summary>
        /// <typeparam name="Type">type of the list to extract</typeparam>
        /// <returns>extracted list by class</returns>
        public LinkList<T> ExtractClassList<Type>()
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

        /// <summary>
        /// Sorts particular class objects by a defined pattern
        /// </summary>
        /// <typeparam name="Type">Class to sort like</typeparam>
        private void SortByClass<Type>() where Type : class, IComparable<Type>
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

        /// <summary>
        /// Executes extraction of lists and their sorting
        /// </summary>
        public void CustomSort()
        {
            LinkList<T> museums = ExtractClassList<Museum>();
            LinkList<T> statues = ExtractClassList<Statue>();

            if (museums.Count() > 0) museums.SortByClass<Museum>();
            if (statues.Count() > 0) statues.SortByClass<Statue>();

            ReplaceThisList(museums + statues);
        }

        /// <summary>
        /// Operator "+" method
        /// </summary>
        /// <param name="one">List to add</param>
        /// <param name="second">LISst to add</param>
        /// <returns>connected list</returns>
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
