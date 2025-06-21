using Domain.Entities.Setting.Request;
using Domain.Entities.Setting.Response;
using Domain.Entities.Subscriptions.Response;
using Domain.ShareData.Base;
 using Shared.Wrapper;


namespace Domain.Repository.Setting
{
    public interface ISettingRepository
    {

        Task<Result<List<SettingResponse>>> getAllAsync();
        Task<Result<SettingResponse>> UpdateAsync(SettingUpdate request);
        Task<Result<DeleteResponse>> DeleteAsync(string id);
    }
}