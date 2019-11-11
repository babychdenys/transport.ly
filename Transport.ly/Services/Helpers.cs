using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.ly.Objects;

namespace Transport.ly.Services
{
    public static class Helpers
    {
        //Main output method
        public static void OutputFlight(Flight flight, Order order = null)
        {
            Console.WriteLine( (order == null ? "" : $"order: {order.OrderNumber}, ") +//order number if present                
                (flight == null ? "flightNumber: not scheduled" : // flight, if avaliable for schedule
                $"flightNumber: {flight.Number.ToString()}, " +
                $"departure: {flight.From.ToString()}-{Airports.AirportDictionary[flight.From].City}, " +
                $"arrival: {flight.To.ToString()}-{Airports.AirportDictionary[flight.To].City}, " +
                $"day: {flight.Day.ToString()}."));
        }

        public static List<Order> LoadOrdersJson(string path)
        {
            List<Order> orders = new List<Order>();
            //Windows copying path defaults to wrapping it as "path"
            if(path[0].Equals('"'))
            {
                path = path.Substring(1);
            }
            if (path[path.Length-1].Equals('"'))
            {
                path = path.Substring(0, path.Length - 1);
            }
            try
            {

                using (StreamReader r = new StreamReader(path))
                {
                    string json = r.ReadToEnd();
                    Dictionary<string, Dictionary<string, string>> jlist = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(json);

                    foreach (var item in jlist)
                    {
                        string orderNumber = item.Key;
                        string destination = item.Value["destination"];
                        if(orderNumber != null && destination != null)
                        {                            
                            try
                            {
                                Order order = new Order(orderNumber, (AirportEnum)Enum.Parse(typeof(AirportEnum), destination, true));
                                orders.Add(order);
                            }
                            catch
                            {   //wrong order-# or Destination Airport
                                Console.WriteLine($"Error in building Order({orderNumber}:{destination}:not scheduled)");
                            }
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("Error during file read. Please, verify if file is accessible, content is formatted and the path is correct.\nStory Terminated.\n");
            }
            return orders;
        }
    }
}
