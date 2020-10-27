using System;

namespace FuberAppApi.Domain
{
    public class Ride
    {

        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Cab Cab { get; set; }
        public DateTime RideStartTime { get; set; }
        public DateTime RideEndTime { get; set; }
        public double EstimatedFare { get; set; }
        public bool HasRideEnded { get; set; }
    }
}
