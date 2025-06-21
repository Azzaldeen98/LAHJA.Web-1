using Domain.Entities.Subscriptions.Request;
using Domain.Entities.Subscriptions.Response;
using Domain.Exceptions;
using Domain.Repository.Subscriptions;
 using Shared.Wrapper;

namespace Application.UseCase.Plans.Get
{
    public class CreateSubscriptionUseCase
    {
        private readonly ISubscriptionsRepository repository;
        public CreateSubscriptionUseCase(ISubscriptionsRepository repository)
        {

            this.repository = repository;
        }

        public async Task<Result<SubscriptionCreateResponse>> ExecuteAsync(SubscriptionCreate request)
        {

            try
            {
                var response = await repository.CreateAsync(request);
              return  Result<SubscriptionCreateResponse>.Success(response);

            }
            catch(ServerException e)
            {
                return Result<SubscriptionCreateResponse>.Fail(e.Message,e.StatusCode);

            }
            catch(Exception e)
            {
                return Result<SubscriptionCreateResponse>.Fail(e.Message);
            }
           
           

        }
    }  






}
