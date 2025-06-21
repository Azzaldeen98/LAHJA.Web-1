namespace Infrastructure.Models.Product.Response
{
    public partial class ProductResponseModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Object { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
        public bool? Deleted { get; set; }
        public IEnumerable<string> Images { get; set; }
        public bool? Shippable { get; set; }
        public string Type { get; set; }
        public string UnitLabel { get; set; }
        public string Url { get; set; }
    }


}
