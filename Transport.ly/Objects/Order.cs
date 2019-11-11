using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.ly.Objects
{
    public class Order
    {
        public string OrderNumber { get; set; }
        public AirportEnum From { get; }
        public AirportEnum To { get; set; }

        public Order()
        {
            From = AirportEnum.YUL;//All orders originate in Montreal
        }

        public Order(string orderNumber, AirportEnum to) : this()
        {
            OrderNumber = orderNumber;
            To = to;
        }

        public Order(string orderNumber, int to) : this(orderNumber, (AirportEnum)to) { }
    }
}
