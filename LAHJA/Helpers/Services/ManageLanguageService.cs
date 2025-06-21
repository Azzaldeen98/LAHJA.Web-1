using ApexCharts;
using Blazorise;
using Domain.ShareData;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.JSInterop;
using Shared.Constants;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
namespace LAHJA.Helpers.Services
{



    public class LanguageService
    {
        public event Action<string> OnLanguageChanged;
        private string _currentLanguage = "ar";
     
        public string CurrentLanguage
        {
            get => _currentLanguage;
            set
            {
                if (_currentLanguage != value)
                {
                    _currentLanguage = value;
                    NotifyLanguageChanged(_currentLanguage);
                }
            }
        }

        private void NotifyLanguageChanged(string langCode)
        {

            if (langCode == "ar")
            {
                CultureInfo.CurrentCulture = new CultureInfo("ar");
                CultureInfo.CurrentUICulture = new CultureInfo("ar");
            }
            else
            {
                CultureInfo.CurrentCulture = new CultureInfo("en");
                CultureInfo.CurrentUICulture = new CultureInfo("en");
            }
            //OnLanguageChanged?.Invoke(langCode);


        }
    }




    public class ManageLanguageService: IManageLanguageService { 

        private readonly ProtectedSessionStorage PSession;
   
        private readonly IJSRuntime _jsRuntime;
        private Semaphore semaphore = new Semaphore(1, 1);
        public ManageLanguageService(IJSRuntime jsRuntime, ProtectedSessionStorage pSession)
        {
            _jsRuntime = jsRuntime;
            PSession = pSession;
        }

        public  async Task SetLanguageInSessionAsync(LanguagesCode code)
        {
            await PSession.SetAsync(ConstantsApp.LANGUAGE_STORAGE, (code.ToString().ToLower()));
        }
        public  async Task<string> GetLanguageFromSessionAsync()
        {

            var response = await PSession.GetAsync<string>(ConstantsApp.LANGUAGE_STORAGE);
           return response.Value??"ar";

        }
        public  async Task<string> GetLanguageAsync()
        {

    
            try
            {
                //semaphore.WaitOne();
                var lang= await _jsRuntime.InvokeAsync<string>("localStorageHelper.getItem", ConstantsApp.LANGUAGE_STORAGE) ?? LanguagesCode.EN.ToString().ToLower();
                changeLanguageApp(lang=="ar"? LanguagesCode.AR: LanguagesCode.EN);
                return lang;
            }
            catch (Exception ex)
            {
                return LanguagesCode.AR.ToString().ToLower();
            }
            finally
            {
                //semaphore.Release();
            }
        }
        public  async Task<bool> CheckIsLanguage(LanguagesCode code)
        {
         
            var lang = await GetLanguageAsync();
            if (!string.IsNullOrEmpty(lang))
            {

                changeLanguageApp(lang == "ar" ? LanguagesCode.AR : LanguagesCode.EN);
                return (lang.ToLower() == code.ToString().ToLower());
            }
            return false;   
        }
        public async Task SetLanguageAsync(LanguagesCode code)
        {
            if (code != null)
            {
                try
                {
                    semaphore.WaitOne();
                    await SetLanguageInSessionAsync(code);

                    await _jsRuntime.InvokeVoidAsync("localStorageHelper.setItem", ConstantsApp.LANGUAGE_STORAGE, (code.ToString().ToLower()));
                    changeLanguageApp(code);
                    //await _jsRuntime.InvokeVoidAsync("reloadPage");
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    semaphore.Release();
                }
            }
        }
        
        public async Task SetStringLanguageAsync(string culture)
        {
            if (!string.IsNullOrEmpty(culture))
            {
                try
                {
                    semaphore.WaitOne();
                    await _jsRuntime.InvokeVoidAsync("localStorageHelper.setItem", ConstantsApp.LANGUAGE_STORAGE, culture);
                    await PSession.SetAsync(ConstantsApp.LANGUAGE_STORAGE, culture);
                    //await _jsRuntime.InvokeVoidAsync("reloadPage");
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    semaphore.Release();
                }
            }
        }

        private void changeLanguageApp(LanguagesCode code)
            {


         

            if (code == LanguagesCode.AR)
                {
                    CultureInfo.CurrentCulture = new CultureInfo("ar");
                    CultureInfo.CurrentUICulture = new CultureInfo("ar");
                }
                else
                {
                    CultureInfo.CurrentCulture = new CultureInfo("en");
                    CultureInfo.CurrentUICulture = new CultureInfo("en");
                }
            }

        public async Task<string> InitAsync()
        {
            var lang = await GetLanguageAsync();
            if (!string.IsNullOrEmpty(lang))
            {
                var lg = lang == "ar" ? LanguagesCode.AR : LanguagesCode.EN;
                await SetLanguageInSessionAsync(lg);

            }

            return lang;
        }
    }
}
