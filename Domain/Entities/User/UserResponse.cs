using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.User
{
    public class UserResponse
    {

        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public bool active { get; set; }
        public string phoneNumber { get; set; }
    }
}
