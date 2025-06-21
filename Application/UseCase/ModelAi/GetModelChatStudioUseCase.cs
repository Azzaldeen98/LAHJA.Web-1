using Domain.Exceptions;
using Domain.Repository.ModelAi;
 using Shared.Wrapper;

namespace Application.UseCase.ModelAi
{
    public class GetModelChatStudioUseCase
    {
        private readonly IModelAiRepository _repository;
        public GetModelChatStudioUseCase(IModelAiRepository repository) => _repository = repository;

        public async Task<Result<IDictionary<string, object>>> ExecuteAsync(string lg)
        {
            try
            {
                return Result<IDictionary<string, object>>.Success(await _repository.GetModelChatStudioAsync(lg));
            }
            catch (ServerException e)
            {
                return Result<IDictionary<string, object>>.Fail(e.Message, e.StatusCode);
            }
            catch (Exception e)
            {
                return Result<IDictionary<string, object>>.Fail(e.Message);
            }
        }
    }


}
