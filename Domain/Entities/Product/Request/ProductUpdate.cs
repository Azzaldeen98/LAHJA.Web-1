namespace Domain.Entities.Product.Request
{
    public partial class ProductUpdate
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Images { get; set; }
        public bool? Shippable { get; set; }
        public string UnitLabel { get; set; }
    }
}
