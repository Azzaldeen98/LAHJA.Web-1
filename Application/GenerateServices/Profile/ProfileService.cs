
using System.Threading.Tasks;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
using Shared.Wrapper;
using Domain.Entity;
using AutoGenerator.Attributes;
using Application.Validators;
using Domain.Validators.Enums;
namespace Application.Services;


public class ProfileService : IProfileService {


           
     private readonly GetModelsAiProfileUseCase _getModelsAiProfileUseCase;
     private readonly GetServicesProfileUseCase _getServicesProfileUseCase;
     private readonly GetSpacesSubscriptionProfileUseCase _getSpacesSubscriptionProfileUseCase;
     private readonly GetSpaceSubscriptionProfileUseCase _getSpaceSubscriptionProfileUseCase;
     private readonly GetUserProfileUseCase _getUserProfileUseCase;
     private readonly GetUserSubscriptionsProfileUseCase _getUserSubscriptionsProfileUseCase;
     private readonly RequestsServiceProfileUseCase _requestsServiceProfileUseCase;
     private readonly RequestsSubscriptionProfileUseCase _requestsSubscriptionProfileUseCase;
     private readonly UpdateProfileUseCase _updateProfileUseCase;


        public ProfileService(   
            GetModelsAiProfileUseCase getModelsAiProfileUseCase,
            GetServicesProfileUseCase getServicesProfileUseCase,
            GetSpacesSubscriptionProfileUseCase getSpacesSubscriptionProfileUseCase,
            GetSpaceSubscriptionProfileUseCase getSpaceSubscriptionProfileUseCase,
            GetUserProfileUseCase getUserProfileUseCase,
            GetUserSubscriptionsProfileUseCase getUserSubscriptionsProfileUseCase,
            RequestsServiceProfileUseCase requestsServiceProfileUseCase,
            RequestsSubscriptionProfileUseCase requestsSubscriptionProfileUseCase,
            UpdateProfileUseCase updateProfileUseCase)
        {
                
          _getModelsAiProfileUseCase=getModelsAiProfileUseCase;
          _getServicesProfileUseCase=getServicesProfileUseCase;
          _getSpacesSubscriptionProfileUseCase=getSpacesSubscriptionProfileUseCase;
          _getSpaceSubscriptionProfileUseCase=getSpaceSubscriptionProfileUseCase;
          _getUserProfileUseCase=getUserProfileUseCase;
          _getUserSubscriptionsProfileUseCase=getUserSubscriptionsProfileUseCase;
          _requestsServiceProfileUseCase=requestsServiceProfileUseCase;
          _requestsSubscriptionProfileUseCase=requestsSubscriptionProfileUseCase;
          _updateProfileUseCase=updateProfileUseCase;


        }

                        

    public async Task<ICollection<ModelAi>> getModelsAiProfileAsync(CancellationToken cancellationToken)
    {
    

                     return   await _getModelsAiProfileUseCase.ExecuteAsync(cancellationToken);
                    
    }



    public async Task<ICollection<Service>> getServicesProfileAsync(CancellationToken cancellationToken)
    {
    

                     return   await _getServicesProfileUseCase.ExecuteAsync(cancellationToken);
                    
    }



    public async Task<ICollection<Space>> getSpacesSubscriptionProfileAsync(string subscriptionId, CancellationToken cancellationToken)
    {
    

                     return   await _getSpacesSubscriptionProfileUseCase.ExecuteAsync(subscriptionId, cancellationToken);
                    
    }



    public async Task<Space> getSpaceSubscriptionProfileAsync(string subscriptionId, string spaceId, CancellationToken cancellationToken)
    {
    

                     return   await _getSpaceSubscriptionProfileUseCase.ExecuteAsync(subscriptionId, spaceId, cancellationToken);
                    
    }



    public async Task<User> getUserProfileAsync(CancellationToken cancellationToken)
    {
    

                     return   await _getUserProfileUseCase.ExecuteAsync(cancellationToken);
                    
    }



    public async Task<PaginatedResult<Subscription>> getUserSubscriptionsProfileAsync(CancellationToken cancellationToken)
    {
    

                     return   await _getUserSubscriptionsProfileUseCase.ExecuteAsync(cancellationToken);
                    
    }



    public async Task<PaginatedResult<Request>> requestsServiceProfileAsync(string serviceId, CancellationToken cancellationToken)
    {
    

                     return   await _requestsServiceProfileUseCase.ExecuteAsync(serviceId, cancellationToken);
                    
    }



    public async Task<PaginatedResult<Request>> requestsSubscriptionProfileAsync(string subscriptionId, CancellationToken cancellationToken)
    {
    

                     return   await _requestsSubscriptionProfileUseCase.ExecuteAsync(subscriptionId, cancellationToken);
                    
    }



    public async Task updateProfileAsync(User body, CancellationToken cancellationToken)
    {
    

                     await _updateProfileUseCase.ExecuteAsync(body, cancellationToken);
                    
    }





}
