using Infrastructure.Nswag;

namespace Infrastructure.Models.Plans.Response
{
    public class PlanServicesCreateModel
    {

        public long NumberRequests { get; set; } = 0L;


        public int Scope { get; set; } = 1;


        public string Processor { get; set; }


        public string ConnectionType { get; set; }


        public string ServiceId { get; set; }

    }
}
