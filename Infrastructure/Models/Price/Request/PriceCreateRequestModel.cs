namespace Infrastructure.Models.Price.Request
{
    public partial class PriceCreateRequestModel
    {
        public string ProductId { get; set; }
        public string Currency { get; set; }
        public long UnitAmount { get; set; }
        public string Interval { get; set; }
    }



}
