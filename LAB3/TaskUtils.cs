using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB3
{
    static class TaskUtils
    {
        /// <summary>
        /// Task1: Finds the total length of all routes in each city
        /// </summary>
        /// <param name="Data">Associative container (dictionary) of electronic devices</param>
        /// <returns>Dictionary (city,mylinkedlist) of city </returns>
        public static Dictionary<string, MyLinkedList> FindAllLongestBatteryLife
        (Dictionary<string, MyLinkedList> Data)
        {
            Dictionary<string, MyLinkedList> AllLongest =
            new Dictionary<string, MyLinkedList>();
            double total = 0.0;
            foreach (KeyValuePair<string, MyLinkedList> pair in Data)
            {
                string owner = pair.Key;
                //double Longest = pair.Value.TotalLength();
                MyLinkedList ED = new MyLinkedList();
                // Copy electronic devices with longest battery life
                for (pair.Value.Start(); pair.Value.Exists(); pair.Value.Next())
                {
                    Route ed = pair.Value.GetData();
                    total = total + ed.Length;
                }
                Route longest = new Route();
                longest.Length = total;
                ED.AddToFront(longest);
                if (!AllLongest.ContainsKey(owner))
                {
                    AllLongest.Add(owner, ED);
                }
                total = 0.0;
            }
            return AllLongest;
        }
        /// <summary>
        /// Task1: Finds all the routes based on the filter criteria
        /// </summary>
        /// <param name="Data">Associative container (dictionary) of route</param>
        /// <returns>Dictionary (city, MyLinkedList) of routes </returns>
        public static MyLinkedList Task2
        (Dictionary<string, MyLinkedList> Data,double a,double b)
        {
            MyLinkedList AllLongest = new MyLinkedList();
            foreach (KeyValuePair<string, MyLinkedList> pair in Data)
            {
                
                // Copy electronic devices with longest battery life
                for (pair.Value.Start(); pair.Value.Exists(); pair.Value.Next())
                {
                    Route ed = pair.Value.GetData();
                    // Find all devices with maximum battery life
                    if (ed.Length>=a && ed.Length<=b)
                    {
                        if (!AllLongest.Contains(ed))
                            AllLongest.AddToEnd(ed);
                    }
                }
                
            }
            return AllLongest;
        }
        /// <summary>
        /// creates a new container based on enter value of D by user and the value must be greater than 60 minutes
        /// </summary>
        /// <param name="Data">initial data</param>
        /// <param name="D">entered value by user</param>
        /// <returns>returns a new linkedlist of the filtered routes from data</returns>
        public static MyLinkedList Task4(MyLinkedList Data,double D)
        {
            MyLinkedList newcontainer = new MyLinkedList();
            for(Data.Start();Data.Exists();Data.Next())
            {
                Route r = Data.GetData();
                TimeSpan start1 = r.start;
                TimeSpan end1 = r.end;
                TimeSpan duration1 = (end1 - start1);
                double totalminutes = duration1.TotalMinutes;
                if(totalminutes>D)
                    newcontainer.AddToEnd(r);

            }
            return newcontainer;  
        }

    }
}
