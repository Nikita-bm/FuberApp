using System.Linq;

namespace FuberAppApi.Domain
{
    public class CabService
    {
        public Cab AssignClosestAvailableCab(Customer customer) 
        {
            var cab =  Db.Cabs
                     .Where(x => x.IsCabHired && (x.IsPinkCab == customer.BookPinkCab || customer.BookPinkCab == null))
                     .OrderBy(x => Location.GetDistance(x.Location, customer.PickUp))
                     .FirstOrDefault();
            if (cab != null)
            {
                cab.IsCabHired = true;
                cab.Location = customer.PickUp;
                //TO DO: Cab location updted to customer location - Needed??
                return cab;
            }

            return null;

        }

        public void UpdateCabLocation(Cab cab, Customer customer)
        {
            cab.IsCabHired = false;
            cab.Location = customer.Drop;
        }
    }
}
