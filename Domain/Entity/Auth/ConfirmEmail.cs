using AutoGenerator;
using AutoGenerator.Config.Attributes;
using AutoGenerator.Enums;
using Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity
{

    
    [AutomateMapperWith(LayersModels.DTO, "ConfirmEmailRequest")]
    [AutomateMapperWith(LayersModels.VM, "DataBuildAuthBase", "ConfirmEmailRequest")]
    [MethodRoute("ConfirmationEmailAsync", "ConfirmEmailAsync")]


    public class ConfirmEmail : ITDso
    {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [DataType(DataType.PostalCode)]
        public string Code { get; set; }


        [DataType(DataType.EmailAddress)]
        public string ChangedEmail { get; set; }

        public bool IsChangedEmail { get; set; }

        [DataType(DataType.Url)]
        public string ReturnUrl { get; set; }

       

   
    }

}
