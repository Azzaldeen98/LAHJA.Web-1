namespace Domain.ShareData.Base.Plan
{
    public partial class BasePlanServicesUpdate
    {

        public long NumberRequests { get; set; }

        public int Scope { get; set; }

        public string Processor { get; set; }

        public string ConnectionType { get; set; }

        public string ServiceId { get; set; }

    }
}
