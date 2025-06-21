using Shared.Interfaces;

namespace Shared.LocalStorage
{
    public interface IStorageService<T> :ITBase
    {
        Task SaveAsync(string key, T value);
        Task<T> GetAsync(string key);
        Task DeleteAsync(string key);
    }
}