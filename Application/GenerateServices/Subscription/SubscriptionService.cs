
using System.Threading.Tasks;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
using Shared.Wrapper;
using Domain.Entity;
namespace Application.Services;


public class SubscriptionService : ISubscriptionService {


        
     private readonly CancelSubscriptionUseCase _cancelSubscriptionUseCase;
     private readonly GetOneSubscriptionUseCase _getOneSubscriptionUseCase;
     private readonly GetSubscriptionsUseCase _getSubscriptionsUseCase;
     private readonly GetSubscriptionUseCase _getSubscriptionUseCase;
     private readonly PauseSubscriptionUseCase _pauseSubscriptionUseCase;
     private readonly RenewSubscriptionUseCase _renewSubscriptionUseCase;
     private readonly ResumeSubscriptionUseCase _resumeSubscriptionUseCase;


    public SubscriptionService(   
            CancelSubscriptionUseCase cancelSubscriptionUseCase,
            GetOneSubscriptionUseCase getOneSubscriptionUseCase,
            GetSubscriptionsUseCase getSubscriptionsUseCase,
            GetSubscriptionUseCase getSubscriptionUseCase,
            PauseSubscriptionUseCase pauseSubscriptionUseCase,
            RenewSubscriptionUseCase renewSubscriptionUseCase,
            ResumeSubscriptionUseCase resumeSubscriptionUseCase)
    {
                        
          _cancelSubscriptionUseCase=cancelSubscriptionUseCase;
          _getOneSubscriptionUseCase=getOneSubscriptionUseCase;
          _getSubscriptionsUseCase=getSubscriptionsUseCase;
          _getSubscriptionUseCase=getSubscriptionUseCase;
          _pauseSubscriptionUseCase=pauseSubscriptionUseCase;
          _renewSubscriptionUseCase=renewSubscriptionUseCase;
          _resumeSubscriptionUseCase=resumeSubscriptionUseCase;


    }

                

    public async Task cancelSubscriptionAsync(string id, CancellationToken cancellationToken)
    {
    

         await _cancelSubscriptionUseCase.ExecuteAsync(id, cancellationToken);
        
    }



    public async Task<Subscription> getOneSubscriptionAsync(string id, CancellationToken cancellationToken)
    {
    

         return   await _getOneSubscriptionUseCase.ExecuteAsync(id, cancellationToken);
        
    }



    public async Task<ICollection<Subscription>> getSubscriptionsAsync(CancellationToken cancellationToken)
    {
    

         return   await _getSubscriptionsUseCase.ExecuteAsync(cancellationToken);
        
    }



    public async Task<Subscription> getSubscriptionAsync(CancellationToken cancellationToken)
    {
    

         return   await _getSubscriptionUseCase.ExecuteAsync(cancellationToken);
        
    }



    public async Task pauseSubscriptionAsync(string id, Subscription model, CancellationToken cancellationToken)
    {
    

         await _pauseSubscriptionUseCase.ExecuteAsync(id, model, cancellationToken);
        
    }



    public async Task renewSubscriptionAsync(string id, CancellationToken cancellationToken)
    {
    

         await _renewSubscriptionUseCase.ExecuteAsync(id, cancellationToken);
        
    }



    public async Task resumeSubscriptionAsync(string id, CancellationToken cancellationToken)
    {
    

         await _resumeSubscriptionUseCase.ExecuteAsync(id, cancellationToken);
        
    }





}
