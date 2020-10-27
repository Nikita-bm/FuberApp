using System.Linq;
using FuberAppApi.Domain.Exceptions;

namespace FuberAppApi.Domain
{
    public class CabService
    {
        public Cab AssignClosestAvailableCab(Customer customer)
        {
            // TODO: Test
            var cab = Db.Cabs
                     .Where(x => !x.IsCabHired && (x.IsPinkCab == customer.BookPinkCab || customer.BookPinkCab == null))
                     .OrderBy(x => Location.GetDistance(x.Location, customer.PickUpLocation)) // Something else? O(n) >
                     .FirstOrDefault();

            if (cab == null)
                throw new CabNotFoundException();

            cab.IsCabHired = true;
            cab.Location = customer.PickUpLocation;
            return cab;
        }

        public void EndRide(Cab cab, Customer customer)
        {
            UpdateCabLocation(cab, customer);

            var customerService = new CustomerService();
            customerService.RemoveCustomer(customer);
        }

        public void UpdateCabLocation(Cab cab, Customer customer)
        {
            var bookedCab = Db.Cabs.First(c => c.Id == cab.Id);
            bookedCab.IsCabHired = false;
            bookedCab.Location = customer.DropLocation;
        }
    }
}
