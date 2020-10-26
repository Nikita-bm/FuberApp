namespace FuberApps.Model
{
    public class CustomerService
    {
        public Car Car { get; set; }
        public Customer Customer { get; set; }

        public CustomerService(Car car,Customer customer)
        {
            Car = car;
            Customer = customer;
        }
    }
}
