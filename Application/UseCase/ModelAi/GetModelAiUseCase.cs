using Domain.Entities.ModelAi;
using Domain.Exceptions;
using Domain.Repository.ModelAi;
 using Shared.Wrapper;

namespace Application.UseCase.ModelAi
{
    public class GetModelAiUseCase
    {
        private readonly IModelAiRepository _repository;
        public GetModelAiUseCase(IModelAiRepository repository) => _repository = repository;

        public async Task<Result<ModelAiResponseEntity>> ExecuteAsync(string id)
        {
            try
            {
                return Result<ModelAiResponseEntity>.Success(await _repository.GetModelAiAsync(id));
            }
            catch (ServerException e)
            {
                return Result<ModelAiResponseEntity>.Fail(e.Message, e.StatusCode);
            }
            catch (Exception e)
            {
                return Result<ModelAiResponseEntity>.Fail(e.Message);
            }
        }
    }


}
