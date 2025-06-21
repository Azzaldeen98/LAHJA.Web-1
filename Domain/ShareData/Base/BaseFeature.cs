namespace Domain.ShareData.Base
{

    public class BaseFeature
    {
        public string? Id { get; set; }
        public string? ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool Active { get; set; } = false;
        public decimal? Price { get; set; } = 1;
        public bool IsFixed { get; set; } = true;
        public bool? IsPaid { get; set; } = true;

    }



}
