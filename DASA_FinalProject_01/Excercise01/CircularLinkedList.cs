using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DASA_FinalProject_01
{
    public class Node
    {
        public Employee Data;
        public Node Next;

        public Node(Employee data)
        {
            Data = data;
            Next = null;
        }
    }

    public class CircularLinkedList
    {
        public Node head;

        public CircularLinkedList()
        {
            head = null;
        }

        public bool IsEmpty()
        {
            return head == null;
        }

        public void InsertAtEnd(Employee employee)
        {
            Node newNode = new Node(employee);
            if (IsEmpty())
            {
                head = newNode;
                newNode.Next = head;
            }
            else
            {
                Node temp = head;
                while (temp.Next != head)
                {
                    temp = temp.Next;
                }
                temp.Next = newNode;
                newNode.Next = head;
            }
        }

        public void InsertAfter(Node prevNode, Employee employee)
        {
            if (prevNode == null)
            {
                MessageBox.Show("The given previous node cannot be null.");
                return;
            }

            Node newNode = new Node(employee);
            newNode.Next = prevNode.Next;
            prevNode.Next = newNode;
        }

        public void RemoveAfter(Node prevNode)
        {
            if (prevNode == null || prevNode.Next == null)
            {
                MessageBox.Show("The given previous node is not valid or has no next node.");
                return;
            }

            Node nodeToRemove = prevNode.Next;
            prevNode.Next = nodeToRemove.Next;

            if (nodeToRemove == head) // If the node to remove is the head
            {
                head = prevNode.Next;
            }
        }

        public void SelectionSort()
        {
            if (IsEmpty() || head.Next == head) return; // List is empty or has one node

            Node current = head;
            do
            {
                Node minNode = current;
                Node nextNode = current.Next;

                do
                {
                    if (nextNode.Data.ID < minNode.Data.ID)
                    {
                        minNode = nextNode;
                    }
                    nextNode = nextNode.Next;
                } while (nextNode != head);

                // Swap data
                if (minNode != current)
                {
                    Employee temp = current.Data;
                    current.Data = minNode.Data;
                    minNode.Data = temp;
                }

                current = current.Next;
            } while (current != head);
        }

        public void QuickSort()
        {
            if (IsEmpty() || head.Next == head) return; // List is empty or has one node
            head = QuickSort(head);
        }

        private Node QuickSort(Node head)
        {
            if (head == null || head.Next == head) return head;

            Node pivot = head;
            Node lessHead = null, lessTail = null;
            Node greaterHead = null, greaterTail = null;

            Node current = head.Next;
            do
            {
                if (current.Data.ID < pivot.Data.ID)
                {
                    if (lessHead == null)
                    {
                        lessHead = current;
                        lessTail = lessHead;
                    }
                    else
                    {
                        lessTail.Next = current;
                        lessTail = lessTail.Next;
                    }
                }
                else
                {
                    if (greaterHead == null)
                    {
                        greaterHead = current;
                        greaterTail = greaterHead;
                    }
                    else
                    {
                        greaterTail.Next = current;
                        greaterTail = greaterTail.Next;
                    }
                }
                current = current.Next;
            } while (current != head);

            if (lessTail != null) lessTail.Next = pivot;
            else lessHead = pivot;

            pivot.Next = QuickSort(greaterHead);

            if (lessTail != null) lessTail.Next = lessHead;
            else head = lessHead;

            return head;
        }

        public void Merge(CircularLinkedList otherList)
        {
            if (otherList.IsEmpty()) return;

            if (IsEmpty())
            {
                head = otherList.head;
                return;
            }

            Node temp = head;
            while (temp.Next != head)
            {
                temp = temp.Next;
            }
            temp.Next = otherList.head;

            // Make the merged list circular
            Node otherTemp = otherList.head;
            while (otherTemp.Next != otherList.head)
            {
                otherTemp = otherTemp.Next;
            }
            otherTemp.Next = head;
            head = otherList.head; // Update head to point to the merged list
        }

        public void RemoveAllByPosition(string position)
        {
            if (IsEmpty()) return;

            Node current = head;
            Node prev = null;

            do
            {
                if (current.Data.Position == position)
                {
                    if (prev == null) // Removing head
                    {
                        Node temp = head;
                        while (temp.Next != head)
                        {
                            temp = temp.Next;
                        }
                        if (head.Next == head) // Only one node
                        {
                            head = null;
                        }
                        else
                        {
                            head = head.Next;
                            temp.Next = head;
                        }
                    }
                    else
                    {
                        prev.Next = current.Next;
                    }
                    current = (prev == null) ? head : prev.Next; // Update current
                }
                else
                {
                    prev = current;
                    current = current.Next;
                }
            } while (current != head);
        }
    }
}
