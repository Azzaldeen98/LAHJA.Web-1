using AutoMapper;

using Shared.Settings;

namespace Infrastructure.Core.Repositories.Base
{

    public interface IBaseRepository<T> where T : class
    {

    }

    public class BaseRepository<T>: IBaseRepository<T> where T : class
    {
        protected readonly IMapper _mapper;
        protected readonly ApplicationModeService _appModeService;
        protected readonly T _apiClient;
        public BaseRepository(IMapper mapper, ApplicationModeService appModeService, T apiClient)
        {
            _mapper = mapper;
            _appModeService = appModeService;
            _apiClient = apiClient;
        }
    }

}
