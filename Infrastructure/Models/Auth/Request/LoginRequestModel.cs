using Domain.ShareData.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models.Plans
{

    public class LoginRequestModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        public required string? email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(50)]
        public required string password { get; set; }


        [DataType(DataType.PostalCode)]
        [MaxLength(50)]
        public string? twoFactorCode { get; set; } = "string";

        [DataType(DataType.PostalCode)]
        [MaxLength(50)]
        public string? twoFactorRecoveryCode { get; set; } = "string";


    }


}
