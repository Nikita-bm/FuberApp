namespace FuberApps.Model
{
    public class FuberService
    {
        public Car Car { get; set; }
        public Customer Customer { get; set; }

        public FuberService(Car car,Customer customer)
        {
            Car = car;
            Customer = customer;
        }
    }
}
