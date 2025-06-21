using AutoMapper;
using Domain.Entities.Profile;
using Domain.Entities.Profile.Request;
using Domain.Entities.Profile.Response;
using Domain.Exceptions;
 using Shared.Wrapper;
using Infrastructure.DataSource.ApiClient.Base;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Middlewares;
using Infrastructure.Models.Plans;
using Infrastructure.Models.Profile.Response;
using Infrastructure.Models.Request.Response;
using Infrastructure.Nswag;
using Infrastructure.Share.Invoker;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataSource.ApiClient.Profile
{
    public class ProfileApiClient: BuildApiClient<ProfileClient>
    {


        public ProfileApiClient(ClientFactory clientFactory, IMapper mapper, IConfiguration config, IApiInvoker apiSafelyHandler)
            : base(clientFactory, mapper, config, apiSafelyHandler)
        {

        }

        public async Task<Result<ProfileUserResponse>> GetProfileUserAsync()
        {
            try
            {

                var client = await GetApiClient();
                var response = await client.GetUserAsync();
                //var resModel = _mapper.Map<ProfileUserResponse>(response);
                    return Result<ProfileUserResponse>.Success();

            }
            catch (ApiException e)
            {

                return Result<ProfileUserResponse>.Fail(e.Response, e.StatusCode);

            }
            catch (Exception e)
            {

                return Result<ProfileUserResponse>.Fail(e.Message);

            }



        }
        public async Task<Result<ProfileResponseModel>> getProfileAsync()
        {
            try
            {

                var client = await GetApiClient(); 
                var response = await client.GetUserAsync();
                var resModel = _mapper.Map<ProfileResponseModel>(response);
                return Result<ProfileResponseModel>.Success();

            }
            catch (ApiException e)
            {

                return Result<ProfileResponseModel>.Fail(e.Response,e.StatusCode);

            }
            catch (Exception e)
            {

                return Result<ProfileResponseModel>.Fail(e.Message);

            }



        }
        public async Task<Result<ProfileUserResponse>> UpdateProfileUserAsync(ProfileUserRequest request)
        {
            try
            {
                var model = _mapper.Map<ApplicationUserUpdateVM>(request);
                var client = await GetApiClient();
                await client.UpdateAsync(model);
            
                return Result<ProfileUserResponse>.Success();

            }
            catch (ApiException e)
            {

                return Result<ProfileUserResponse>.Fail(e.Response, e.StatusCode);

            }
            catch (Exception e)
            {

                return Result<ProfileUserResponse>.Fail(e.Message);

            }



        }
        public  async  Task<ICollection<ProfileSubscriptionResponse>> SubscriptionsAsync()
        {
            try
            {
                var client = await GetApiClient();
           
                var response = await client.GetUserSubscriptionsAsync();
               
           
                //var response = await client.SubscriptionsAsync();
                //var resModel = _mapper.Map<ICollection<ProfileSubscriptionResponse>>(response);

                return new List<ProfileSubscriptionResponse>();
            }
            catch (ApiException e)
            {
                throw new ServerException(e.Message, e.StatusCode);
            }
      

        }

        public async Task<ICollection<ProfileModelAiResponse>> ModelAisAsync()
        {
            try
            {
                var client = await GetApiClient();

                var response = await client.ModelAisAsync();
                var resModel = _mapper.Map<ICollection<ProfileModelAiResponse>>(response);

                return resModel;
            }
            catch (ApiException e)
            {
                throw new ServerException(e.Message, e.StatusCode);
            }
        

        }

        public async Task<ICollection<ProfileServiceResponse>> ServicesAsync()
        {
            try
            {
                var client = await GetApiClient();

                var response = await client.ServicesAsync();
                var resModel = _mapper.Map<ICollection<ProfileServiceResponse>>(response);

                return resModel;
            }
            catch (ApiException e)
            {
                throw new ServerException(e.Message, e.StatusCode);
            }
     
         

        }

        public async Task<ICollection<ProfileServiceResponse>> ServicesModelAiAsync(string modelAiId)
        {

            try 
            { 

                var client = await GetApiClient();

                //var response = await client.ServicesModelAiAsync(modelAiId);
                //var resModel = _mapper.Map<ICollection<ProfileServiceResponse>>(response);

            return new List<ProfileServiceResponse>();
            }
            catch (ApiException e)
            {
                throw new ServerException(e.Message, e.StatusCode);
            }


    
       

        }

        public async Task<ICollection<ProfileSpaceResponse>> SpacesSubscriptionAsync(string subscriptionId)
        {

            try
            {

                var client = await GetApiClient();
    
                 var response = await client.SpacesSubscriptionAsync(subscriptionId);
         
              
                var resModel = _mapper.Map<ICollection<ProfileSpaceResponse>>(response);

                return resModel;
            }
            catch (ApiException e)
            {
                throw new ServerException(e.Message, e.StatusCode);
            }

        }


        public async Task<ProfileSpaceResponse> SpaceSubscriptionAsync(string subscriptionId, string spaceId)
        {

            try
            {
                var client = await GetApiClient();

                var response = await client.SpaceSubscriptionAsync(subscriptionId, spaceId);
                var resModel = _mapper.Map<ProfileSpaceResponse>(response);

                return resModel;
            }
            catch (ApiException e)
            {
                throw new ServerException(e.Message, e.StatusCode);
            }

        }



        public async Task<ICollection<RequestResponseModel>> RequestsServiceAsync(string serviceId)
        {

            try
            {
                var client = await GetApiClient();

                var response = await client.RequestsServiceAsync(serviceId);
                return _mapper.Map<ICollection<RequestResponseModel>>(response);
            }
            catch (ApiException e)
            {
                throw new ServerException(e.Message, e.StatusCode);
            }

        }

    }
}
