using Domain.Entities.AuthorizationSession;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models.User
{


    public class UserModel
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public bool? Active { get; set; }
        public string? Image { get; set; }
        public string? PhoneNumber { get; set; }
    }
    
}
