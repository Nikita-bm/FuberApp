using System.Linq;

namespace FuberAppApi.Domain
{
    public class CustomerService
    {
        public Customer RegisterCustomer(Customer customer)
        {
            Customer newCustomer = new Customer()
            {
                Id = Db.Customers.Count + 1,
                DropLocation = customer.DropLocation,
                PickUpLocation = customer.PickUpLocation
            };

            Db.Customers.Add(newCustomer);

            return newCustomer;
        }

        public void RemoveCustomer(Customer customer)
        {
            var registredcustomer = Db.Customers.FirstOrDefault(cust => cust.Id == customer.Id);
            Db.Customers.Remove(registredcustomer);
        }
    }
}
