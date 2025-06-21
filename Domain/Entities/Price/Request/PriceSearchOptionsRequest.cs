namespace Domain.Entities.Price.Request
{
    public partial class PriceSearchOptionsRequest
    {
        public IEnumerable<string> Expand { get; set; }
        public IDictionary<string, object> ExtraParams { get; set; }
        public long? Limit { get; set; }
        public string Page { get; set; }
        public string Query { get; set; }
    }

}
