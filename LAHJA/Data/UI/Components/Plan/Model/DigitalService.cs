namespace LAHJA.Data.UI.Components.Plan
{
    public class DigitalService
    {
        public string ServiceType { get; set; }
        public string Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice;
    }
}
