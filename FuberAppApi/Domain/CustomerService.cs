
namespace FuberAppApi.Domain
{
    public class CustomerService
    {
        public Customer RegisterCustomer(Customer customer)
        {
            Customer newCustomer = new Customer()
            {
                Id = Db.customers.Count + 1,
                Drop = customer.Drop,
                PickUp = customer.PickUp
            };

            Db.customers.Add(newCustomer);

            return newCustomer;

        }

        public void RemoveCustomer(Customer customer)
        {
            Db.customers.Remove(customer);
        }
}
}
