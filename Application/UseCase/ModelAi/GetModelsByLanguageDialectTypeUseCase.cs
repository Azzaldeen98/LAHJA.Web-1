using Domain.Entities.ModelAi;
using Domain.Exceptions;
using Domain.Repository.ModelAi;
 using Shared.Wrapper;

namespace Application.UseCase.ModelAi
{
    public class GetModelsByLanguageDialectTypeUseCase
    {
        private readonly IModelAiRepository _repository;
        public GetModelsByLanguageDialectTypeUseCase(IModelAiRepository repository) => _repository = repository;

        public async Task<Result<ICollection<ModelAiResponseEntity>>> ExecuteAsync(string language, string dialect, string type)
        {
            try
            {
                return Result<ICollection<ModelAiResponseEntity>>.Success(await _repository.GetModelsByLanguageDialectTypeAsync(language, dialect, type));
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
