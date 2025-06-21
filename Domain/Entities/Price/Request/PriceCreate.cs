namespace Domain.Entities.Price.Request
{
    public partial class PriceCreate
    {
        public string ProductId { get; set; }
        public string Currency { get; set; }
        public long UnitAmount { get; set; }
        public string Interval { get; set; }
    }


}
