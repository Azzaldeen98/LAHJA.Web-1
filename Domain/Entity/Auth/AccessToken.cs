using AutoGenerator;
using AutoGenerator.Attributes;
using AutoGenerator.Enums;
using Shared.Interfaces;

namespace Domain.Entity
{

        
    [AutomateMapperWith(LayersModels.DTO, "AccessTokenResponse")]
    [AutomateMapperWith(LayersModels.VM, "AccessTokenResponse")]
    public class AccessToken : ITDso
    {
        public string? TokenType { get; set; }

        [MapTo(AutoGeneratorConstant.ModelType.DTO, "AccessToken")]
        [MapTo(AutoGeneratorConstant.ModelType.VM, "AccessToken")]
        public string? Token { get; set; }
        public string? ExpiresIn { get; set; }
        public string? RefreshToken { get; set; }
    }

}
