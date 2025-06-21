using Infrastructure.Nswag;
using Microsoft.Extensions.Logging;
using Shared.Exceptions;
using Shared.Exceptions.Base;
using Shared.Exceptions.General;
using Shared.Exceptions.Operation;
using Shared.Exceptions.Server;
using Shared.HandlerException;

namespace Infrastructure.Share.Invoker
{
    /// <summary>
    /// ResilientApiInvoker
    /// </summary>
    public class ApiInvoker: ExceptionHandler,IApiInvoker
    {
            private readonly ILogger<ApiInvoker> _logger;

            public ApiInvoker(ILogger<ApiInvoker> logger)
            {
                _logger = logger;
            }
            public async Task InvokeAsync(Func<Task> action)
            {
                await InvokeAsync<object?>(async () =>
                {
                    await action();
                    return null;
                }, CancellationToken.None);
            }
            public async Task InvokeAsync(Func<Task> action, CancellationToken cancellationToken)
            {
                await InvokeAsync<object?>(async () =>
                {
                    await action();
                    return null;
                }, cancellationToken);
            }
            public async Task<T> InvokeAsync<T>(Func<Task<T>> action, int maxRetries = 3)
            {
                return await InvokeAsync(action, CancellationToken.None, maxRetries);
            }
            public async Task<T> InvokeAsync<T>(Func<Task<T>> action, CancellationToken cancellationToken, int maxRetries = 3)
            {
                int attempt = 0;

                while (attempt < maxRetries)
                {
                    try
                    {
                        if (cancellationToken.IsCancellationRequested)
                        {
                            _logger.LogWarning($"Attempt {attempt + 1}: Operation was cancelled before starting the request.");
                            throw new OperationCanceledException(cancellationToken);
                        }

                        return await action();
                    }
                    catch (HttpRequestException ex)
                    {
                        _logger.LogWarning($"Attempt {attempt + 1}: HttpRequestException occurred.");
                        HandleHttpRequestException(ex, ref attempt, maxRetries);
                    }
                    catch (TaskCanceledException ex)
                    {
                        _logger.LogWarning($"Attempt {attempt + 1}: TaskCanceledException occurred.");
                        HandleTaskCanceledException(ex, ref attempt, maxRetries);
                    }
                    catch (OperationCanceledException)
                    {
                        _logger.LogWarning($"Attempt {attempt + 1}: Operation was cancelled during execution.");
                        throw;
                    }
                    catch (ApiException ex)
                    {
                        _logger.LogError($"Attempt {attempt + 1}: ApiException occurred: {ex.Message}", ex);
                        HandleThrowException(ex.Message, ex.StatusCode, ref attempt, maxRetries);
                    }
                    catch (IOException ex) when (ex.Message.Contains("An existing connection was forcibly closed by the remote host"))
                    {
                        _logger.LogError($"Attempt {attempt + 1}: Unexpected exception occurred: {ex.Message}", ex);
                        throw new RemoteHostClosedConnectionException("The connection was disconnected by the remote server unexpectedly.", ex);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"Attempt {attempt + 1}: Unexpected exception occurred: {ex.Message}", ex);
                        HandleException(ex, ref attempt, maxRetries);
                    }

                    if (cancellationToken.IsCancellationRequested)
                        {
                        _logger.LogWarning($"Attempt {attempt + 1}: Operation was cancelled before retry delay.");
                        throw new OperationCanceledException(cancellationToken);
                    }

                    await Task.Delay(GetRetryDelay(attempt), cancellationToken);
                }

                _logger.LogError("Max retry attempts reached.");
                throw new MaxRetryAttemptsReachedException("Max retry attempts reached.");
            }
            public void HandleException(Exception ex, ref int attempt, int maxRetries)
                {
                    _logger.LogError($"Unexpected error occurred: {ex.Message}", ex);
                    int stateCode = ExtractStateCode(ex.Message);
                    if (stateCode == -1)
                    {
                        stateCode = DetectExceptionTypeByMessage(ex.Message);
                    }
                    HandleThrowException(ex.Message, stateCode, ref attempt, maxRetries);
                }

            public void HandleTaskCanceledException(TaskCanceledException ex, ref int attempt, int maxRetries)
                {
                    if (ex.CancellationToken.IsCancellationRequested)
                    {
                        _logger.LogWarning("The task was canceled by the user or application.");
                        throw new ClientTaskCanceledException();
                    }
                    else
                    {
                        attempt++;
                        _logger.LogWarning($"Retrying request ({attempt}/{maxRetries}) due to timeout.");

                        if (attempt >= maxRetries)
                        {
                            _logger.LogError("Max retry attempts reached due to timeout.");
                            throw new TimeoutExceptionApp(ex.Message);
                        }
                    }
                }

            public void HandleHttpRequestException(HttpRequestException ex, ref int attempt, int maxRetries)
                {
                    _logger.LogError($"HttpRequestException: {ex.Message}");
                    HandleThrowException(ex.Message, (int)(ex.StatusCode ?? 0), ref attempt, maxRetries);
                }

            public void HandleThrowException(string message, int stateCode, ref int attempt, int maxRetries)
            {
                _logger.LogError($"StatusCode ({stateCode}): {message}");

                if (IsShouldRetry(GetExceptionTypeByStateCode(stateCode)))
                {
                    attempt++;
                    _logger.LogInformation($"Retry Number: {attempt}");

                    if (attempt >= maxRetries)
                    {
                        ThrowMappedException(message, stateCode);
                    }
                }
                else
                {
                    ThrowMappedException(message, stateCode);
                }
            }

            public bool IsShouldRetry(BaseExceptionApp ex)
            {
                var retryExceptions = new List<Type>
            {
                typeof(BadRequestException),
                typeof(TimeoutExceptionApp),
                typeof(HostNotFoundException),
                typeof(UnauthorizedException),
                typeof(BadGatewayException),
                typeof(InternalServerException),
                typeof(ServiceUnavailableException),
                typeof(TooManyRequestsException),
                typeof(RemoteHostClosedConnectionException)
            };

                return retryExceptions.Contains(ex.GetType());
            }

            
        }

}
