using System;

namespace FuberAppApi.Domain
{
    public class Cab
    {
        public int Id { get; set; }
        public Location Location { get; set; }
        public bool IsPinkCab { get; set; } = false;
        public bool IsCabHired { get; set; } = false;
        
    }
}
