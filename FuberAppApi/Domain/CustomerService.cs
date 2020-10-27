using System.Linq;

namespace FuberAppApi.Domain
{
    public class CustomerService
    {
        public Customer RegisterCustomer(Customer customer)
        {
            Customer newCustomer = new Customer()
            {
                Id = Db.customers.Count + 1,
                DropLocation = customer.DropLocation,
                PickUpLocation = customer.PickUpLocation
            };

            Db.customers.Add(newCustomer);

            return newCustomer;
        }

        public void RemoveCustomer(Customer customer)
        {
            var registredcustomer = Db.customers.FirstOrDefault(cust => cust.Id == customer.Id);
            Db.customers.Remove(registredcustomer);
        }
    }
}
