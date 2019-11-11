using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.ly.Objects
{
    public static class Airports
    {
        public static Dictionary<AirportEnum, Airport> AirportDictionary = new Dictionary<AirportEnum, Airport>()
            {
               { AirportEnum.YUL, new Airport() { Id = (int)AirportEnum.YUL, City = "Montreal" } },
               { AirportEnum.YYZ, new Airport() { Id = (int)AirportEnum.YYZ, City = "Toronto" } },
               { AirportEnum.YYC, new Airport() { Id = (int)AirportEnum.YYC, City = "Calgary" } },
               { AirportEnum.YVR, new Airport() { Id = (int)AirportEnum.YVR, City = "Vancouver" } }
            };      
    }

    public class Airport
    {
        public int Id { get; set; }
        public string City { get; set; }
    }

    public enum AirportEnum
    {
        YUL,
        YYZ,
        YYC,
        YVR
    }
}
