using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LD3
{
    sealed class Node<Type>
    {
        public Type Value { get; set; }
        public Node<Type> Link { get; set; }
        public Node(Type value, Node<Type> link)
        {
            this.Value = value;
            this.Link = link;
        }
    }
}
