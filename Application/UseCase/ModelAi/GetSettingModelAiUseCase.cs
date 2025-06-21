using Domain.Entities.ModelAi;
using Domain.Exceptions;
using Domain.Repository.ModelAi;
 using Shared.Wrapper;

namespace Application.UseCase.ModelAi
{
    public class GetSettingModelAiUseCase
    {
        private readonly IModelAiRepository _repository;
        public GetSettingModelAiUseCase(IModelAiRepository repository) => _repository = repository;

        public async Task<Result<ModelPropertyValuesEntity>> ExecuteAsync(string lg)
        {
            try
            {
                return Result<ModelPropertyValuesEntity>.Success(await _repository.GetSettingModelAiAsync(lg));
            }
            catch (ServerException e)
            {
                return Result < ModelPropertyValuesEntity>.Fail(e.Message, e.StatusCode);
            }
            catch (Exception e)
            {
                return Result<ModelPropertyValuesEntity>.Fail(e.Message);
            }
        }
    }


}
