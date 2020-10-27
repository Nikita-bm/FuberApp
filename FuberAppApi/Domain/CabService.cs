using System;
using System.Linq;
using FuberAppApi.Domain.Exceptions;

namespace FuberAppApi.Domain
{
    public class CabService
    {
        public Ride AssignClosestAvailableCab(Customer customer)
        {
            // TODO: Test

            var registeredCustomer = Db.Customers.First(c => c.Id == customer.Id);

            var cab = FetchNearestCab(registeredCustomer);

            if (cab == null)
                throw new CabNotFoundException();

            cab.IsCabHired = true;
            cab.Location = customer.PickUpLocation;

            Ride ride = new Ride()
            {
                Id = Db.Rides.Count + 1,
                Customer = registeredCustomer,
                Cab = cab,
                RideStartTime = DateTime.UtcNow,
            };

            Db.Rides.Add(ride);

           return ride;
        }


       
        public string EndRide(Ride ride)
        {
            var currentRide = Db.Rides.First(x => x.Id == ride.Id);

            UpdateCabLocation(currentRide);
            UpdateRideDetails(currentRide);

            return "The estimated fare is : Dogecoin " + currentRide.EstimatedFare.ToString();
        }

        public void UpdateCabLocation(Ride ride)
        {
            var bookedCab = Db.Cabs.First(c => c.Id == ride.Cab.Id);
            bookedCab.IsCabHired = false;
            bookedCab.Location = ride.Customer.DropLocation;

        }

        public void UpdateRideDetails(Ride ride)
        {
            ride.HasRideEnded = true;
            ride.RideEndTime = DateTime.UtcNow;
            ride.EstimatedFare = CalculateRideFare(ride);
        }

        public double CalculateRideFare(Ride ride )
        {
            var bookedCab = Db.Cabs.First(c => c.Id == ride.Cab.Id);
            var registeredCustomer = Db.Customers.First(c => c.Id == ride.Customer.Id);

            var timeforCommute = (ride.RideEndTime - ride.RideStartTime).TotalMinutes; // To do :Convert ot whole Numbers
            var kmsCovered = Location.GetDistance(registeredCustomer.PickUpLocation, registeredCustomer.DropLocation);

            var estimatedFare = (timeforCommute * 1) + (kmsCovered * 2);
            if(bookedCab.IsPinkCab)
            {
                estimatedFare += 5;
            }

            return estimatedFare;


        }

        private Cab FetchNearestCab(Customer customer)
        {
            var availableCabs =
                       Db.Cabs
                       .Where(x => !x.IsCabHired && (x.IsPinkCab == customer.BookPinkCab || customer.BookPinkCab == null));


            var shortestDistance = double.MaxValue;
            var cab = (Cab)null;
            foreach (var availableCab in availableCabs)
            {
                var distance = Location.GetDistance(availableCab.Location, customer.PickUpLocation);
                if (distance < shortestDistance)
                {
                    shortestDistance = distance;
                    cab = availableCab;
                }
            }
            return cab;
        }
    }
}
