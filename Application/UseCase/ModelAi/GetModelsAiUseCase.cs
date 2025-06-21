using Domain.Entities.ModelAi;
using Domain.Exceptions;
using Domain.Repository.ModelAi;
 using Shared.Wrapper;

namespace Application.UseCase.ModelAi
{
    public class GetModelsAiUseCase
    {
        private readonly IModelAiRepository _repository;
        public GetModelsAiUseCase(IModelAiRepository repository) => _repository = repository;

        public async Task<Result<ICollection<ModelAiResponseEntity>>> ExecuteAsync()
        {
            try
            {
                return Result<ICollection<ModelAiResponseEntity>>.Success(await _repository.GetModelsAiAsync());
            }
            catch (ServerException e)
            {
                return Result<ICollection<ModelAiResponseEntity>>.Fail(e.Message, e.StatusCode);
            }
            catch (Exception e)
            {
                return Result<ICollection<ModelAiResponseEntity>>.Fail(e.Message);
            }
        }
    }


}
