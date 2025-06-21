using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models.Plans
{
    public class RegisterRequestModel
    {


        public string? FirstName { get; set; }


        public string? LastName { get; set; } 
        public string? FullName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }


        public string? ConfirmPassword { get; set; }


        public string? Avatar { get; set; } 


        public string? ReturnUrl { get; set; } = "https://asg.tryasp.net/swagger/index.html";

        public string? UserRole { get; set; }

    }


}
