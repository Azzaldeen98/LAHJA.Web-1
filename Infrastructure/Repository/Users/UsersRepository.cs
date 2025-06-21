
using AutoMapper;
using Domain.Entities.Plans;
using Domain.Entities.User;
using Domain.Repository.Users;
using Domain.Repository.Plans;
using Infrastructure.DataSource.Seeds;
using Infrastructure.Models.Plans;
using Infrastructure.Models.User;
using Shared.Settings;

namespace Infrastructure.Repository.Users
{
    public class UsersRepository : IUsersRepository
    {
        private readonly SeedsUsers seedsUsers;
        private readonly IMapper _mapper;
        private readonly ApplicationModeService appModeService;
        public UsersRepository(
            IMapper mapper,
            SeedsUsers seedsUsers, 
            ApplicationModeService appModeService)
        {

            //seedsPlans = new SeedsPlans();
            _mapper = mapper;
            this.seedsUsers = seedsUsers;
            this.appModeService = appModeService;
        }

        public async Task<IEnumerable<UserResponse>?> getAllUsersAsync()
        {
            var response = await ExecutorAppMode.ExecuteAsync<IEnumerable<UserModel>>(
               async () => new List<UserModel>(),
               seedsUsers.getAllUsersAsync

           );

            var data=(response!=null)? _mapper.Map<IEnumerable<UserResponse>>(response): null;

            return data;
        }

        public async Task<UserResponse?> getUserByIdAsync(string userId)
        {
            var response = await ExecutorAppMode.ExecuteAsync<UserModel>(
               async () => new UserModel(),
              () => seedsUsers.getUserByIdAsync(userId)

           );

            var data = (response != null) ? _mapper.Map<UserResponse>(response) : null;

            return data;
        }




    }
}
