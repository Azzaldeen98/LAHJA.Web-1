using AutoGenerator.Attributes;
using AutoGenerator.Enums;
using Shared.Interfaces;

namespace Domain.Entity
{
    [AutomateMapperWith(LayersModels.DTO, "SpaceOutputVM", "SpaceCreateVM", "SpaceUpdateVM")]
    public partial class Space : ITDso
    {
        
    
    
    }
}
