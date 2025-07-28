
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


public interface IPlanService :  ITBaseShareService  
{

    public Task<int> countAllPlansAsync(CancellationToken cancellationToken);


    public Task<PaginatedResult<Plan>> getAllPlansAsync(string lg, CancellationToken cancellationToken);


    public Task<Plan> getByIdPlanAsync(string lg, string id, CancellationToken cancellationToken);


    public Task<ICollection<Plan>> getPlansAsync(string lg, CancellationToken cancellationToken);




}

