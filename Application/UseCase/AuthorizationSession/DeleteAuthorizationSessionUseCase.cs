using Domain.Exceptions;
using Domain.Repository.AuthorizationSession;
using Domain.ShareData.Base;
 using Shared.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCase.AuthorizationSession
{

    public class DeleteAuthorizationSessionUseCase
    {
        private readonly IAuthorizationSessionRepository repository;

        public DeleteAuthorizationSessionUseCase(IAuthorizationSessionRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Result<DeleteResponse>> ExecuteAsync(string sessionId)
        {
            try
            {
                var response = await repository.DeleteAuthorizationSessionAsync(sessionId);
                return Result<DeleteResponse>.Success(response);
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
