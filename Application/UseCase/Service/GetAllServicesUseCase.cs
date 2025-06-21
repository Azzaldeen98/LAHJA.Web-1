using Domain.Entities.Service.Response;
using Domain.Exceptions;
using Domain.Repository.AuthorizationSession;
using Domain.Repository.Service;
 using Shared.Wrapper;

namespace Application.UseCase.Service
{

 
    public class GetAllServicesUseCase
    {
        private readonly IServiceRepository repository;

        public GetAllServicesUseCase(IServiceRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<List<ServiceResponse>>> ExecuteAsync()
        {
            try
            {
                var response = await repository.GetAllAsync();

                    return Result<List<ServiceResponse>>.Success(response);
                
            }
            catch (ServerException e)
            {
                return Result<List<ServiceResponse>>.Fail(e.Message,e.StatusCode);
            }
            catch (Exception e)
            {
                return Result<List<ServiceResponse>>.Fail(e.Message);
            }


        }
    }

}
