namespace CardShopping.Web.VitsModel.Subscriptions
{
    public class InputSubscription
    {
        public string Id { get; set; }
        public string IdUser { get; set; }
        public string Name { get; set; }
        public string Typeplan { get; set; }
        public string Idplan { get; set; }
        public string Nameplan { get; set; }
        public int RemainiingRequest { get; set; }
        public DateTimeOffset SubscrptionDate { get; set; }
        public DateTimeOffset ExpirationDate { get; set; }
    }
}
