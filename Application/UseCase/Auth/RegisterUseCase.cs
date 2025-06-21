using Domain.Entities.Plans;
using Domain.Repository.Auth;
using Domain.Repository.Plans;
using Infrastructure.Models.Plans;
 using Shared.Wrapper;
using Domain.Entities.Auth.Response;
using Domain.Entities.Auth.Request;

namespace Application.UseCase.Auth  
{
    public class RegisterUseCase
    {
        private readonly IAuthRepository repository;
        public RegisterUseCase(IAuthRepository repository)
        {

            this.repository = repository;
        }


        public async Task<Result<RegisterResponse>> ExecuteAsync(RegisterRequest  request)
        {

            var data = await repository.registerAsync(request);
            return  data;

            //if (data != null)
            //{
            //    return Result<RegisterResponse>.Success(data);
            //}
            //else
            //{
            //    return Result<RegisterResponse>.Fail("البريد الالكتروني او رقم الهاتف غير صالح !!");
            //}


        }
    } 
}
