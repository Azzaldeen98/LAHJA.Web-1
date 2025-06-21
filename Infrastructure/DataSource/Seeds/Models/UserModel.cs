using Infrastructure.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataSource.Seeds.Models
{
    public class UserApp: UserModel
    {
        public  string password { get; set; }
   
    }
}
