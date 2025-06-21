using AutoMapper;
using Infrastructure.DataSource.Seeds.Models;
using Infrastructure.Models.Plans;
using Infrastructure.Models.User;

namespace Infrastructure.DataSource.Seeds
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json.Serialization;


    public class SeedsUsers
    {

        public List<UserApp>  Db { get=> db;}

        private static List<UserApp> db=new List<UserApp>() {
        
            new UserApp{ Id="12345",Name="Test User",Email="test@gmail.com",password="Test@123",PhoneNumber="771211417",Active=true,Image="" },
            new UserApp{ Id="1345678",Name="User",Email="user@gmail.com",password="Test@2025",PhoneNumber="781211417",Active=true,Image="" },
            new UserApp{ Id="1345678",Name="azzaldeen",Email="azzaldeen771211417@gmail.com",password="Test@123",PhoneNumber="781211417",Active=true,Image="" },
        
        };

        private readonly IMapper _mapper;

        public SeedsUsers(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<UserModel?> loginAsync(LoginRequestModel model)
        {

            if (db != null )
            {
                var user=db.FirstOrDefault(x => x.Email == model.email && x.password == model.password);
               if(user != null) 
                 return user;
            }
      
            return null;

        }
        public async Task<bool> createUserAsync(UserApp model) {

            if (db != null && db.FirstOrDefault(x => x.Email == model.Email) == null)
            {
                model.Id = Guid.NewGuid().ToString();
                model.Active = true;
                //var user = _mapper.Map<UserApp>(model);
                db.Add(model);
                return true;
            }
            else
            {
                return false;
            }

        }
        public async Task<IEnumerable<UserModel>?> getAllUsersAsync()
        {
            var users = (db.Count>0)? _mapper.Map<IEnumerable<UserModel>>(db): new List<UserModel>();
            return users;
        }

        public async Task<UserModel?> getUserByIdAsync(string id)
        {
           var user =  db.FirstOrDefault(x => x.Id == id);
           if (user != null)
                return  _mapper.Map<UserModel>(user);

            return null;
        }

        public async Task<UserModel?> getUserByEmailAsync(string email)
        {
            var user = db.FirstOrDefault(x => x.Email == email);
            if (user != null)
                return _mapper.Map<UserModel>(user);

            return null;
        }


    }
}
