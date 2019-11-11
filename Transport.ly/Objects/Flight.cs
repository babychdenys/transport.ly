using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.ly.Objects
{
    public class Flight
    {
        private static int _FlightNumber = 0;

        public int Number { get; }
        public AirportEnum From { get; set; }
        public AirportEnum To { get; set; }
        public int Day { get; set; }

        //Capacity and orders that take that space
        private int Capacity = 20;
        public List<Order> Orders { get; } = new List<Order>();
        
        public Flight()
        {
            Number = ++_FlightNumber;//Auto-increment
        }

        public Flight(AirportEnum from, AirportEnum to, int day) : this()
        {
            try
            {
                From = from;
                To = to;
                Day = day;
            }
            catch
            {
                //implement when needed
            }
        }

        public Flight(int from, int to, int day) : this((AirportEnum)from, (AirportEnum)to, day) { }

        public bool HasSpace()
        {
            return Orders.Count < Capacity; //Count if we have enough capacity
        }
    }
}
