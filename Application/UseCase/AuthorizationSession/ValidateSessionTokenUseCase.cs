using Domain.Exceptions;
using Domain.Repository.AuthorizationSession;
 using Shared.Wrapper;

namespace Application.UseCase.AuthorizationSession
{
    public class ValidateSessionTokenUseCase
    {
        private readonly IAuthorizationSessionRepository repository;

        public ValidateSessionTokenUseCase(IAuthorizationSessionRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<bool>> ExecuteAsync(string token)
        {
            try
            {
                await repository.ValidateSessionTokenAsync(token);
                return Result<bool>.Success(true);
            }
            catch (ServerException e)
            {
                Console.WriteLine($"ServerException: {e.Message}, StatusCode: {e.StatusCode}");
                return Result<bool>.Fail(e.Message, e.StatusCode);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
                return Result<bool>.Fail("An unexpected error occurred. Please try again.");
            }
        }
    }
}
