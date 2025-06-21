
using System.Threading.Tasks;
using Shared.Interfaces;
using Microsoft.Extensions.Configuration;
using Application.UseCases;
using Shared.Wrapper;
using Domain.Entity;
namespace Application.Services;


public class PlanService : IPlanService {


        
     private readonly CountAllPlansUseCase _countAllPlansUseCase;
     private readonly GetAllPlansUseCase _getAllPlansUseCase;
     private readonly GetByIdPlanUseCase _getByIdPlanUseCase;
     private readonly GetPlansUseCase _getPlansUseCase;


    public PlanService(   
            CountAllPlansUseCase countAllPlansUseCase,
            GetAllPlansUseCase getAllPlansUseCase,
            GetByIdPlanUseCase getByIdPlanUseCase,
            GetPlansUseCase getPlansUseCase)
    {
                        
          _countAllPlansUseCase=countAllPlansUseCase;
          _getAllPlansUseCase=getAllPlansUseCase;
          _getByIdPlanUseCase=getByIdPlanUseCase;
          _getPlansUseCase=getPlansUseCase;


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



    public async Task<List<Plan>> getPlansAsync(String lg, CancellationToken cancellationToken)
    {
    

         return   await _getPlansUseCase.ExecuteAsync(lg, cancellationToken);
        
    }





}
