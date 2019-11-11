using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.ly.Objects;

namespace Transport.ly.Services
{
    public static class StoryService
    {
        //Existing Stories
        public static Dictionary<int, Action> Stories = new Dictionary<int, Action>()
        {
            { 1, UserStory1 },
            { 2, UserStory2 }
        };

        //Usually it would come from a database, worst case file, but the task hasn't stated the requirement
        private static List<Flight> flights = new List<Flight>()
            {
                new Flight(AirportEnum.YUL, AirportEnum.YYZ, 1),
                new Flight(AirportEnum.YUL, AirportEnum.YYC, 1),
                new Flight(AirportEnum.YUL, AirportEnum.YVR, 1),
                new Flight(0, 1, 2),
                new Flight(0, 2, 2),
                new Flight(0, 3, 2)
            };

        //Typing flights out
        public static void UserStory1()
        {

            Console.WriteLine("\nUser Story #1\n");

            foreach(Flight f in flights)
            {
                Helpers.OutputFlight(f);
            }

            Console.WriteLine("\n");
        }

        public static void UserStory2()
        {            

            Console.WriteLine("\nUser Story #2\n");

            Console.WriteLine("Please enter a file path with orders(format \"drive:\\path\\name.json)\"");
            string path = Console.ReadLine();
            List<Order> orders = Helpers.LoadOrdersJson(path);
            if (orders != null && orders.Count() > 0)
            {
                for(int i = 0; i<orders.Count; i++)
                {
                    //Check if flight has space, add order to it for tracking and possible future use
                    Flight flight = flights.FirstOrDefault(f => f.To == orders[i].To && f.HasSpace());
                    if(flight != null)
                    {
                        flight.Orders.Add(orders[i]);
                        Helpers.OutputFlight(flight, orders[i]);
                    }
                    else
                    {
                        Helpers.OutputFlight(null, orders[i]);//if there was no flights avaliable with empty space/proper destination
                    }
                }
            }
            else
            {
                Console.WriteLine("Order list is empty.");
            }

            Console.WriteLine("\n");
        }
    }
}
