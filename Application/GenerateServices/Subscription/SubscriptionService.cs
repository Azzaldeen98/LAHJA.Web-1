using Application.UseCases;
using Domain.Entity;
using Application.Validators.User;
using Domain.Validators.Enums;
using AutoGenerator.Attributes;
namespace Application.Services;


public class SubscriptionService : ISubscriptionService {


        
     private readonly CancelSubscriptionUseCase _cancelSubscriptionUseCase;
     private readonly GetOneSubscriptionUseCase _getOneSubscriptionUseCase;
     private readonly GetSubscriptionsUseCase _getSubscriptionsUseCase;
     private readonly GetSubscriptionUseCase _getSubscriptionUseCase;
     private readonly PauseSubscriptionUseCase _pauseSubscriptionUseCase;
     private readonly RenewSubscriptionUseCase _renewSubscriptionUseCase;
     private readonly ResumeSubscriptionUseCase _resumeSubscriptionUseCase;
     private readonly IUserValidator userValidator;


    public SubscriptionService(
            CancelSubscriptionUseCase cancelSubscriptionUseCase,
            GetOneSubscriptionUseCase getOneSubscriptionUseCase,
            GetSubscriptionsUseCase getSubscriptionsUseCase,
            GetSubscriptionUseCase getSubscriptionUseCase,
            PauseSubscriptionUseCase pauseSubscriptionUseCase,
            RenewSubscriptionUseCase renewSubscriptionUseCase,
            ResumeSubscriptionUseCase resumeSubscriptionUseCase,
            IUserValidator userValidator)
    {

        _cancelSubscriptionUseCase = cancelSubscriptionUseCase;
        _getOneSubscriptionUseCase = getOneSubscriptionUseCase;
        _getSubscriptionsUseCase = getSubscriptionsUseCase;
        _getSubscriptionUseCase = getSubscriptionUseCase;
        _pauseSubscriptionUseCase = pauseSubscriptionUseCase;
        _renewSubscriptionUseCase = renewSubscriptionUseCase;
        _resumeSubscriptionUseCase = resumeSubscriptionUseCase;
        this.userValidator = userValidator;
    }







    public async Task<Subscription> getOneSubscriptionAsync(string id, CancellationToken cancellationToken)
    {
    

         return   await _getOneSubscriptionUseCase.ExecuteAsync(id,cancellationToken);
        
    }



    public async Task<ICollection<Subscription>> getSubscriptionsAsync(CancellationToken cancellationToken)
    {


        return   await _getSubscriptionsUseCase.ExecuteAsync(cancellationToken);
        
    }



    public async Task<Subscription> getSubscriptionAsync(CancellationToken cancellationToken)
    {
    

         return   await _getSubscriptionUseCase.ExecuteAsync(cancellationToken);
        
    }


    [ManualEdited]
    public async Task pauseSubscriptionAsync(Subscription model, CancellationToken cancellationToken)
    {

        var validate = await userValidator.ValidateAsync(UserValidatorStates.SubscriptionActive);
        if (validate!=null && validate.Success==true)
            await _pauseSubscriptionUseCase.ExecuteAsync(model, cancellationToken);
        
    }



    public async Task renewSubscriptionAsync(CancellationToken cancellationToken)
    {
    

         await _renewSubscriptionUseCase.ExecuteAsync(cancellationToken);
        
    }


    [ManualEdited]
    public async Task resumeSubscriptionAsync(CancellationToken cancellationToken)
    {

        var validate = await userValidator.ValidateAsync(UserValidatorStates.SubscriptionActive);
        if (validate != null && validate.Success == true)
            await _resumeSubscriptionUseCase.ExecuteAsync(cancellationToken);
        
    }

    [ManualEdited]
    public async Task cancelSubscriptionAsync(CancellationToken cancellationToken)
    {

        var validate = await userValidator.ValidateAsync(UserValidatorStates.SubscriptionActive);
        if (validate != null && validate.Success == true)
            await _cancelSubscriptionUseCase.ExecuteAsync(cancellationToken);

    }


}
