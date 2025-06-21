using AutoGenerator;
using AutoGenerator.Config.Attributes;
using AutoGenerator.Enums;
using Shared.Interfaces;

namespace Domain.Entity
{

    [AutomateMapperWith(LayersModels.DTO, "PlanFeatureCreateVM", "PlanFeatureFilterVM", "PlanFeatureInfoVM", "PlanFeatureOutputVM", "PlanFeatureUpdateVM")]
    [AutomateMapperWith(LayersModels.VM, "PlanFeatureViewModel")]
    [HasTranslate]
    public partial class PlanFeature : ITDso
    {

        public int Id { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [MapTo(AutoGeneratorConstant.ModelType.VM, "ProductId")]
        public string PlanId { get; set; }
        public decimal Amount { get; set; } = 0;
        public int? NumberRequests { get; set; }
        public string? Processor { get; set; }


    }
}
