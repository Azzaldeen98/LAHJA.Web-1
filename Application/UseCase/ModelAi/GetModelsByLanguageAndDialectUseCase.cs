using Domain.Entities.ModelAi;
using Domain.Exceptions;
using Domain.Repository.ModelAi;
 using Shared.Wrapper;

namespace Application.UseCase.ModelAi
{
    public class GetModelsByLanguageAndDialectUseCase
    {
        private readonly IModelAiRepository _repository;
        public GetModelsByLanguageAndDialectUseCase(IModelAiRepository repository) => _repository = repository;

        public async Task<Result<ICollection<ModelAiResponseEntity>>> ExecuteAsync(string language, string dialect)
        {
            try
            {
                return Result<ICollection<ModelAiResponseEntity>>.Success(await _repository.GetModelsByLanguageAndDialectAsync(language, dialect));
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
