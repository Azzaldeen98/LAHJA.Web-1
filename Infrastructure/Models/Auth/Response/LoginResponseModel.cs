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
    public class LoginResponseModel: BaseAccessToken
    {

        public string? userId { get; set; }
   
        public string? email { get; set; }

        public string? name { get; set; }

        public string? token { get; set; }


    }


}
