using Domain.Entities.ModelAi;
using Domain.Exceptions;
using Domain.Repository.ModelAi;
 using Shared.Wrapper;

namespace Application.UseCase.ModelAi
{
    public class GetValueFilterServiceUseCase
    {
        private readonly IModelAiRepository _repository;
        public GetValueFilterServiceUseCase(IModelAiRepository repository) => _repository = repository;

        public async Task<Result<ICollection<ValueFilterModelEntity>>> ExecuteAsync(string lg)
        {
            try
            {
                return Result<ICollection<ValueFilterModelEntity>>.Success(await _repository.GetValueFilterServiceAsync(lg));
            }
            catch (ServerException e)
            {
                return Result<ICollection<ValueFilterModelEntity>>.Fail(e.Message, e.StatusCode);
            }
            catch (Exception e)
            {
                return Result<ICollection<ValueFilterModelEntity>>.Fail(e.Message);
            }
        }
    }


}
