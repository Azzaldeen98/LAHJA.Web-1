using Shared.Exceptions.Base;
using Shared.HandlerException;
using Shared.Interfaces;

namespace Infrastructure.Share.Invoker
{
    public interface IApiInvoker: IExceptionHandler, ITScope
    {
        public bool IsShouldRetry(BaseExceptionApp ex);
        public Task<T> InvokeAsync<T>(Func<Task<T>> action, CancellationToken cancellationToken, int _maxRetries = 3);
        public Task<T> InvokeAsync<T>(Func<Task<T>> action, int _maxRetries = 3);
        public Task InvokeAsync(Func<Task> action);
        public Task InvokeAsync(Func<Task> action, CancellationToken cancellationToken);
        //public void HandleException(Exception ex, ref int attempt, int maxRetries);
        //public void HandleThrowException(string message, int stateCode, ref int attempt, int _maxRetries);
        //public void HandleHttpRequestException(HttpRequestException ex, ref int attempt, int maxRetries);
        //public void HandleTaskCanceledException(TaskCanceledException ex, ref int attempt, int maxRetries);
    }

}
