using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB3
{
    public sealed class MyLinkedList
    {
        /// <summary>
        /// Nested class for node of linked list
        /// </summary>
        private sealed class MyNode
        {
            public Route Data { get; set; }
            public MyNode Next { get; set; }
            public MyNode() { }
            public MyNode(Route data, MyNode address)
            {
                this.Data = data;
                this.Next = address;
            }
        }
        private MyNode head; // start address
        private MyNode tail; // end address
        private MyNode iP; // pointer for interface
                           // Constructor: initialization of pointer values
        public MyLinkedList()
        {
            this.head = null;
            this.tail = null;
            this.iP = null;
        }
        /// <summary>
        /// Gets data of electronic device
        /// </summary>
        /// <returns>Data of first element in linked list</returns>
        public Route First() { return head.Data; }
        /// <summary>
        /// Gets data of route
        /// </summary>
        /// <returns>Data of last element in linked list</returns>
        public Route Last() { return tail.Data; }
        /// <summary>
        /// Gets number of elements in linked list (0 if no elements)
        /// Expanded get access modifier
        /// </summary>
        public int Count
        {
            get
            {
                if (head == null)
                    return 0;
                int k = 0;
                for (MyNode dd = head; dd != null; dd = dd.Next)
                    k++;
                return k;
            }
        }
        /// <summary>
        /// Adds new element (node) to front of linked list
        /// </summary>
        /// <param name="ED">Data of single route</param>
        public void AddToFront(Route ED)
        {
            var p = new MyNode(ED, null);
            p.Next = head;
            head = p;
            // or
            //head = new MyNode(student, p);
        }
        /// <summary>
        /// Adds new element (node) to end of linked list
        /// </summary>
        /// <param name="ED">Data of single route</param>
        public void AddToEnd(Route ED)
        {
            var p = new MyNode(ED, null);
            if (head != null)
            {
                tail.Next = p;
                tail = p;
            }
            else // if linked list is empty
            {
                head = p;
                tail = p;
            }
        }
        /// <summary>
        /// Deletes nodes in entire linked list
        /// </summary>
        public void Destroy()
        {
            while (head != null)
            {
                iP = head;
                head = head.Next;
                iP.Next = null;
            }
            tail = iP = head; // tail = iP = null;
        }
        /// <summary>
        /// Sets interface pointer (IP) to head
        /// </summary>
        public void Start() { iP = head; }
        /// <summary>
        /// Moves interface pointer (IP) to next node
        /// </summary>
        public void Next() { iP = iP.Next; }
        /// <summary>
        /// Checks if interface pointer (IP) is valid
        /// </summary>
        /// <returns>True if IP points to valid object; null otherwise</returns>
        public bool Exists() { return iP != null; }
        /// <summary>
        /// Searches if an element is found in container
        /// </summary>
        /// <param name="myEd">Searched route</param>
        /// <returns>True, if searched route is found, false otherwise</returns>
        public bool Contains(Route myEd)
        {
            for (MyNode p = head; p != null; p = p.Next)
            {
                Route ed = p.Data;
                if (ed.Equals(myEd))
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Get data of element in linked list
        /// </summary>
        /// <returns>Data of electronic device (referenced by interface pointer)</returns>
        public Route GetData() { return iP.Data; }

        /// <summary>
        /// Sort data of linked list
        /// Algorithm: selection sort
        /// </summary>
        public void Sort()
        {
            for (MyNode s1 = head; s1 != null; s1 = s1.Next)
            {
                // Search for maxmimum value in range
                MyNode maxv = s1;
                for (MyNode s2 = s1; s2 != null; s2 = s2.Next)
                    if (s2.Data >= maxv.Data)
                        maxv = s2;
                //Swap of values (exchanging data parts)
                Route s = s1.Data;
                s1.Data = maxv.Data;
                maxv.Data = s;
            }
        }
        /// <summary>
        /// Removes elements from linked list with value W entered by user
        /// </summary>
        /// <param name="ABL">value of the string entered by the user</param>
        public void RemoveALL(string ABL)
        {
            for (MyNode s1 = head; s1 != null; s1 = s1.Next)
            {
                if (s1.Data.RouteName.Contains(ABL))
                {
                    // Store head node
                    MyNode temp = head, previous = null;
                    // If head node itself holds the value to be deleted
                    if (temp != null && temp.Data.RouteName.Contains(ABL))
                    {
                        head = temp.Next; // Changed head
                        return;
                    }
                    // Search for the value to be deleted, keep track of the
                    // previous node as we need to change temp.next
                    while (temp != null && !temp.Data.RouteName.Contains(ABL))
                    {
                        previous = temp;
                        temp = temp.Next;
                    }
                    // If value was not present in linked list
                    if (temp == null) return;
                    // Unlink the node from linked list
                    previous.Next = temp.Next;
                }
            }
        }

    }
}
