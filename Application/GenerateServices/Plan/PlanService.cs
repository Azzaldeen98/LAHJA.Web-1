using Application.UseCases;
using Shared.Wrapper;
using Domain.Entity;
using Application.Validators.User;
using Domain.Validators.Enums;
using Shared.Constants.Localization;
namespace Application.Services;


public class PlanService : IPlanService {

    private readonly CountAllPlansUseCase _countAllPlansUseCase;
    private readonly GetAllPlansUseCase _getAllPlansUseCase;
    private readonly GetByIdPlanUseCase _getByIdPlanUseCase;
    private readonly GetPlansUseCase _getPlansUseCase;
    private readonly IUserValidator userValidator;

    public PlanService(
            CountAllPlansUseCase countAllPlansUseCase,
            GetAllPlansUseCase getAllPlansUseCase,
            GetByIdPlanUseCase getByIdPlanUseCase,
            GetPlansUseCase getPlansUseCase,
            IUserValidator userValidator)
    {

        _countAllPlansUseCase = countAllPlansUseCase;
        _getAllPlansUseCase = getAllPlansUseCase;
        _getByIdPlanUseCase = getByIdPlanUseCase;
        _getPlansUseCase = getPlansUseCase;
        this.userValidator = userValidator;
    }



    public async Task<int> countAllPlansAsync(CancellationToken cancellationToken)
    {
         return   await _countAllPlansUseCase.ExecuteAsync(cancellationToken);
        
    }



    public async Task<PaginatedResult<Plan>> getAllPlansAsync(string lg, CancellationToken cancellationToken)
    {

  

        return   await _getAllPlansUseCase.ExecuteAsync(lg, cancellationToken);
        
    }



    public async Task<Plan> getByIdPlanAsync(string lg, string id, CancellationToken cancellationToken)
    {
    
         return   await _getByIdPlanUseCase.ExecuteAsync(lg, id, cancellationToken);
        
    }



    public async Task<ICollection<Plan>> getPlansAsync(String lg, CancellationToken cancellationToken)
    {


        var items = await _getPlansUseCase.ExecuteAsync(lg, cancellationToken);

        if (items?.Any() == true)
        {
            var validate = await userValidator.ValidateAsync(UserValidatorStates.SubscriptionActive,cancellationToken);

            if (validate?.Success == true && validate.Result is Subscription sub)
            {
                var targetPlan = items.FirstOrDefault(x => x.Id == sub.PlanId);
                if (targetPlan != null)
                {
                    targetPlan.HasSubscription = true;
                }
            }
        }

        return items;




    }





}
