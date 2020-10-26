using System.Collections.Generic;

namespace FuberApps.Model
{
    public class Cars
    {
        public List<Car> CarsList { get; set; }


        public void InitializeCars()
        {
            CarsList = new List<Car>()
            {
                    new Car()
                    {
                        Id = 1,
                        Location = new Location()
                        {
                            Latitude = 11.78,
                            Longitude = 12
                        }
                    },
                    new Car()
                    {
                          Id = 2,
                        Location = new Location()
                        {
                            Latitude = 1,
                            Longitude = 2
                        }
                    }
            };
        }

    }
}
