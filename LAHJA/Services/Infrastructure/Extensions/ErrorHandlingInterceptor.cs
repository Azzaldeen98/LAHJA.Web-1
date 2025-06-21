//using Castle.DynamicProxy;
//using Microsoft.Extensions.Logging;
//using Shared.Exceptions.Base;
//using Shared.Exceptions.Server;
//using Shared.Exceptions.Subscription;
//using Shared.Exceptions;
//using System.Reflection;
//using System.Threading.Tasks;



//namespace LAHJA.Services.Infrastructure.Extensions;
//public class ErrorHandlingInterceptor : IInterceptor //,ITSingleton
//{
//    private readonly ILogger<ErrorHandlingInterceptor> _logger;
//    private readonly IErrorHandlingService _errorHandlingService;

//    public ErrorHandlingInterceptor(
//        ILogger<ErrorHandlingInterceptor> logger,
//        IErrorHandlingService errorHandlingService)
//    {
//        _logger = logger;
//        _errorHandlingService = errorHandlingService;
//    }

//    public  void Intercept(IInvocation invocation)
//    {
//        _logger.LogInformation("➡️ Starting execution of {MethodName}", invocation.Method.Name);

//        if (IsAsyncMethod(invocation.Method))
//        {
//            InterceptAsync(invocation);
//        }
//        else
//        {
//            try
//            {
//                invocation.Proceed();
//                _logger.LogInformation("✅ Executed: {MethodName}", invocation.Method.Name);
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex, "❌ Error in {MethodName}", invocation.Method.Name);
//                HandleException(ex);
//            }
//        }
//    }

//    private void InterceptAsync(IInvocation invocation)
//    {
//        invocation.Proceed();

//        if (invocation.Method.ReturnType == typeof(Task))
//        {
//            invocation.ReturnValue = HandleAsync((Task)invocation.ReturnValue, invocation.Method.Name);
//        }
//        else // Task<T>
//        {
//            var returnType = invocation.Method.ReturnType.GetGenericArguments()[0];
//            var method = typeof(ErrorHandlingInterceptor)
//                .GetMethod(nameof(HandleAsyncGeneric), BindingFlags.NonPublic | BindingFlags.Instance)
//                .MakeGenericMethod(returnType);

//            invocation.ReturnValue = method.Invoke(this, new object[] { invocation.ReturnValue, invocation.Method.Name });
//        }
//    }

//    private async Task HandleAsync(Task task, string methodName)
//    {
//        try
//        {
//            await task;
//            _logger.LogInformation("✅ Executed: {MethodName}", methodName);
//        }
//        catch (Exception ex)
//        {
//            _logger.LogError(ex, "❌ Error in {MethodName}", methodName);
//            await HandleExceptionAsync(ex);
//        }
//    }

//    private async Task<T> HandleAsyncGeneric<T>(Task<T> task, string methodName)
//    {
//        try
//        {
//            var result = await task;
//            _logger.LogInformation("✅ Executed: {MethodName}", methodName);
//            return result;
//        }
//        catch (Exception ex)
//        {
//            _logger.LogError(ex, "❌ Error in {MethodName}", methodName);
//            await HandleExceptionAsync(ex);
//            return default;
//        }
//    }

//    private bool IsAsyncMethod(MethodInfo method)
//    {
//        return typeof(Task).IsAssignableFrom(method.ReturnType);
//    }
//    private void HandleException(Exception ex)
//    {
//        var syncContext = SynchronizationContext.Current;
//        if (syncContext != null)
//        {
//             Task.Run(() =>
//            {
//                syncContext.Post(async _ =>
//                {
//                  await  HandleExceptionAsync(ex);
//                }, null);
//            });
//        }
//        else
//        {
//            HandleExceptionAsync(ex);
//        }
      
//    }
//    public async Task HandleExceptionAsync(Exception ex)
//    {
//        switch (ex)
//        {
//            case BadRequestException badEx:
//                _logger.LogError($"🟠 BadRequestException: {badEx.Message} | ErrorCode: {badEx.ErrorCode}");
//                await _errorHandlingService.HandleBadRequestErrorAsync(badEx);
//                break;

//            case TimeoutExceptionApp timeoutEx:
//                _logger.LogError($"⏱️ TimeoutExceptionApp: {timeoutEx.Message} | ErrorCode: {timeoutEx.ErrorCode}");
//                await _errorHandlingService.HandleTimeoutErrorAsync(timeoutEx);
//                break;

//            case InternalServerException serverEx:
//                _logger.LogError($"🔥 InternalServerException: {serverEx.Message} | ErrorCode: {serverEx.ErrorCode}");
//                await _errorHandlingService.HandleInternalServerErrorAsync(serverEx);
//                break;

//            case ServiceUnavailableException serviceEx:
//                _logger.LogError($"🔌 ServiceUnavailableException: {serviceEx.Message} | ErrorCode: {serviceEx.ErrorCode}");
//                await _errorHandlingService.HandleServiceUnavailableErrorAsync(serviceEx);
//                break;

//            case TooManyRequestsException tooManyRequestsEx:
//                _logger.LogError($"🚫 TooManyRequestsException: {tooManyRequestsEx.Message} | ErrorCode: {tooManyRequestsEx.ErrorCode}");
//                await _errorHandlingService.HandleTooManyRequestsErrorAsync(tooManyRequestsEx);
//                break;

//            case UnauthorizedException unauthorizedEx:
//                _logger.LogError($"🔒 UnauthorizedException: {unauthorizedEx.Message} | ErrorCode: {unauthorizedEx.ErrorCode}");
//                await _errorHandlingService.HandleUnauthorizedErrorAsync(unauthorizedEx);
//                break;

//            case ForbiddenException forbiddenEx:
//                _logger.LogError($"🚫 ForbiddenException: {forbiddenEx.Message} | ErrorCode: {forbiddenEx.ErrorCode}");
//                await _errorHandlingService.HandleForbiddenErrorAsync(forbiddenEx);
//                break;

//            case NotFoundException notFoundEx:
//                _logger.LogError($"🔍 NotFoundException: {notFoundEx.Message} | ErrorCode: {notFoundEx.ErrorCode}");
//                await _errorHandlingService.HandleNotFoundErrorAsync(notFoundEx);
//                break;

//            case SubscriptionUnavailableException subEx:
//                _logger.LogError($"📴 SubscriptionUnavailableException: {subEx.Message} | ErrorCode: {subEx.ErrorCode}");
//                await _errorHandlingService.HandleSubscriptionUnavailableErrorAsync(subEx);
//                break;

//            case SubscriptionExpiredException expireEx:
//                _logger.LogError($"📅 SubscriptionExpiredException: {expireEx.Message} | ErrorCode: {expireEx.ErrorCode}");
//                await _errorHandlingService.HandleSubscriptionExpiredErrorAsync(expireEx);
//                break;

//            case BaseExceptionApp baseEx:
//                _logger.LogError($"📌 BaseExceptionApp: {baseEx.Message} | ErrorCode: {baseEx.ErrorCode}");
//                break;

//            case Exception e:
//                _logger.LogError($"⚠️ General Exception: {e.Message}");
//                break;

//            default:
//                _logger.LogError($"❓ Unknown Exception Type: {ex?.GetType().Name} - {ex?.Message}");
//                break;
//        }
//    }

//}
