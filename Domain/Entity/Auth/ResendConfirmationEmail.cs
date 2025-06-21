using AutoGenerator.Config.Attributes;
using AutoGenerator.Enums;
using Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{
    [AutomateMapperWith(LayersModels.DTO, "ResendConfirmationEmailRequest")]
    [AutomateMapperWith(LayersModels.VM, "DataBuildAuthBase", "ResendConfirmationEmail")]
    public class ResendConfirmationEmail:ITDso
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Url)]
        public string ReturnUrl { get; set; } 
    }

}
