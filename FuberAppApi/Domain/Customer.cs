namespace FuberAppApi.Domain
{
    public class Customer
    {
        public int Id { get; set; }
        public Location PickUp { get; set; }
        public Location Drop { get; set; }
        public bool? BookPinkCab { get; set; } = null;
    }
}
