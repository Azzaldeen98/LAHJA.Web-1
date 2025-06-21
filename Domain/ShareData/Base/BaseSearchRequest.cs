namespace Domain.ShareData.Base
{
    public partial class BaseSearchRequest
    {
        public string query { get; set; }
        public int limit { get; set; }
        public string page { get; set; }

    }
}
