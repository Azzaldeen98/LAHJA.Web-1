using Microsoft.AspNetCore.Http;
using Shared.Constants;

namespace Shared.LocalStorage
{
    public interface ISessionStorageService: IStorageService<string>
    {
    }
    //public class SessionStorageService: ISessionStorageService
    //{
    //    private readonly ProtectedSessionStorage PSession;
    //    public async Task SaveAsync(string key,string token)
    //    {

    //        try
    //        {
    //            if (!string.IsNullOrEmpty(token))
    //            {

    //                await PSession.SetAsync(key, token);
    //            }

    //        }
    //        catch (Exception e)
    //        {
    //            Console.WriteLine(e.Message);
    //        }
    //    }
    //    public async Task<string> GetAsync(string key)
    //    {
    //        return (await PSession.GetAsync<string>(key)).Value ?? "";
    //    }
    //    public async Task DeleteAsync(string key)
    //    {
    //        try
    //        {
    //            await PSession.DeleteAsync(key);

    //        }
    //        catch (Exception e)
    //        {
    //            Console.WriteLine(e.Message);
    //        }
    //    }

        

       
    //}
}