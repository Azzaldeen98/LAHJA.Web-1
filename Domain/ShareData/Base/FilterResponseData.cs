namespace Domain.ShareData.Base
{
    public class FilterResponseData:BaseEntity
    {
        public string StartingAfter { get; set; }
        public string EndingBefore { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public int Limit { get; set; }
    }
}
