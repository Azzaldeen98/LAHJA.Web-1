using AutoMapper;
using Domain.Exceptions;
 using Shared.Wrapper;
using Infrastructure.DataSource.ApiClient.Base;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Middlewares;
using Infrastructure.Models.BaseFolder.Response;
using Infrastructure.Models.Service.Request;
using Infrastructure.Models.Service.Response;
using Infrastructure.Nswag;
using Infrastructure.Share.Invoker;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.DataSource.ApiClient.Service
{
    public class ServiceApiClient : BuildApiClient<ServiceClient>
    {

        public ServiceApiClient(ClientFactory clientFactory, IMapper mapper, IConfiguration config, IApiInvoker apiSafelyHandler) 
            : base(clientFactory, mapper, config, apiSafelyHandler)
        {

        }

        public async Task<List<ServiceResponseModel>> GetAllAsync()
        {
            try
            {
           
                var client = await GetApiClient();
                var response = await client.GetServicesAsync();
                 return _mapper.Map<List<ServiceResponseModel>>(response);
               

            }
            catch (ApiException e)
            {
                throw new ServerException(e.Message, e.StatusCode);
                //return Result<List<ServiceResponseModel>>.Fail(e.Response, httpCode: e.StatusCode);

            }




        }
        public async Task<ServiceResponseModel> GetOneAsync(string id)
        {
            try
            {
                //var model = _mapper.Map<CheckoutOptions>(request);
                var client = await GetApiClient();
                var response = await client.GetServiceAsync(id);

                var resModel = _mapper.Map<ServiceResponseModel>(response);
                return resModel;

            }
            catch (ApiException e)
            {
                throw new ServerException(e.Message,e.StatusCode);
                //return Result<ServiceResponseModel>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }
        public async Task<Result<ServiceResponseModel>> UpdateAsync(ServiceRequestModel request)
        {
            try
            {
                var model = _mapper.Map<ServiceUpdateVM>(request);
                var client = await GetApiClient();
                await client.UpdateServiceAsync(request.Id, model);


                //var resModel = _mapper.Map<ServiceResponseModel>(response);
                return Result<ServiceResponseModel>.Success();

            }
            catch (ApiException e)
            {

                return Result<ServiceResponseModel>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }
        public async Task<Result<ServiceResponseModel>> CreateAsync(ServiceRequestModel request)
        {
            try
            {
                var model = _mapper.Map<ServiceCreateVM>(request);
                var client = await GetApiClient();
                var response = await client.CreateServiceAsync(model);


                var resModel = _mapper.Map<ServiceResponseModel>(response);
                return Result<ServiceResponseModel>.Success(resModel);

            }
            catch (ApiException e)
            {

                return Result<ServiceResponseModel>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }
        public async Task<Result<DeleteResponseModel>> DeleteAsync(string id)
        {
            try
            {
                //var model = _mapper.Map<ServiceCreate>(request);
                var client = await GetApiClient();
                await client.DeleteServiceAsync(id);


                //var resModel = _mapper.Map<DeleteResponseModel>(response);
                return Result<DeleteResponseModel>.Success();

            }
            catch (ApiException e)
            {

                return Result<DeleteResponseModel>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }

    }
}
