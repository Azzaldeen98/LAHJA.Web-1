using Domain.ShareData;
using Infrastructure.DataSource.Seeds.Models;
using Microsoft.JSInterop;
namespace LAHJA.Helpers.Services
{
    public class SessionUserManager: ISessionUserManager
    {

        private readonly IJSRuntime _jsRuntime;

        public SessionUserManager(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }
        public async Task SaveDataAsync(string email, string password, string numberPhone)
        {
            await _jsRuntime.InvokeVoidAsync("localStorageHelper.setItem", "email", email);
            await _jsRuntime.InvokeVoidAsync("localStorageHelper.setItem", "password", password);
            await _jsRuntime.InvokeVoidAsync("localStorageHelper.setItem", "numberPhone", numberPhone);
        }

        public async Task<string> GetEmailAsync()
        {
            return  await _jsRuntime.InvokeAsync<string>("localStorageHelper.getItem", "email") ?? "";
        }
        
        public async Task StoreEmailAsync(string email)
        {
            await _jsRuntime.InvokeVoidAsync("localStorageHelper.setItem", "email", email);
        }
        public async Task SaveThemeAsync(string theme)
        {
       
                await _jsRuntime.InvokeVoidAsync("localStorageHelper.setItem", "theme", theme);

          
        }

        public async Task<string> GetThemeAsync()
        {
           return  await _jsRuntime.InvokeAsync<string>("localStorageHelper.getItem", "theme");
        }
        public async Task<UserApp> GetDataAsync()
        {
            var email = await _jsRuntime.InvokeAsync<string>("localStorageHelper.getItem", "email") ?? "";
            //var password = await _jsRuntime.InvokeAsync<string>("localStorageHelper.getItem", "password") ?? "";
            var numberPhone = await _jsRuntime.InvokeAsync<string>("localStorageHelper.getItem", "numberPhone") ?? "";
            return new UserApp { Email = email, PhoneNumber = numberPhone };
        }

        public async Task RemoveDataAsync()
        {
            await _jsRuntime.InvokeVoidAsync("localStorageHelper.removeItem", "email");
            await _jsRuntime.InvokeVoidAsync("localStorageHelper.removeItem", "password");
            await _jsRuntime.InvokeVoidAsync("localStorageHelper.removeItem", "numberPhone");
        }


    }
}
