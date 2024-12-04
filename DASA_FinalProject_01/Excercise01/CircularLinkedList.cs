using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DASA_FinalProject_01.Utils;

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
                OurMessageBox.Show("The given previous node cannot be null");
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
                OurMessageBox.Show("The given previous node is not valid or has no next node");
                return;
            }

            Node nodeToRemove = prevNode.Next;
            prevNode.Next = nodeToRemove.Next;

            if (nodeToRemove == head) 
            {
                head = prevNode.Next;
            }
        }

        public void SelectionSort01() // This is Ascending Order
        {
            if (IsEmpty() || head.Next == head) return;

            Node current = head;
            do
            {
                Node minNode = current;
                Node nextNode = current.Next;

                do
                {
                    if (nextNode.Data.ID > minNode.Data.ID)
                    {
                        minNode = nextNode;
                    }
                    nextNode = nextNode.Next;
                } while (nextNode != head);

                if (minNode != current)
                {
                    Employee temp = current.Data;
                    current.Data = minNode.Data;
                    minNode.Data = temp;
                }

                current = current.Next;
            } while (current != head);
        }
        public void SelectionSort02() // This is Descending Order
        {
            if (IsEmpty() || head.Next == head) return;

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
            if (IsEmpty() || head.Next == head) return;
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


            Node otherTemp = otherList.head;
            while (otherTemp.Next != otherList.head)
            {
                otherTemp = otherTemp.Next;
            }
            otherTemp.Next = head;
            head = otherList.head; 
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
                    if (prev == null) 
                    {
                        Node temp = head;
                        while (temp.Next != head)
                        {
                            temp = temp.Next;
                        }
                        if (head.Next == head) 
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
                    current = (prev == null) ? head : prev.Next; 
                }
                else
                {
                    prev = current;
                    current = current.Next;
                }
            } while (current != head);
        }
        public void RemoveAllByID(int id)
        {
            if (IsEmpty()) return;

            Node current = head;
            Node previous = null;
            bool found = false;

            do
            {
                if (current.Data.ID == id) 
                {
                    found = true; 

                    if (previous == null) 
                    {

                        if (current.Next == head)
                        {
                            head = null; 
                        }
                        else
                        {
                            
                            Node lastNode = head;
                            while (lastNode.Next != head)
                            {
                                lastNode = lastNode.Next;
                            }
                            head = current.Next; 
                            lastNode.Next = head;
                        }
                    }
                    else
                    {
                        previous.Next = current.Next;
                    }

                    current = previous != null ? previous.Next : head; 
                }
                else
                {
                    previous = current; 
                    current = current.Next; 
                }
            } while (current != head);

            if (found)
            {
                OurMessageBox.Show($"All nodes with ID {id} have been removed");
            }
            else
            {
                OurMessageBox.Show($"No nodes with ID {id} found");
            }
        }
        public void PrintList(ListBox listBox)
        {
            listBox.Items.Clear();
            if (IsEmpty())
            {
                listBox.Items.Add("List is empty");
                return;
            }

            Node current = head;
            do
            {
                listBox.Items.Add(current.Data);
                current = current.Next;
            } while (current != head);
        }
        public void RemoveFirst()
        {
            if (IsEmpty())
            {
                OurMessageBox.Show("List is empty");
                return;
            }

            if (head.Next == head)
            {
                head = null;
            }
            else
            {
                Node temp = head;
                while (temp.Next != head)
                {
                    temp = temp.Next;
                }
                temp.Next = head.Next;
                head = head.Next;
            }
        }

        public void RemoveLast()
        {
            if (IsEmpty())
            {
                OurMessageBox.Show("List is empty");
                return;
            }

            if (head.Next == head) 
            {
                head = null;
            }
            else
            {
                Node temp = head;
                while (temp.Next.Next != head)
                {
                    temp = temp.Next;
                }
                temp.Next = head;
            }
        }
        public Node Search(int id)
        {
            if (IsEmpty())
                return null;

            Node current = head;
            do
            {
                if (current.Data.ID == id)
                    return current;
                current = current.Next;
            } while (current != head);

            return null;
        }
    }
}
