using Client.Shared.UI.Services.DialogBox;
using Shared.Interfaces;
using Shared.Wrapper;

namespace Client.Shared.Execution
{


    public interface ICancelableTaskExecutor : IDisposable,ITScope
    {
        Task<Result> RunAsync(Func<CancellationToken, Task> taskFunc);
        Task<Result<T>> RunAsync<T>(Func<CancellationToken, Task<T>> taskFunc);
        void CancelCurrentTask();
    }
    public class CancelableTaskExecutor : ICancelableTaskExecutor
    {
        private CancellationTokenSource? _cts;
        private readonly IConfirmationDialogService _confirmationDialogService;
        private readonly SemaphoreSlim _semaphore = new(1, 1);

        public CancelableTaskExecutor(IConfirmationDialogService confirmationDialogService)
        {
            _confirmationDialogService = confirmationDialogService;//?? throw new ArgumentNullException(nameof(confirmationDialogService));
        }

        public async Task<Result> RunAsync(Func<CancellationToken, Task> taskFunc)
        {
            await _semaphore.WaitAsync();
            try
            {
                if (_cts != null && !_cts.IsCancellationRequested)
                {
                    var confirmCancel = await _confirmationDialogService.ConfirmCancellationAsync();

                    if (!confirmCancel)
                        return Result.Faild("The operation was canceled by the user.");

                    CancelCurrentTask();
                }

                _cts = new CancellationTokenSource();

                //try
                //{
                    await taskFunc(_cts.Token);
                    return Result.Successed();
                //}
                //catch (OperationCanceledException)
                //{
                //    return Result.Faild("The task was canceled.");
                //}
                //catch (Exception ex)
                //{
                //    return Result.Faild($"Error: {ex.Message}");
                //}
            }
            catch 
            {
                throw;
            }
            finally
            {
                CancelCurrentTask();
                _semaphore.Release();
            }
        }

        public async Task<Result<T>> RunAsync<T>(Func<CancellationToken, Task<T>> taskFunc)
        {
            await _semaphore.WaitAsync();
            try
            {
                if (_cts != null && !_cts.IsCancellationRequested)
                {
                    var confirmCancel = await _confirmationDialogService.ConfirmCancellationAsync();

                    if (!confirmCancel)
                        return Result<T>.Fail("The operation was canceled by the user.");

                    CancelCurrentTask();
                }

                _cts = new CancellationTokenSource();

                //try
                //{
                    var result = await taskFunc(_cts.Token);
                    return Result<T>.Success(result);
                //}
                //catch (OperationCanceledException)
                //{
                //    return Result<T>.Fail("The task was canceled.");
                //}
                //catch (Exception ex)
                //{
                //    CancelCurrentTask();
                //    _semaphore.Release();
                //    //return Result<T>.Fail($"Error: {ex.Message}");
                //    throw;
                //}
            }
            catch
            {
                throw;
            }
            finally
            {
                CancelCurrentTask();
                _semaphore.Release();
            }
        }

        public void CancelCurrentTask()
        {
            if (_cts != null && !_cts.IsCancellationRequested)
            {
                try
                {
                    _cts.Cancel();
                }
                catch (ObjectDisposedException) { }
                finally
                {
                    _cts.Dispose();
                    _cts = null;
                }
            }
        }

        public void Dispose()
        {
            CancelCurrentTask();
            _semaphore.Dispose();
        }
    }


    //public interface ICancelableTaskExecutor<TDialog>
    //{

    //    Task<T> RunAsync<T>(Func<CancellationToken, Task<T>> taskFunc);
    //    Task<Result> RunAsync(Func<CancellationToken, Task> taskFunc);
    //    T GetFailureResult<T>(string message);
    //    void CancelCurrentTask();
    //    void CancelCurrentTaskWithLock();
    //}





    //public class CancelableTaskExecutor<TDialog> : ICancelableTaskExecutor<TDialog>, IDisposable where TDialog : IComponent
    //{
    //    private CancellationTokenSource? _cts;
    //    private readonly IDialogService _dialogService;
    //    private readonly object _ctsLock = new();
    //    public CancelableTaskExecutor(IDialogService dialogService)
    //    {
    //        _dialogService = dialogService;
    //    }

    //    private async Task<DialogResult> ShowDialogAsync()
    //    {
    //        var parameters = new DialogParameters
    //        {
    //            { "ContentText", "هناك عملية جارية، هل تريد إلغاءها؟" },
    //            { "ButtonTrueText", "نعم" },
    //            { "ButtonFalseText", "لا" },
    //            { "Color", Color.Warning }
    //        };

    //        var options = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.ExtraSmall };
    //        var dialog = _dialogService.Show<TDialog>("تأكيد", parameters, options);
    //        return await dialog.Result;
    //    }

    //    public async Task<Result> RunAsync(Func<CancellationToken, Task> taskFunc)
    //    {
    //        if (_cts != null && !_cts.IsCancellationRequested)
    //        {
    //            var result = await ShowDialogAsync();

    //            if (result == null)
    //                return Result<object>.Fail();
    //            else if (result.Canceled == true || result.Data is not bool confirm || !confirm)
    //                return Result<object>.Fail();

    //            CancelCurrentTask();
    //        }

    //        _cts = new CancellationTokenSource();

    //        try
    //        {
    //            await taskFunc(_cts.Token);
    //        }
    //        catch (OperationCanceledException)
    //        {
    //            // Handle cancellation gracefully if needed
    //            return Result<object>.Success("Task was canceled.");
    //        }
    //        catch (Exception ex)
    //        {
    //            // Log the exception or handle it as needed
    //            return Result<object>.Fail(ex.Message);
    //        }
    //        finally
    //        {
    //            CancelCurrentTask();
    //        }

    //        return Result<object>.Success();
    //    }


    //    public async Task<T> RunAsync<T>(Func<CancellationToken, Task<T>> taskFunc)
    //    {
    //        if (_cts != null && !_cts.IsCancellationRequested)
    //        {
    //            var result = await ShowDialogAsync();

    //            if (result == null)
    //                return GetFailureResult<T>("Dialog returned null.");
    //            else if (result.Canceled == true || result.Data is not bool confirm || !confirm)
    //                return GetFailureResult<T>("Operation cancelled by user.");

    //            CancelCurrentTask();
    //        }

    //        _cts = new CancellationTokenSource();

    //        try
    //        {
    //            return await taskFunc(_cts.Token);
    //        }
    //        finally
    //        {
    //            CancelCurrentTask();
    //        }
    //    }

    //    public T GetFailureResult<T>(string message)
    //    {
    //        var targetType = typeof(T);

    //        if (typeof(IResult).IsAssignableFrom(targetType))
    //        {
    //            // T is IResult or derived

    //            // If T is generic Result<TData>
    //            if (targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(Result<>))
    //            {
    //                var innerType = targetType.GetGenericArguments()[0];
    //                var failMethod = typeof(Result<>)
    //                    .MakeGenericType(innerType)
    //                    .GetMethod("Fail", new[] { typeof(string), typeof(int) });
    //                var failResult = failMethod.Invoke(null, new object[] { message, 0 });
    //                return (T)failResult;
    //            }
    //            else
    //            {
    //                // T is non-generic Result
    //                var failMethod = typeof(Result).GetMethod("Fail", new[] { typeof(string), typeof(int) });
    //                var failResult = failMethod.Invoke(null, new object[] { message, 0 });
    //                return (T)failResult;
    //            }
    //        }

    //        // For other types, return default
    //        return default;
    //    }


    //    public void CancelCurrentTask()
    //    {
    //        if (_cts != null && !_cts.IsCancellationRequested)
    //        {
    //            _cts.Cancel();
    //            _cts.Dispose();
    //            _cts = null;
    //        }
    //    }


    //    public void CancelCurrentTaskWithLock()
    //    {
    //        lock (_ctsLock)
    //        {
    //            CancelCurrentTask();
    //        }
    //    }
    //    public void Dispose()
    //    {
    //        CancelCurrentTask();
    //    }


    //}




}
