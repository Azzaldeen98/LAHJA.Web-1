using AutoGenerator.Attributes;
using AutoGenerator.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    [AutomateMapperWith(LayersModels.DTO, "ForgotPasswordRequest")]
    [AutomateMapperWith(LayersModels.VM, "DataBuildAuthBase", "ForgotPasswordRequest")]
    public class ForgetPassword
    {
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [DataType(DataType.Url)]
        public string? ReturnUrl { get; set; }
    }
}
