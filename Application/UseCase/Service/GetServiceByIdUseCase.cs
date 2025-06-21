using Domain.Entities.Service.Response;
using Domain.Exceptions;
using Domain.Repository.Service;
 using Shared.Wrapper;

namespace Application.UseCase.Service
{
    public class GetServiceByIdUseCase
    {
        private readonly IServiceRepository repository;

        public GetServiceByIdUseCase(IServiceRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<ServiceResponse>> ExecuteAsync(string id)
        {
            try
            {
                var response= await repository.GetOneAsync(id);
                if(response == null)
                    return Result<ServiceResponse>.Fail("null");
                return Result<ServiceResponse>.Success(response);
            }
            catch (ServerException e)
            {

                return Result<ServiceResponse>.Fail(e.Message, e.StatusCode);
            }
            catch (Exception e)
            {
                return Result<ServiceResponse>.Fail(e.Message);
            }
        }
    }


}
