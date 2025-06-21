
using AutoMapper;
 using Shared.Wrapper;
using Infrastructure.DataSource.Seeds;

using Shared.Settings;
using Infrastructure.DataSource.ApiClient.Payment;

using Domain.ShareData.Base;
using Domain.Repository.Setting;
using Domain.Entities.Setting.Response;
using Infrastructure.Models.Setting.Response;
using Infrastructure.Models.Setting.Request;
using Domain.Entities.Setting.Request;
using Infrastructure.Models.BaseFolder.Response;


namespace Infrastructure.Repository.Setting
{

    public class SettingRepository : ISettingRepository
    {
        private readonly SeedsPlans seedsPlans;
        private readonly SettingsApiClient SettingApiClient;
        private readonly IMapper _mapper;
        private readonly ApplicationModeService appModeService;
        public SettingRepository(
            IMapper mapper,
            SeedsPlans seedsPlans,
            ApplicationModeService appModeService,
            SettingsApiClient SettingApiClient)
        {

            //seedsPlans = new SeedsPlans();
            _mapper = mapper;
            this.seedsPlans = seedsPlans;
            this.appModeService = appModeService;

            this.SettingApiClient = SettingApiClient;
        }
      
        public async Task<Result<List<SettingResponse>>> getAllAsync()
        {
            var response = await ExecutorAppMode.ExecuteAsync<Result<List<SettingResponseModel>>>(
                 async () => await SettingApiClient.getAllAsync(),
                  async () => Result<List<SettingResponseModel>>.Success());

            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<List<SettingResponse>>(response.Data) : null;
                return Result<List<SettingResponse>>.Success(result);
            }
            else
            {
                return Result<List<SettingResponse>>.Fail(response.Messages);
            }


        }

        public async Task<Result<SettingResponse>> UpdateAsync(SettingUpdate request)
        {
            var model = _mapper.Map<SettingUpdateModel>(request);

            var response = await ExecutorAppMode.ExecuteAsync<Result<SettingResponseModel>>(
                 async () => await SettingApiClient.UpdateAsync(model),
                  async () => Result<SettingResponseModel>.Success());

            if (response.Succeeded)
            {
                var result = (response.Data != null) ? _mapper.Map<SettingResponse>(response.Data) : null;
                return Result<SettingResponse>.Success(result);
            }
            else
            {
                return Result<SettingResponse>.Fail(response.Messages);
            }



        }

    

        public async Task<Result<DeleteResponse>> DeleteAsync(string id)
        {
            var response = await ExecutorAppMode.ExecuteAsync<Result<DeleteResponseModel>>(
                 async () => await SettingApiClient.DeleteAsync(id),
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
