
using AutoMapper;
 using Shared.Wrapper;
using Infrastructure.DataSource.Seeds;

using Domain.ShareData.Base;
using Infrastructure.Models.BaseFolder.Response;
using Infrastructure.DataSource.ApiClient.Service;
using Domain.Repository.Service;
using Shared.Settings;
using Infrastructure.Models.Service.Response;
using Domain.Entities.Service.Response;
using Domain.Entities.Service.Request;
using Infrastructure.Models.Service.Request;
using System.Text.Json.Serialization;
using Domain.Exceptions;


namespace Infrastructure.Repository.Services
{

    public class ServiceRepository : IServiceRepository
    {
        private readonly SeedsPlans seedsPlans;
        private readonly ServiceApiClient _servicesApiClient;
        private readonly IMapper _mapper;
        private readonly ApplicationModeService appModeService;
        public ServiceRepository(
            IMapper mapper,
            SeedsPlans seedsPlans,
            ApplicationModeService appModeService,
            ServiceApiClient ServicesApiClient)
        {

            //seedsPlans = new SeedsPlans();
            _mapper = mapper;
            this.seedsPlans = seedsPlans;
            this.appModeService = appModeService;

            this._servicesApiClient = ServicesApiClient;
        }
      
        public async Task<List<ServiceResponse>> GetAllAsync()
        {
            var response = await ExecutorAppMode.ExecuteAsync(
                 async () => await _servicesApiClient.GetAllAsync(),
                  async () => new());

            if (response!=null)
            {
                var result =  _mapper.Map<List<ServiceResponse>>(response);
                return result;
            }
            else
            {
                return new();
            }


        }
        public async Task<ServiceResponse?> GetOneAsync(string id)
        {
            var response = await ExecutorAppMode.ExecuteAsync<ServiceResponseModel>(
                 async () => await _servicesApiClient.GetOneAsync(id),
                  async () => await _servicesApiClient.GetOneAsync(id));

            if (response!=null)
            {
                return  _mapper.Map<ServiceResponse>(response);
               
            }
            else
            {
                return null;
            }


        }
        public async Task<Result<ServiceResponse>> UpdateAsync(ServiceRequest request)
        {
            var model = _mapper.Map<ServiceRequestModel>(request);

            var response = await ExecutorAppMode.ExecuteAsync<Result<ServiceResponseModel>>(
                 async () => await _servicesApiClient.UpdateAsync(model),
                  async () => Result<ServiceResponseModel>.Success());

            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<ServiceResponse>(response.Data) : null;
                return Result<ServiceResponse>.Success(result);
            }
            else
            {
                return Result<ServiceResponse>.Fail(response.Messages);
            }



        }
        public async Task<Result<ServiceResponse>> CreateAsync(ServiceRequest request)
        {
            var model = _mapper.Map<ServiceRequestModel>(request);

            var response = await ExecutorAppMode.ExecuteAsync<Result<ServiceResponseModel>>(
                 async () => await _servicesApiClient.CreateAsync(model),
                  async () => Result<ServiceResponseModel>.Success());

            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<ServiceResponse>(response.Data) : null;
                return Result<ServiceResponse>.Success(result);
            }
            else
            {
                return Result<ServiceResponse>.Fail(response.Messages);
            }



        }
        public async Task<Result<DeleteResponse>> DeleteAsync(string id)
        {
            var response = await ExecutorAppMode.ExecuteAsync<Result<DeleteResponseModel>>(
                 async () => await _servicesApiClient.DeleteAsync(id),
                  async () => Result<DeleteResponseModel>.Success());

            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<DeleteResponse>(response.Data) : null;
                return Result<DeleteResponse>.Success(result);
            }
            else
            {
                return Result<DeleteResponse>.Fail(response.Messages);
            }
        }


   

      
    } 
}
