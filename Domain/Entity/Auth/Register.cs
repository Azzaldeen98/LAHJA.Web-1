using AutoGenerator;
using AutoGenerator.Config.Attributes;
using AutoGenerator.Enums;
using Shared.Interfaces;

namespace Domain.Entity
{

    [AutomateMapperWith(LayersModels.DTO, "RegisterRequest")]
    [AutomateMapperWith(LayersModels.VM, "DataBuildAuthBase", "RegisterRequest")]
    public class Register:ITDso
    {
        [MapTo(AutoGeneratorConstant.ModelType.DTO, "FirsName")]
       
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? ConfirmPassword { get; set; }

        [MapTo(AutoGeneratorConstant.ModelType.VM, "Picture")]
        public string? Avatar { get; set; } = "";

        public string? ReturnUrl { get; set; } 

        public string? UserRole { get; set; } = "";

    }
}
