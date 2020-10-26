﻿using System;

namespace FuberAppApi.Domain
{
    public class Location
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public static double GetDistance(Location point1 , Location point2)
        {
            return Math.Sqrt(Math.Pow(point2.Latitude - point1.Latitude, 2) + Math.Pow(point2.Longitude - point1.Longitude, 2));
        }
    }
}
