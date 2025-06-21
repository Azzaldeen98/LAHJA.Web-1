using AutoMapper;
using Domain.ShareData.Base;
 using Shared.Wrapper;
using Infrastructure.DataSource.ApiClient.Base;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Middlewares;
using Infrastructure.Models.BaseFolder.Response;
using Infrastructure.Models.Price.Request;
using Infrastructure.Models.Price.Response;
using Infrastructure.Models.Product.Request;
using Infrastructure.Models.Product.Response;
using Infrastructure.Models.Setting.Request;
using Infrastructure.Models.Setting.Response;
using Infrastructure.Models.Subscriptions.Request;
using Infrastructure.Nswag;
using Infrastructure.Share.Invoker;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.DataSource.ApiClient.Payment
{
    public class SettingsApiClient : BuildApiClient<SettingClient>
    {

        public SettingsApiClient(ClientFactory clientFactory, IMapper mapper, IConfiguration config, IApiInvoker apiSafelyHandler) : base(clientFactory, mapper, config, apiSafelyHandler)
        {
         
        }



        public async Task<Result<List<SettingResponseModel>>> getAllAsync()
        {
            try
            {
            
                var client = await GetApiClient();
                var response = await client.GetSettingsAsync();


                //var resModel = _mapper.Map<List<SettingResponseModel>>(response);
                //return Result<List<SettingResponseModel>>.Success(resModel);


                return Result<List<SettingResponseModel>>.Fail(this.DevelopmentMessage);

            }   
            catch (ApiException e)
            {

                return Result<List<SettingResponseModel>>.Fail(e.Response, httpCode: e.StatusCode);

            }
            catch (Exception e)
            {
                return Result<List<SettingResponseModel>>.Fail(e.Message);
            }



        }  
        
        public async Task<Result<SettingResponseModel>> UpdateAsync(SettingUpdateModel  request)
        {
            try
            {
                //var model = _mapper.Map<SettingUpdate>(request);
                var client = await GetApiClient();
                //await client.UpdateSettingAsync(request.Name,model);


                //var resModel = _mapper.Map<SubscriptionResponseModel>(response);
                return Result<SettingResponseModel>.Success();

            }
            catch (ApiException e)
            {

                return Result<SettingResponseModel>.Fail(e.Response, httpCode: e.StatusCode);

            }
            catch (Exception e)
            {
                return Result<SettingResponseModel>.Fail(e.Message);
            }



        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Result<DeleteResponseModel>> DeleteAsync(string id)
        {
            try
            {

                var client = await GetApiClient();
                //var response =

                 await client.DeleteSettingAsync(id);


                //var resModel = _mapper.Map<SubscriptionResponseModel>(response);
                //return Result<SubscriptionResponseModel>.Success(resModel);
                return Result<DeleteResponseModel>.Success();
            }
            catch (ApiException e)
            {

                return Result<DeleteResponseModel>.Fail(e.Response, httpCode: e.StatusCode);

            }
            catch (Exception e)
            {
                return Result<DeleteResponseModel>.Fail(e.Message);
            }



        }

    }
}
