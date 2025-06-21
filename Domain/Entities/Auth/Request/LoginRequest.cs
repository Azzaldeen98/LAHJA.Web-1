using Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Auth.Request
{
    public class LoginRequest
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
        public  string? TwoFactorCode { get; set; }

        [DataType(DataType.PostalCode)]
        [MaxLength(50)]
        public string? TwoFactorRecoveryCode { get; set; }


    }


}
