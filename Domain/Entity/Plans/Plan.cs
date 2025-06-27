using AutoGenerator;
using AutoGenerator.Config.Attributes;
using AutoGenerator.Enums;
using Shared.Interfaces;

namespace Domain.Entity
{



    [AutoGenerate(GenerationTarget.Repository | GenerationTarget.UseCase | GenerationTarget.Service)]
    [SupportedMethods(SupportedMethods.GetById | SupportedMethods.GetAll | SupportedMethods.CountAll)]
    [AutomateMapper( SupportedMethods.GetById | SupportedMethods.CountAll,true)]
    //[MethodRoute(SupportedMethods.GetAll, "GetPlansAsync")]
    //[MethodRoute("GetPlansAsync", "GetPlansAsync")]
    [AutomateMapperWith(LayersModels.DTO, "PlanOutputVM", "PlanCreateVM" )]
    [AutomateMapperWith(LayersModels.VM, "PlanViewModel")]
   
    [HasTranslate]

    public class Plan:  ITDso
    {
        public string Id { get; set; }
        public string ProductId { get; set; }

        [MapTo(AutoGeneratorConstant.ModelType.DTO, "ProductName")]
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<string> Images { get; set; }
        public string BillingPeriod { get; set; }

        [MapTo(AutoGeneratorConstant.ModelType.VM, "TotalAmount")]
        public double Amount { get; set; }
  
        public bool Active { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public DateTimeOffset CreatedAt { get; set; }


        [MapTo(AutoGeneratorConstant.ModelType.VM, "Features")]
        public ICollection<PlanFeature> PlanFeatures { get; set; }

        public decimal? TotalBilling { get; set; } = 0;
        public string? Processor { get; set; }
        public string? ConnectionType { get; set; }
        public string? AbsolutePath { get; set; }
        public int? NumberRequests { get; set; }

        public decimal? MonthlyPrice { get; set; }
        public decimal? AnnualPrice { get; set; }
        public decimal? WeeklyPrice { get; set; }

    }

}
