using Domain.Entities.AuthorizationSession;
using Domain.Exceptions;
using Domain.Repository.AuthorizationSession;
 using Shared.Wrapper;

namespace Application.UseCase.AuthorizationSession
{
    public class CreateAuthorizationSessionUseCase
    {
        private readonly IAuthorizationSessionRepository repository;

        public CreateAuthorizationSessionUseCase(IAuthorizationSessionRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<AuthorizationSessionWebResponse>> ExecuteAsync(AuthorizationWebRequest request)
        {
            try
            {
                var response = await repository.CreateAuthorizationSessionAsync(request);
                return Result<AuthorizationSessionWebResponse>.Success(response);
            }
            catch (ServerException e)
            {
                Console.WriteLine($"ServerException: {e.Message}, StatusCode: {e.StatusCode}");
                return Result<AuthorizationSessionWebResponse>.Fail(e.Message, e.StatusCode);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
                return Result<AuthorizationSessionWebResponse>.Fail("An unexpected error occurred. Please try again.");
            }
        }
    }

}
