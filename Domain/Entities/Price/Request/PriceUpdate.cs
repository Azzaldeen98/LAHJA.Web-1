namespace Domain.Entities.Price.Request
{
    public partial class PriceUpdate
    {
        public bool Active { get; set; }
        public string LookupKey { get; set; }
    }

}
