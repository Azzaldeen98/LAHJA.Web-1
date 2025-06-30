using AutoGenerator.Attributes;

using AutoGenerator.Enums;
using Shared.Interfaces;

namespace Domain.Entity
{

    public static class RouteProviderSubscription
    {
        public static readonly (SupportedMethods Method, string Target, string[] CustomParams)[] Routes = new[]
        {
            (SupportedMethods.Pause, "PauseCollectionAsync", new[] { "Subscription model" }),
            (SupportedMethods.Pause, "PauseCollectionAsync", Array.Empty<string>()),
            (SupportedMethods.Resume, "ResumeCollectionAsync", Array.Empty<string>()),
            (SupportedMethods.Cancel, "CancelAtEndAsync", Array.Empty<string>()),
            (SupportedMethods.GetCurrent, "GetMySubscriptionAsync", Array.Empty<string>())
        };

    }


    [AutoGenerate(GenerationTarget.Repository | GenerationTarget.UseCase| GenerationTarget.Service)]
    [SupportedMethods(SupportedMethods.RRPC | SupportedMethods.GetOne | SupportedMethods.GetCurrent | SupportedMethods.GetAll)]
    [AutoMapper(SupportedMethods.GetAll | SupportedMethods.GetOne | SupportedMethods.GetCurrent, true)]
    [MethodRoute(SupportedMethods.Pause, "PauseCollectionAsync", "Subscription model")]
    [MethodRoute(SupportedMethods.Resume, "ResumeCollectionAsync")]
    [MethodRoute(SupportedMethods.Renew, "RenewSubscriptionAsync")]
    [MethodRoute(SupportedMethods.Cancel, "CancelAtEndAsync")]
    //[MethodRoute("GetSubscriptionAsync", "GetMySubscriptionAsync")]
    [MethodRoute(SupportedMethods.GetCurrent, "GetMySubscriptionAsync")]
    //[MethodRouteProvider(typeof(RouteProviderSubscription))]
    [AutomateMapperWith(LayersModels.DTO, "SubscriptionOutputVM", "SubscriptionUpdateRequest", "SubscriptionResumeRequest")]
    [AutomateMapperWith(LayersModels.VM, "DataBuildUserSubscriptionInfo")]
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
        public string? ProrationBehavior { get; set; }
        public DateTimeOffset? CancelAt { get; set; }
        public bool? CancelAtPeriodEnd { get; set; }



    }
}
