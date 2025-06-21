using Domain.ShareData.Base;

namespace Domain.Entities.Auth.Response
{

    public class LoginResponse: BaseAccessToken
    {


        public string? userId { get; set; }
   
        public string? email { get; set; }

        public string? name { get; set; }

  


    }


}
