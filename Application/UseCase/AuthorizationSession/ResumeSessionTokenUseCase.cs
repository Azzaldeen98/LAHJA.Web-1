using Domain.Exceptions;
using Domain.Repository.AuthorizationSession;
using Domain.ShareData.Base;
 using Shared.Wrapper;

namespace Application.UseCase.AuthorizationSession
{
    public class ResumeSessionTokenUseCase
    {
        private readonly IAuthorizationSessionRepository repository;

        public ResumeSessionTokenUseCase(IAuthorizationSessionRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<DeleteResponse>> ExecuteAsync(string id)
        {
            try
            {
               var res= await repository.ResumeAuthorizationSessionAsync(id);
                return Result<DeleteResponse>.Success(res);
            }
            catch (ServerException e)
            {
                Console.WriteLine($"ServerException: {e.Message}, StatusCode: {e.StatusCode}");
                return Result<DeleteResponse>.Fail(e.Message, e.StatusCode);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
                return Result<DeleteResponse>.Fail("An unexpected error occurred. Please try again.");
            }
        }
    }
}
