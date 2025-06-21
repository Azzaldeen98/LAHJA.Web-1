using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Profile
{
    public class ProfileRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Image { get; set; }
        public bool? Active { get; set; }
    }


    public  class ProfileModelAiResponse
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Token { get; set; }

        public string AbsolutePath { get; set; }

        public string Category { get; set; }

        public string Language { get; set; }

        public bool? IsStandard { get; set; }

        public string Gender { get; set; }

        public string Dialect { get; set; }

        public string Type { get; set; }


    }


    public class ProfileSubscriptionResponse
    {
        public string? Id { get; set; }
        public string? PlanId { get; set; }
        public string? CustomerId { get; set; }
        public string? BillingPeriod { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public string? Status { get; set; }
        public bool CancelAtPeriodEnd { get; set; }
    }

    public class ProfileServiceResponse
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? AbsolutePath { get; set; }
        public string? Token { get; set; }
        public string? ModelAiId { get; set; }
    }
    public class ProfileSpaceResponse
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Ram { get; set; }
        public int CpuCores { get; set; }
        public float DiskSpace { get; set; }
        public bool IsGpu { get; set; }
        public bool IsGlobal { get; set; }
        public float Bandwidth { get; set; }
    }

}
