namespace FuberAppApi.Domain
{
    public class Customer
    {
        public int Id { get; set; }
        public Location PickUpLocation { get; set; }
        public Location DropLocation { get; set; }
        public bool? BookPinkCab { get; set; } = null;
    }
}
