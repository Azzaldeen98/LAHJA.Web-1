using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository.Users
{
    public  interface  IUsersRepository
    {
       public Task<IEnumerable<UserResponse>?> getAllUsersAsync();
        public Task<UserResponse?> getUserByIdAsync(string userId);
    }

}
