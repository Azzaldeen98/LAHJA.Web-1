using AutoMapper;
using Infrastructure.DataSource.ApiClientFactory;
using Microsoft.Extensions.Configuration;
using Infrastructure.DataSource.ApiClient.Base;
 using Shared.Wrapper;
using Domain.Entities.ModelGateway;
using Infrastructure.Models.BaseFolder.Response;
using Domain.ShareData.Base;
using Infrastructure.Models.ModelGateway;
using Infrastructure.Nswag;
using Infrastructure.Middlewares;
using Infrastructure.Share.Invoker;


namespace Infrastructure.DataSource.ApiClient.ModelGateway
{


    public class ModelGatewayApiClient : BuildApiClient<ModelGatewayClient>
    {

        public ModelGatewayApiClient(ClientFactory clientFactory, IMapper mapper, IConfiguration config, IApiInvoker apiSafelyHandler) 
            : base(clientFactory, mapper, config,apiSafelyHandler)
        {
        }

        public async Task<Result<IEnumerable<ModelGatewayResponseModel>>> GetAllModelGatewaysAsync()
        {
            try
            {
                var client = await GetApiClient();

                var response = await client.GetModelGatewaysAsync();
                //var resModel = _mapper.Map<ICollection<ModelGatewayResponseModel>>(response);

                return Result<IEnumerable<ModelGatewayResponseModel>>.Success();
            }
            catch (Nswag.ApiException ex)
            {
                return Result<IEnumerable<ModelGatewayResponseModel>>.Fail(ex.Response,ex.StatusCode);
            }
            catch (Exception ex)
            {
                return Result<IEnumerable<ModelGatewayResponseModel>>.Fail(ex.Message);
            }
        }

        public async Task<Result<ModelGatewayResponseModel>> GetModelGatewayAsync(string id)
        {
            try
            {
                var client = await GetApiClient();

                var response = await client.GetModelGatewayAsync(id);
                //var resModel = _mapper.Map<ModelGatewayResponseModel>(response);

                return Result<ModelGatewayResponseModel>.Success();
            }
            catch (Nswag.ApiException ex)
            {
                return Result<ModelGatewayResponseModel>.Fail(ex.Response, ex.StatusCode);
            }
            catch (Exception ex)
            {
                return Result<ModelGatewayResponseModel>.Fail(ex.Message);
            }
        }

        public async Task<Result<ModelGatewayResponseModel>> CreateModelGatewayAsync(ModelGatewayRequest request)
        {
            try
            {
                var client = await GetApiClient();
                var model = _mapper.Map<Nswag.ModelGatewayCreateVM>(request);
                var response = await client.CreateModelGatewayAsync(model);
                var resModel = _mapper.Map<ModelGatewayResponseModel>(response);

                return Result<ModelGatewayResponseModel>.Success(resModel);
            }
            catch (Nswag.ApiException ex)
            {
                return Result<ModelGatewayResponseModel>.Fail(ex.Response, ex.StatusCode);
            }
            catch (Exception ex)
            {
                return Result<ModelGatewayResponseModel>.Fail(ex.Message);
            }
        }

        public async Task<Result<ModelGatewayResponseModel>> UpdateModelGatewayAsync( ModelGatewayRequest request)
        {
            try
            {
                var client = await GetApiClient();
                var model = _mapper.Map<Nswag.ModelGatewayUpdateVM>(request);
                var response = await client.UpdateModelGatewayAsync(request.Id,model);
                var resModel = _mapper.Map<ModelGatewayResponseModel>(response);

                return Result<ModelGatewayResponseModel>.Success(resModel);
            }
            catch (Nswag.ApiException ex)
            {
                return Result<ModelGatewayResponseModel>.Fail(ex.Response, ex.StatusCode);
            }
            catch (Exception ex)
            {
                return Result<ModelGatewayResponseModel>.Fail(ex.Message);
            }
        }

        public async Task<Result<DeleteResponse>> DeleteModelGatewayAsync(string id)
        {
            try
            {
                var client = await GetApiClient();
    
                await client.DeleteModelGatewayAsync(id);
                return Result<DeleteResponse>.Success();
            }
            catch (Nswag.ApiException ex)
            {
                return Result<DeleteResponse>.Fail(ex.Response, ex.StatusCode);
            }
            catch (Exception ex)
            {
                return Result<DeleteResponse>.Fail(ex.Message);
            }
        }

       

    }
}
