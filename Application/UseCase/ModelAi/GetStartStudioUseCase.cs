using Domain.Entities.ModelAi;
using Domain.Exceptions;
using Domain.Repository.ModelAi;
 using Shared.Wrapper;

namespace Application.UseCase.ModelAi
{
    public class GetStartStudioUseCase
    {
        private readonly IModelAiRepository _repository;
        public GetStartStudioUseCase(IModelAiRepository repository) => _repository = repository;

        public async Task<Result<ItemEntity>> ExecuteAsync(string lg)
        {
            try
            {
                return Result<ItemEntity>.Success(await _repository.GetStartStudioAsync(lg));
            }
            catch (ServerException e)
            {
                return Result<ItemEntity>.Fail(e.Message, e.StatusCode);
            }
            catch (Exception e)
            {
                return Result<ItemEntity>.Fail(e.Message);
            }
        }
    }


}
