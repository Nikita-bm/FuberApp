namespace FuberApps.Domain
{
    public class CustomerService
    {
        public Cab Cab { get; set; }
        public Customer Customer { get; set; }

        public CustomerService(Cab Cab,Customer customer)
        {
            Cab = Cab;
            Customer = customer;
        }
    }
}
