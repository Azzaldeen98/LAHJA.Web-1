namespace Infrastructure.Models.Product.Request
{
    public partial class ProductUpdateModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
        public IEnumerable<string> Images { get; set; }
        public bool? Shippable { get; set; }
        public string UnitLabel { get; set; }
    }


}
