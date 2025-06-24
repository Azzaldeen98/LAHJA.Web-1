using AutoGenerator.Config.Attributes;
using AutoGenerator.Enums;
using Shared.Interfaces;

namespace Domain.Entity
{

    [AutoGenerate(GenerationTarget.Repository | GenerationTarget.UseCase| GenerationTarget.Service)]
    [SupportedMethods(SupportedMethods.RRPC | SupportedMethods.GetOne | SupportedMethods.GetCurrent | SupportedMethods.GetAll)]
    [AutomateMapper(SupportedMethods.GetAll | SupportedMethods.GetOne | SupportedMethods.GetCurrent, true)]
    [MethodRoute(SupportedMethods.Pause, "PauseCollectionAsync")]
    [MethodRoute(SupportedMethods.Resume,"ResumeCollection2Async")]
    [MethodRoute(SupportedMethods.Cancel,"Cancel2Async")]
    public class Subscription: ITDso
    {

        public string? Id { get; set; }
        public string? UserId { get; set; }
        public string? PlanId { get; set; }
        public long? Nr { get; set; }
        public string? CustomerId { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public string? Status { get; set; }
        public string? BillingPeriod { get; set; }
        public DateTimeOffset? CancelAt { get; set; }
        public bool? CancelAtPeriodEnd { get; set; }

    }
}
