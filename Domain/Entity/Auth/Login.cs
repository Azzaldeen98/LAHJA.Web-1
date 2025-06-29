using AutoGenerator.Attributes;
using AutoGenerator.Enums;
using Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{

    [AutomateMapperWith(LayersModels.DTO, "LoginRequest")]
    [AutomateMapperWith(LayersModels.VM, "DataBuildAuthBase", "LoginRequest")]
    public class Login : ITDso
    {

        [DataType(DataType.EmailAddress)]
        public required string Email { get; set; }
   
        [DataType(DataType.Password)]
        public required string Password { get; set; }

    }

}
