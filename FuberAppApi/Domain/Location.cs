using System;

namespace FuberAppApi.Domain
{
    // TODO: Breaks encapsulation - getters and setters
    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        // TODO: Test
        public static double GetDistance(Location point1 , Location point2)
        {
            return Math.Sqrt(Math.Pow(point2.Latitude - point1.Latitude, 2) + Math.Pow(point2.Longitude - point1.Longitude, 2));
        }
    }
}
