using Domain.Entities.AuthorizationSession;
using Domain.Exceptions;
using Domain.Repository.AuthorizationSession;
 using Shared.Wrapper;

namespace Application.UseCase.AuthorizationSession
{
    public class EncryptFromWebUseCase
    {
        private readonly IAuthorizationSessionRepository repository;

        public EncryptFromWebUseCase(IAuthorizationSessionRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<AuthorizationSessionEncryptResponse>> ExecuteAsync()
        {
            try
            {
                var response = await repository.EncryptFromWebAsync();
                return Result<AuthorizationSessionEncryptResponse>.Success(response);
            }
            catch (ServerException e)
            {
                Console.WriteLine($"ServerException: {e.Message}, StatusCode: {e.StatusCode}");
                return Result<AuthorizationSessionEncryptResponse>.Fail(e.Message, e.StatusCode);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
                return Result<AuthorizationSessionEncryptResponse>.Fail("An unexpected error occurred. Please try again.");
            }
        }
    }


}
