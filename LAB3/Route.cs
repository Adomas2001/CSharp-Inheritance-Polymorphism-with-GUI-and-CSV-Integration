using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB3
{
    public class Route
    {
        // Auto-properties
        public int RouteNumber { get; set; }
        public string RouteName { get; set; }
        public double Length { get; set; }
        public int stops { get; set; }
        public TimeSpan start { get; set; }
        public TimeSpan end { get; set; }


        /// <summary>
        /// Default constructor (no parameters)
        /// </summary>
        public Route() { }
        /// <summary>
        /// Constructor with parameteres
        /// </summary>
        /// <param name="model">New value for model of electronic device</param>
        /// <param name="type">New value for type of electronic device</param>
        /// <param name="batteryLife">New value for battery life of electronic device</param>
        public Route(int number, string name1, double length, int stops, TimeSpan start, TimeSpan end)
        {
            this.RouteNumber = number;
            this.RouteName = name1;
            this.Length = length;
            this.stops = stops;
            this.start = start;
            this.end = end;
        }
        /// <summary>
        /// Method for creating a string output from class properties (data fields)
        /// </summary>
        /// <returns>all the properties as a single string</returns>
        public override string ToString()
        {
            return string.Format("{0,-8:d} {1,-20} {2,-10:f2} {3,-10:d} {4,-15} {5,-15} ",
            RouteNumber, RouteName, Length, stops, start, end);
        }
        /// <summary>
        /// Equality check method for two routes
        /// </summary>
        /// <param name="myObject">Object of route to be matched with </param>
        /// <returns>True if all the properties of one route
        /// match the other properties of another rroute</returns>
        public override bool Equals(object myObject)
        {
            Route electronicDevice = myObject as Route;
            return electronicDevice.RouteName == RouteName &&
            electronicDevice.RouteNumber == RouteNumber &&
           electronicDevice.Length == Length &&
           electronicDevice.stops == stops &&
           electronicDevice.start == start &&
           electronicDevice.end == end;
        }
        /// <summary>
        /// Reccommended method to override: GetHashCode
        /// </summary>
        /// <returns>Hash code  </returns>
        public override int GetHashCode()
        {
            return RouteName.GetHashCode() ^
            RouteNumber.GetHashCode() ^
           Length.GetHashCode() ^
           stops.GetHashCode() ^
           start.GetHashCode() ^
           end.GetHashCode();
        }
        /// <summary>
        /// Overloaded operator >= 
        /// </summary>
        /// <param name="first">First route</param>
        /// <param name="second">Second route</param>
        /// <returns>True or false</returns>
        public static bool operator >=(Route first, Route second)
        {
            int poz = TimeSpan.Compare(first.start, second.start);
            return first.stops < second.stops ||
            first.stops == second.stops && poz < 0;
        }
        /// <summary>
        /// Overloaded operator <= 
        /// </summary>
        /// <param name="first">First route</param>
        /// <param name="second">Second route</param>
        /// <returns>True or false</returns>
        public static bool operator <=(Route first, Route second)
        {
            int poz = TimeSpan.Compare(first.start, second.start);
            return first.stops < second.stops ||
            first.stops == second.stops && poz < 0;
        }
        /// <summary>
        /// Overloaded operator == 
        /// </summary>
        /// <param name="first">First route</param>
        /// <param name="second">Second route</param>
        /// <returns>True or false</returns>
        public static bool operator ==(Route first, Route second)
        {
            return first.RouteNumber == second.RouteNumber;
        }
        /// <summary>
        /// Overloaded operator != 
        /// </summary>
        /// <param name="first">First route</param>
        /// <param name="second">Second route</param>
        /// <returns>True opr false</returns>
        public static bool operator !=(Route first, Route second)
        {
            return first.RouteNumber != second.RouteNumber;
        }
        /// <summary>
        /// Overloaded operator > 
        /// </summary>
        /// <param name="first">First route</param>
        /// <param name="second">Second route</param>
        /// <returns>True or false</returns>
        public static bool operator >(Route first, Route second)
        {
            return first.Length > second.Length;
        }
        /// <summary>
        /// Overloaded operator < 
        /// </summary>
        /// <param name="first">First route</param>
        /// <param name="second">Second route</param>
        /// <returns>true or false</returns>
        public static bool operator <(Route first, Route second)
        {
            return first.Length < second.Length;
        }
    }
}
