using AutoGenerator.Attributes;
using AutoGenerator.Enums;
using Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    [AutomateMapperWith(LayersModels.DTO, "ResetPasswordRequest")]
    [AutomateMapperWith(LayersModels.VM, "ResetPasswordResponse", "DataBuildAuthBase")]
    public class ResetPassword : ITDso
    {

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PostalCode)]
        public string ResetCode { get; set; }

        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
    }

}
