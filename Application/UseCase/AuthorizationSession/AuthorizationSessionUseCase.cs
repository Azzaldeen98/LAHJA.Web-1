using Domain.Entities.AuthorizationSession;
using Domain.Exceptions;
using Domain.Repository.AuthorizationSession;
 using Shared.Wrapper;

namespace Application.UseCase.AuthorizationSession
{
    public class AuthorizationSessionUseCase
    {
        private readonly IAuthorizationSessionRepository repository;

        public AuthorizationSessionUseCase(IAuthorizationSessionRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<AuthorizationSessionCoreResponse>> ExecuteAsync(ValidateTokenRequest request)
        {
            try
            {
                var response = await repository.AuthorizationSessionAsync(request);
                return Result<AuthorizationSessionCoreResponse>.Success(response);
            }
            catch (ServerException e)
            {
                Console.WriteLine($"ServerException: {e.Message}, StatusCode: {e.StatusCode}");
                return Result<AuthorizationSessionCoreResponse>.Fail(e.Message, e.StatusCode);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
                return Result<AuthorizationSessionCoreResponse>.Fail("An unexpected error occurred. Please try again.");
            }
        }
    }  


}
