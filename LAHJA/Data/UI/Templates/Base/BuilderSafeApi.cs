using AutoMapper;
using Shared.Constants.Localization;
using Shared.Exceptions.Base;
using Shared.Exceptions.Server;
using Shared.Exceptions.Subscription;
using Shared.Exceptions;
using Shared.Failures.Auth;
using Shared.Failures.Server;
using Shared.Failures.Shared.Failures.Network;
using Shared.Failures.Subscription;
using Shared.Failures;
using System.Globalization;
using System.Reflection;
using Client.Shared.Execution;
using Shared.Wrapper;

namespace LAHJA.Data.UI.Templates.Base;

//public class BuilderSafeApi<T,E> : IBuilderApi<E> 
//{
//    protected readonly IMapper Mapper;
//    protected readonly T Service;
//    public readonly LanguageCode Language;
//    private readonly ILogger<BuilderSafeApi<T,E>> _logger;

//    public BuilderSafeApi(IMapper mapper, T service)
//    {
//        Mapper = mapper;
//        Service = service;
//        Language = new LanguageCode { Code = CultureInfo.CurrentUICulture.Name ?? "en" };
   
//    }

//    public async Task<Result> InvokeAsync(Func<Task> action)
//    {
//        try
//        {
//            _logger.LogInformation($"Start Executing {action.Method.Name}");

//            await action();

//            _logger.LogInformation($"End Executing {action.Method.Name}");

//            return Result<object>.Success();
//        }
//        catch (Exception ex)
//        {
//            _logger.LogError(ex, $"Error  Executing {action.Method.Name}");

//            var failure = await HandleExceptionAsync(ex);
//            return Result<object>.Faild(failure);

//        }

//    }


//    public async Task<T> InvokeAsync<T>(Func<Task<T>> action)
//    {
//        try
//        {
//            _logger.LogInformation($"Start Executing {action.Method.Name}");

//            var result = await action();

//            _logger.LogInformation($"End Executing {action.Method.Name}");

//            return result;
//        }
//        catch (Exception ex)
//        {
//            _logger.LogError(ex, $"Error Executing {action.Method.Name}");

//            var failure = await HandleExceptionAsync(ex);

//            var typeT = typeof(T);

//            // Handle IResult (غير عام)
//            if (typeof(global::Shared.Wrapper.IResult).IsAssignableFrom(typeT) && !typeT.IsGenericType)
//            {
//                object failResult = Result.Fail(failure);
//                return (T)failResult;
//            }

//            // Handle Result<TData> (عام)
//            if (typeT.IsGenericType && typeT.GetGenericTypeDefinition() == typeof(Result<>))
//            {
//                var genericDefinition = typeT.GetGenericTypeDefinition();
//                var genericArgs = typeT.GetGenericArguments(); // T

//                var closedType = genericDefinition.MakeGenericType(genericArgs);

//                var failMethod = closedType.GetMethod(
//                    "Fail",
//                    BindingFlags.Public | BindingFlags.Static,
//                    null,
//                    new[] { typeof(Failure) },
//                    null
//                );

//                if (failMethod != null)
//                {
//                    var fail = failMethod.Invoke(null, new object[] { failure });
//                    return (T)fail;
//                }
//            }




//            // If not supported
//            throw new InvalidOperationException($"Unsupported return type: {typeT.FullName}");
//        }
//    }

//    public async Task<Failure> HandleExceptionAsync(Exception ex)
//    {


//        switch (ex)
//        {
//            case BadRequestException badEx:
//                _logger.LogError($"🟠 BadRequestException: {badEx.Message} | ErrorCode: {badEx.ErrorCode}");
//                await _errorHandlingService.HandleBadRequestErrorAsync(badEx);
//                return new BadRequestFailure(Failure.ParseStatusCode(badEx.ErrorCode), badEx.Message);

//            case TimeoutExceptionApp timeoutEx:
//                _logger.LogError($"⏱️ TimeoutExceptionApp: {timeoutEx.Message} | ErrorCode: {timeoutEx.ErrorCode}");
//                await _errorHandlingService.HandleTimeoutErrorAsync(timeoutEx);
//                return new ConnectionTimeoutFailure(timeoutEx.Message);

//            case HostNotFoundException hostNotFoundEx:
//                _logger.LogError($"⏱️ TimeoutExceptionApp: {hostNotFoundEx.Message} | ErrorCode: {hostNotFoundEx.ErrorCode}");
//                await _errorHandlingService.HandleHostNotFoundErrorAsync(hostNotFoundEx);
//                return new HostNotFoundFailure(hostNotFoundEx.Message);

//            case InternalServerException serverEx:
//                _logger.LogError($"🔥 InternalServerException: {serverEx.Message} | ErrorCode: {serverEx.ErrorCode}");
//                await _errorHandlingService.HandleInternalServerErrorAsync(serverEx);
//                return new InternalServerFailure(Failure.ParseStatusCode(serverEx.ErrorCode), serverEx.Message);

//            case ServiceUnavailableException serviceEx:
//                _logger.LogError($"🔌 ServiceUnavailableException: {serviceEx.Message} | ErrorCode: {serviceEx.ErrorCode}");
//                await _errorHandlingService.HandleServiceUnavailableErrorAsync(serviceEx);
//                return new ServiceUnavailableFailure(serviceEx.Message);

//            case TooManyRequestsException tooManyRequestsEx:
//                _logger.LogError($"🚫 TooManyRequestsException: {tooManyRequestsEx.Message} | ErrorCode: {tooManyRequestsEx.ErrorCode}");
//                await _errorHandlingService.HandleTooManyRequestsErrorAsync(tooManyRequestsEx);
//                return new TooManyRequestsFailure(tooManyRequestsEx.Message);

//            case UnauthorizedException unauthorizedEx:
//                _logger.LogError($"🔒 UnauthorizedException: {unauthorizedEx.Message} | ErrorCode: {unauthorizedEx.ErrorCode}");
//                await _errorHandlingService.HandleUnauthorizedErrorAsync(unauthorizedEx);
//                return new UnauthorizedFailure(unauthorizedEx.Message);

//            case InvalidCredentialsException invalidCredentialsExce:
//                _logger.LogError($"🔒 InvalidCredentialsException: {invalidCredentialsExce.Message} | ErrorCode: {invalidCredentialsExce.ErrorCode}");
//                return new InvalidCredentialsFailure(resourceProvider.GetAuthMessage("InvalidCredentials"));

//            case LockedOutException lockedExce:
//                _logger.LogError($"🔒 LockedOutAccountException: {lockedExce.Message} | ErrorCode: {lockedExce.ErrorCode}");
//                await _errorHandlingService.HandleLockedOutErrorAsync(lockedExce);
//                return new LockedOutFailure(resourceProvider.GetAuthMessage("TemporarilyLocked"));

//            case ForbiddenException forbiddenEx:
//                _logger.LogError($"🚫 ForbiddenException: {forbiddenEx.Message} | ErrorCode: {forbiddenEx.ErrorCode}");
//                await _errorHandlingService.HandleForbiddenErrorAsync(forbiddenEx);
//                return new ForbiddenFailure(forbiddenEx.Message);

//            case NotFoundException notFoundEx:
//                _logger.LogError($"🔍 NotFoundException: {notFoundEx.Message} | ErrorCode: {notFoundEx.ErrorCode}");
//                await _errorHandlingService.HandleNotFoundErrorAsync(notFoundEx);
//                return new NotFoundFailure(Failure.ParseStatusCode(notFoundEx.ErrorCode), notFoundEx.Message);

//            case SubscriptionUnavailableException subEx:
//                _logger.LogError($"📴 SubscriptionUnavailableException: {subEx.Message} | ErrorCode: {subEx.ErrorCode}");
//                await _errorHandlingService.HandleSubscriptionUnavailableErrorAsync(subEx);
//                return new SubscriptionUnavailableFailure(subEx.ErrorCode, subEx.Message);

//            case SubscriptionExpiredException expireEx:
//                _logger.LogError($"📅 SubscriptionExpiredException: {expireEx.Message} | ErrorCode: {expireEx.ErrorCode}");
//                await _errorHandlingService.HandleSubscriptionExpiredErrorAsync(expireEx);
//                return new SubscriptionExpiredFailure(Failure.ParseStatusCode(expireEx.ErrorCode), expireEx.Message);

//            case BaseExceptionApp baseEx:
//                _logger.LogError($"📌 BaseExceptionApp: {baseEx.Message} | ErrorCode: {baseEx.ErrorCode}");
//                int errorCode;
//                if (int.TryParse(baseEx.ErrorCode, out errorCode))
//                {
//                    return new UnknownFailure(errorCode, baseEx.Message);
//                }
//                else
//                {
//                    // تعيين كود افتراضي في حال عدم نجاح التحويل
//                    return new UnknownFailure(-1, baseEx.Message);
//                }

//            case Exception e:
//                _logger.LogError($"⚠️ General Exception: {e.Message}");
//                return new UnknownFailure(e.Message);

//            default:
//                _logger.LogError($"❓ Unknown Exception Type: {ex?.GetType().Name} - {ex?.Message}");
//                return new UnknownFailure(ex?.Message);
//        }
//    }

//    public object GetInstance() => this;
//}





