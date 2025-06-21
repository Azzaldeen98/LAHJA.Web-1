using AutoMapper;
 using Shared.Wrapper;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Models.BaseFolder.Response;
using Infrastructure.Models.Plans;
using Infrastructure.Models.Plans.Response;
using Infrastructure.Nswag;
using Microsoft.Extensions.Configuration;
using Domain.ShareData.Base;
using Infrastructure.DataSource.ApiClient.Base;
using Infrastructure.Middlewares;
using Infrastructure.Share.Invoker;
using Shared.Interfaces;

namespace Infrastructure.DataSource.ApiClient.Plans
{
    public class PlansApiClient:BuildApiClient<PlanClient>, ITBaseShareApiClient
    {
        public PlansApiClient(ClientFactory clientFactory, IMapper mapper, IConfiguration config, 
            IApiInvoker apiSafelyHandler) : base(clientFactory, mapper, config, apiSafelyHandler)
        {

        }


        public async Task<Result<SubscriptionPlanModel>> CreatePlanAsync(PlanCreateModel request)
        {
            try
            {
                //var model = _mapper.Map<PlanCreate>(request);

                //var client = await GetApiClient();
                //var response = null; //await client.CreatePlanAsync(model);


                //var resModel = null;// _mapper.Map<SubscriptionPlanModel>(response);
                return Result<SubscriptionPlanModel>.Success();

            }
            catch (ApiException e)
            {

                return Result<SubscriptionPlanModel>.Fail(e.Response, httpCode: e.StatusCode);

            }



        }    
        
        public async Task<Result<SubscriptionPlanModel>> UpdatePlanAsync(PlanUpdateModel request)
        {


              //return await apiSafelyHandler.InvokeAsync(async () =>
              //  {
              //      var model = _mapper.Map<PlanUpdate>(request);
              //      var client = await GetApiClient();
              //      var response= await client.Upd(request.Id, model);
              //      var resModel = _mapper.Map<SubscriptionPlanModel>(response);
              //      return Result<SubscriptionPlanModel>.Success();
              //  });

            return Result<SubscriptionPlanModel>.Success();





        } 
        public async Task<Result<DeleteResponseModel>> DeletePlanAsync(string id)
        {
    
                //var client = await GetApiClient();
                //var response = await client.DeletePlanAsync(id);

               //return await apiSafelyHandler.InvokeAsync(async () =>
               // {
               //     var client = await GetApiClient();
               //     var response = await client.DeletePlanAsync(id);
               //     var resModel = _mapper.Map<DeleteResponseModel>(response);
                 

               // });

            return Result<DeleteResponseModel>.Success();





        }
        //public async Task<Result<IEnumerable<PlansGroupModel>>> getPlansGroupAsync(FilterResponseData filter)
        //{
        //    try
        //    {

        //        var client = await GetApiClient();
        //        var response =  await client.AsGroupAsync(filter.lg);


        //        var resModel = _mapper.Map<IEnumerable<PlansGroupModel>>(response);
        //        return Result<IEnumerable<PlansGroupModel>>.Success();

        //    }
        //    catch (ApiException e)
        //    {

        //        return Result<IEnumerable<PlansGroupModel>>.Fail(e.Response, httpCode: e.StatusCode);

        //    }



        //}
        public async Task<Result<IEnumerable<SubscriptionPlanModel>>> GetPlansAsync(FilterResponseData filter)
        {
            var response= await apiSafelyHandler.InvokeAsync(async () =>
            {
                var client = await GetApiClient();
                var response = await client.GetAllPlansAsync(filter.lg);
                
                if (response == null)
                    return Result<IEnumerable<SubscriptionPlanModel>>.Success();

                //response = response.OrderBy(p => p.Amount).ToList();

                var resModel = _mapper.Map<IEnumerable<SubscriptionPlanModel>>(response);
        
                return Result<IEnumerable<SubscriptionPlanModel>>.Success(resModel);

            });

           

            return response;

            //try
            //{

            //    var client = await GetApiClient();
            //    var response = await client.AsGroupAsync(filter.lg);
            //    var response2 = response.OrderBy(p => p.Amount).ToList();


            //    if (response == null)
            //        return Result<IEnumerable<SubscriptionPlanModel>>.Success();


            //    var resModel = _mapper.Map<IEnumerable<SubscriptionPlanModel>>(response2);
            //    return Result<IEnumerable<SubscriptionPlanModel>>.Success(resModel);


            //}
            //catch (ApiException e)
            //{

            //    return Result<IEnumerable<SubscriptionPlanModel>>.Fail(e.Response,httpCode:e.StatusCode);

            //}



        }
        public async Task<Result<SubscriptionPlanModel>> GetPlanAsync(string id,string lg="en")
        {
            return await apiSafelyHandler.InvokeAsync(async () =>
            {
                var client = await GetApiClient();
                var response = await client.GetPlanByIdAsync(id, lg);
                var resModel = _mapper.Map<SubscriptionPlanModel>(response);
                return Result<SubscriptionPlanModel>.Success(resModel);

            });
            //try
            //{

            //    var client = await GetApiClient();
            //    var response = await client.GetPlanAsync(id,lg);
            //    var resModel = _mapper.Map<SubscriptionPlanModel>(response);
            //    return Result<SubscriptionPlanModel>.Success(resModel);

            //}
            //catch (ApiException e)
            //{

            //    return Result<SubscriptionPlanModel>.Fail(e.Response, httpCode: e.StatusCode);

            //}



        }
    }
}
