
namespace Shared.LocalStorage
{
    public interface ITokenStorage : IStorageService<string>
    {

    }
    public class TokenStorage : ITokenStorage
    {
        public TokenStorage()
        {
        }

        public Task DeleteAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(string key, string value)
        {
            throw new NotImplementedException();
        }
    }

}