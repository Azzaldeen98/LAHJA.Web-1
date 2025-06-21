using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.Repositories.Base
{
    public interface ICreate<T>
    {
        Task<T> CreateAsync(T entity);
    }

    public interface IRead<T>
    {
        
        Task<T> GetByIdAsync(string id);
        Task<ICollection<T>> GetAllAsync();
    }

    public interface IUpdate<T>
    {
        Task<T> UpdateAsync(T entity);
    }

    public interface IDelete<T>
    {
        Task DeleteAsync(string id);
    }

    public interface IPause
    {
        Task PauseAsync(string id);
    }

    public interface IResume
    {
        Task ResumeAsync(string id);
    }

    public interface ICancel
    {
        Task CancelAsync(string id);
    }

    public interface IRenew
    {
        Task RenewAsync(string id);
    }

}
