using AutoGenerator.Attributes;
using AutoGenerator.Enums;
using Shared.Interfaces;

namespace Domain.Entity
{

    [AutomateMapperWith(LayersModels.DTO, "RequestOutputVM", "RequestCreateVM", "RequestUpdateVM")]
    public partial class Request : ITDso
    {
        public string Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public string Status { get; set; }

        public string ModelGateway { get; set; }
        public string ModelAi { get; set; }


        public DateTimeOffset UpdatedAt { get; set; }
        public DateTimeOffset CreatedAt { get; set; }

        public string UserId { get; set; }

       
        public User User { get; set; }

        
        public string SubscriptionId { get; set; }

        public Subscription Subscription { get; set; }

        
        public string ServiceId { get; set; }

        
        public Service Service { get; set; }

        
        public string SpaceId { get; set; }

        
        public Space Space { get; set; }

        //public ICollection<EventRequest> Events { get; set; }


    }
}
