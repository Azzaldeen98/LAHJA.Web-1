using Domain.Entities.ModelAi;
using Domain.Exceptions;
using Domain.Repository.ModelAi;
 using Shared.Wrapper;

namespace Application.UseCase.ModelAi
{
    public class GetModelsByTypeAndGenderUseCase
    {
        private readonly IModelAiRepository _repository;
        public GetModelsByTypeAndGenderUseCase(IModelAiRepository repository) => _repository = repository;

        public async Task<Result<ICollection<ModelAiResponseEntity>>> ExecuteAsync(string type, string gender)
        {
            try
            {
                return Result<ICollection<ModelAiResponseEntity>>.Success(await _repository.GetModelsByTypeAndGenderAsync(type, gender));
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
