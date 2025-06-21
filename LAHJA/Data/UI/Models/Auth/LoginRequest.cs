using Domain.ShareData.Base;
using Shared.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace LAHJA.Data.UI.Models.Auth
{
    public class LoginRequest : ITVM
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        public required string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(50)]
        public required string Password { get; set; }


        [DataType(DataType.PostalCode)]
        [MaxLength(50)]
        public string? TwoFactorCode { get; set; }

        [DataType(DataType.PostalCode)]
        [MaxLength(50)]
        public string? TwoFactorRecoveryCode { get; set; }


    }
}
