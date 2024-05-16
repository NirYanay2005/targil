using System;
using System.Collections.Generic;
using System.Text;

namespace targil
{
    class Node
    {
        private int value;
        private Node next;

        public Node(int NodeValue, Node nextNode)
        {
            value = NodeValue;
            next = nextNode;
        }
        public int Value
        {
            get { return value; }
            set { this.value = value; }
        }
        public Node Next
        {
            get { return next; }
            set { this.next = value; }
        }

    }
}
