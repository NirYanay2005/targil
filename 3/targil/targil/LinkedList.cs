﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


/*
 * I am pretty much sure that there is a problem with the question. Look at 6.b and 6.c
 * time complexties should be swapped, or you should have asked 6.a to be tail.
 * Since I am not sure -  I added tail...
 */

namespace targil
{
    class LinkedList : IEnumerable<int>
    {
        private Node head;
        private Node tail;
        private Node maxNode;
        private Node minNode;
        public LinkedList() // Default
        {
            head = new Node(-1, null);
        }
        public LinkedList(int headValue)
        {
            head = new Node(headValue, tail);
            maxNode = head;
            minNode = head;
        }
        public void Append(int newValue) // Adds a new node to the end of the list
        {
            Node tmp;
            if (tail == null)
            {
                tail = new Node(newValue, null);
                head.Next = tail;
            }
            else
            {
                Node newTail = new Node(newValue, null);
                tail.Next = newTail;
                tail = newTail;
            }
            tmp = tail;
            if (tmp.Value > maxNode.Value)
            {
                maxNode = tmp;
            }
            else if (tmp.Value < minNode.Value)
            {
                minNode = tmp;
            }
        }
        public void Prepend(int newValue) // Adds a new node to the front of the list
        {
            Node newHead = new Node(newValue, head), tmp;
            head = newHead;
            tmp = head;
            if (tmp.Value > maxNode.Value)
            {
                maxNode = tmp;
            }
            else if (tmp.Value < minNode.Value)
            {
                minNode = tmp;
            }
        }
        public int Pop() // Removes Node from end of list
        {
            int tailValue = tail.Value;
            Node tmp = head;
            while (tmp.Next.Next != null)
            {
                tmp = tmp.Next;
            }
            tmp.Next = null;
            tail = tmp;
            return tailValue;
        }
        public int Unqueue() // Removes Node from head of list
        {
            int headValue = head.Value;
            head = head.Next;
            return headValue;
        }
        public IEnumerator<int> GetEnumerator() // I didnt find a way to make this ToList...
        {
            Node tmp = head;
            while (tmp != null)
            {
                yield return tmp.Value;
                tmp = tmp.Next;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerable<int> ToList() 
        {
            Node tmp = head;
            while (tmp != null)
            {
                yield return tmp.Value;
                tmp = tmp.Next;
            }
        }

        /*
         * I dont know if it works but my idead was that if it is curcular at some point
         * the function will have the same node as one and two
         * 
         */
        public bool IsCircular()
        {
            // Dont understand how can it happen to a user, a user adds ints which creates new nodes... No node will be the same.
            Node one = head, two = head.Next;

            while (one != null && two != null && two.Next != null)
            {
                if (one == two)
                {
                    return true;
                }
                one = one.Next;
                two = two.Next.Next;
            }
            return false;
        } // cheks if function is circular
        private Node getMiddle(Node startNode)
        {
            Node middle = startNode;
            Node end = startNode.Next;
            while (end != null)
            {
                end = end.Next;
                if (end != null)
                {
                    middle = middle.Next;
                    end = end.Next;
                }
            }
            return middle;
        } // helper funciton to get the middle of a list for. used for sorting
        private Node merge(Node left, Node right)
        {
            Node tmp = new Node(-1, null);
            Node remTmpHead = tmp;
            while (left != null && right != null)
            {
                if (left.Value < right.Value)
                {
                    tmp.Next = left;
                    left = left.Next;
                }
                else
                {
                    tmp.Next = right;
                    right = right.Next;
                }
                tmp = tmp.Next;
            }
            if (left != null)
            {
                tmp.Next = left;
            }
            if (right != null)
            {
                tmp.Next = right;
            }
            return remTmpHead.Next;
        } // helper function to merge two lists and sort them.
        public Node sort(Node startNode) // sort list asceding
        {
            Node left = startNode;
            Node right, tmp;
            if (startNode == null || startNode.Next == null)
            {
                return startNode;
            }
            right = getMiddle(startNode);
            tmp = right.Next;
            right.Next = null;
            right = tmp;
            left = sort(left);
            right = sort(right);
            return merge(left, right);

        }
        public Node sort() // overloading sort
        {
            head = sort(head);
            return head;
        }
        public Node GetMaxNode()
        {
            return maxNode; 
        }
        public Node GetMinNode()
        {
            return minNode; 
        }

    }
}


