using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ShareData
{
    public interface ISessionUserManager
    {

         Task<string> GetEmailAsync();
         Task StoreEmailAsync(string email);
       
    }
}
