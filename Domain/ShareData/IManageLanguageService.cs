namespace Domain.ShareData
{
    public interface IManageLanguageService
    {
        Task<string> InitAsync();
        Task<string> GetLanguageAsync();
        Task<string> GetLanguageFromSessionAsync();
        Task SetLanguageInSessionAsync(LanguagesCode code);
        Task<bool> CheckIsLanguage(LanguagesCode code);
        Task SetLanguageAsync(LanguagesCode code);
        Task SetStringLanguageAsync(string culture);
    }
}
