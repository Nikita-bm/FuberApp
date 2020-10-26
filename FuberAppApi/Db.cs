using System.Collections.Generic;
using FuberApps.Domain;

namespace FuberAppApi
{
    public class Db
    {
        public static List<Cab> Cabs = new List<Cab>
        {
            new Cab {Id=1, Location = new Location {Latitude=1, Longitude=2}},
            new Cab {Id=2, Location = new Location {Latitude=2, Longitude=4}},
            new Cab {Id=3, Location = new Location {Latitude=3, Longitude=6}},
            new Cab {Id=4, Location = new Location {Latitude=4, Longitude=8}}
        };

        public static List<Customer> customers = new List<Customer>
        {
            new Customer {Id=1},
            new Customer {Id=2},
            new Customer {Id=3},
            new Customer {Id=4},
            new Customer {Id=5},
        };
    }
}
