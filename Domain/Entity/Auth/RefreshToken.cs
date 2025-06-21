using AutoGenerator;
using AutoGenerator.Config.Attributes;
using AutoGenerator.Enums;
using Shared.Interfaces;

namespace Domain.Entity
{
    [AutomateMapperWith(LayersModels.DTO, "RefreshTokenRequest")]
    [AutomateMapperWith(LayersModels.VM, "DataBuildAuthBase", "RefreshTokenRequest")]
    public class RefreshToken : ITDso
    {
        [MapTo(AutoGeneratorConstant.ModelType.DTO, "RefreshToken")]
        [MapTo(AutoGeneratorConstant.ModelType.VM, "RefreshToken")]
        public string Token { get; set; }
    }

}
