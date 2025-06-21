namespace Infrastructure.Models.Price.Request
{
    public partial class PriceUpdateRequestModel
    {
        public string Id { get; set; }
        public bool Active { get; set; }
        public string LookupKey { get; set; }
    }



}
