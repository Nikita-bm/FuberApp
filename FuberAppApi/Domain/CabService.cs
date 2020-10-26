using System.Linq;
using FuberAppApi.Domain.Exceptions;

namespace FuberAppApi.Domain
{
    public class CabService
    {
        public Cab AssignClosestAvailableCab(Customer customer) 
        {
            // TODO: Test
            var cab =  Db.Cabs
                     .Where(x => !x.IsCabHired && (x.IsPinkCab == customer.BookPinkCab || customer.BookPinkCab == null))
                     .OrderBy(x => Location.GetDistance(x.Location, customer.PickUp)) // Something else? O(n) >
                     .FirstOrDefault();

            if (cab == null)
            {
                throw new CabNotFoundException();
            }

            cab.IsCabHired = true;
            cab.Location = customer.PickUp;
            return cab;
        }

        public void UpdateCabLocation(Cab cab, Customer customer)
        {
            var bookedCab = Db.Cabs.FirstOrDefault(cab => cab.Id == cab.Id);
            bookedCab.IsCabHired = false;
            bookedCab.Location = customer.Drop;
        }
    }
}
