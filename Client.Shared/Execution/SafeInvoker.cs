using Microsoft.Extensions.Logging;
using Shared.Exceptions.Base;
using Shared.Exceptions.Server;
using Shared.Exceptions.Subscription;
using Shared.Exceptions;
using Shared.Interfaces;
using Shared.Wrapper;
using Client.Shared.UI.ErrorHandling;
using Shared.Failures.Shared.Failures.Network;
using Shared.Failures.Server;
using Shared.Failures.Auth;
using Shared.Failures.Subscription;
using Shared.Failures;
using System.Reflection;
using Client.Shared.Providers;



namespace Client.Shared.Execution
{

    public interface ISafeInvoker: ITScope
    {
        // This interface is used to safely invoke methods and handle exceptions.
        // It provides methods to execute actions and return results, while logging the process.
        // The HandleExceptionAsync method is used to handle exceptions that occur during the invocation.
        // The InvokeAsync method can be used for both synchronous and asynchronous actions.
    
        Task<T> InvokeAsync<T>(Func<Task<T>> action);
        //public Task<Result<T>> InvokeAsync<T>(Func<Task<T>> action);
        Task<Result> InvokeAsync(Func<Task> action);
        Task<Either<Failure, T>> InvokeEtherAsync<T>(Func<Task<T>> action);
        Task<Failure> HandleExceptionAsync(Exception ex);
    }

    public class SafeInvoker : ISafeInvoker
    {
        private readonly ILogger<ISafeInvoker> _logger;



        public readonly IErrorHandlingService _errorHandlingService;
        public readonly ResourceProvider resourceProvider;

        public SafeInvoker(ILogger<ISafeInvoker> logger,
            IErrorHandlingService errorHandlingService)
        {
            _logger = logger;
            _errorHandlingService = errorHandlingService;
             resourceProvider=new ResourceProvider();
        }

        public  async Task<Result> InvokeAsync(Func<Task> action)
        {
            try
            {
                _logger.LogInformation($"Start Executing {action.Method.Name}");

                await action();

                _logger.LogInformation($"End Executing {action.Method.Name}");

                return Result<object>.Success();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,$"Error  Executing {action.Method.Name}");

              var failure=  await HandleExceptionAsync(ex);
               return Result<object>.Faild(failure); 

            }

        }
        //public async Task<T> InvokeAsync<T>(Func<Task<T>> action)
        //{

        //    try
        //    {
        //        _logger.LogInformation($"Start Executing {action.Method.Name}");

        //        var result = await action();

        //        _logger.LogInformation($"End Executing {action.Method.Name}");
        //        return result;

        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, $"Error  Executing {action.Method.Name}");
        //        await HandleExceptionAsync(ex);
        //        throw;

        //    }



        //}

        public async Task<T> InvokeAsync<T>(Func<Task<T>> action)
        {
            try
            {
                _logger.LogInformation($"Start Executing {action.Method.Name}");

                var result = await action();

                _logger.LogInformation($"End Executing {action.Method.Name}");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error Executing {action.Method.Name}");

                var failure = await HandleExceptionAsync(ex);

                var typeT = typeof(T);

                // Handle IResult (غير عام)
                if (typeof(IResult).IsAssignableFrom(typeT) && !typeT.IsGenericType)
                {
                    object failResult = Result.Fail(failure);
                    return (T)failResult;
                }

                // Handle Result<TData> (عام)
                if (typeT.IsGenericType && typeT.GetGenericTypeDefinition() == typeof(Result<>))
                {
                    var genericDefinition = typeT.GetGenericTypeDefinition();
                    var genericArgs = typeT.GetGenericArguments(); // T

                    var closedType = genericDefinition.MakeGenericType(genericArgs);

                    var failMethod = closedType.GetMethod(
                        "Fail",
                        BindingFlags.Public | BindingFlags.Static,
                        null,
                        new[] { typeof(Failure) },
                        null
                    );

                    if (failMethod != null)
                    {
                        var fail = failMethod.Invoke(null, new object[] { failure });
                        return (T)fail;
                    }
                }


                //var failMethod = typeT.GetMethod(
                //    "Fail",
                //    BindingFlags.Public | BindingFlags.Static,
                //    null,
                //    new[] { typeof(Failure) },
                //    null
                //);

                // If not supported
                throw new InvalidOperationException($"Unsupported return type: {typeT.FullName}");
            }
        }

        //public async Task<T> InvokeAsync<T>(Func<Task<T>> action)
        //{
        //    try
        //    {
        //        _logger.LogInformation($"Start Executing {action.Method.Name}");

        //        var result = await action();

        //        _logger.LogInformation($"End Executing {action.Method.Name}");

        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, $"Error Executing {action.Method.Name}");

        //        var failure = await HandleExceptionAsync(ex);

        //        var typeT = typeof(T);

        //        // Handle IResult
        //        if (typeof(IResult).IsAssignableFrom(typeT))
        //        {
        //            object failResult = Result.Fail(failure);
        //            return (T)failResult;
        //        }

        //        // Handle Result<TData>
        //        if (typeT.IsGenericType && typeT.GetGenericTypeDefinition() == typeof(Result<>))
        //        {
        //            var innerType = typeT.GetGenericArguments()[0];

        //            // Try to get static method Fail(Failure)
        //            var failMethod = typeT.GetMethod(
        //                "Fail",
        //                BindingFlags.Public | BindingFlags.Static,
        //                null,
        //                new[] { typeof(Failure) },
        //                null
        //            );

        //            if (failMethod != null)
        //            {
        //                var fail = failMethod.Invoke(null, new object[] { failure });
        //                return (T)fail;
        //            }
        //        }

        //        // Not supported type
        //        throw;
        //    }
        //}

        public async Task<T> InvokeAsync2<T>(Func<Task<T>> action)
        {
            try
            {
                _logger.LogInformation($"Start Executing {action.Method.Name}");

                var result = await action();

                _logger.LogInformation($"End Executing {action.Method.Name}");

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error Executing {action.Method.Name}");
                var failure = await HandleExceptionAsync(ex);

                // إذا كان T هو IResult أو Result نعيد رسالة فشل
                if (typeof(IResult).IsAssignableFrom(typeof(T)))
                {
                    var failResult = Result.Fail($"An error occurred: {ex.Message}");
                    return (T)failResult;
                }

                // أو إذا كان T هو Result<TData>
                var resultType = typeof(T);
                if (resultType.IsGenericType && resultType.GetGenericTypeDefinition() == typeof(Result<>))
                {
                    var innerType = resultType.GetGenericArguments()[0];
                    var genericFail = typeof(Result<>)
                        .MakeGenericType(innerType)
                        .GetMethod(nameof(Result<object>.Fail), new[] { typeof(string), typeof(int) });

                    var fail = genericFail.Invoke(null, new object[] { $"An error occurred: {ex.Message}", 0 });
                    return (T)fail;
                }

                throw; // في حال النوع غير مدعوم، نرمي الخطأ
            }
        }
        public async Task<Either<Failure, T>> InvokeEtherAsync<T>(Func<Task<T>> action)
        {
            try
            {
                _logger.LogInformation($"Start Executing {action.Method.Name}");

                var result = await action();

                _logger.LogInformation($"End Executing {action.Method.Name}");

                return Either<Failure, T>.Right(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error Executing {action.Method.Name}");
                await HandleExceptionAsync(ex);

                // إذا كان T هو نوع IResult أو Result، نفترض أن Result يحتوي على خاصية Failure
                if (typeof(IResult).IsAssignableFrom(typeof(T)))
                {
                    var failResult = Result.Fail($"An error occurred: {ex.Message}");

                    // نُرجع الفشل في الـ Left
                    return Either<Failure, T>.Left(new UnknownFailure(ex.Message));
                }

                var resultType = typeof(T);
                if (resultType.IsGenericType && resultType.GetGenericTypeDefinition() == typeof(Result<>))
                {
                    var innerType = resultType.GetGenericArguments()[0];
                    // هنا ممكن تنشئ UnknownFailure أو أي فشل مناسب
                    return Either<Failure, T>.Left(new UnknownFailure(ex.Message));
                }

                // نوع غير معروف، نرمي الخطأ
                throw;
            }
        }



        //public  async Task<Result<T>> InvokeAsync<T>(Func<Task<T>> action)
        //{

        //    try
        //    {
        //        _logger.LogInformation($"Start Executing {action.Method.Name}");

        //         var result= await action();

        //        _logger.LogInformation($"End Executing {action.Method.Name}");
        //        return Result<T>.Success(result);

        //    }
        //    catch(Exception ex)
        //    {
        //        _logger.LogError(ex, $"Error  Executing {action.Method.Name}");
        //        await HandleExceptionAsync(ex);
        //        return Result<T>.Fail(ex.Message);

        //    }



        //}

        public async Task<Failure> HandleExceptionAsync(Exception ex)
        {
        

            switch (ex)
            {
                case BadRequestException badEx:
                    _logger.LogError($"🟠 BadRequestException: {badEx.Message} | ErrorCode: {badEx.ErrorCode}");
                    await _errorHandlingService.HandleBadRequestErrorAsync(badEx);
                    return new BadRequestFailure(Failure.ParseStatusCode(badEx.ErrorCode), badEx.Message);

                case TimeoutExceptionApp timeoutEx:
                    _logger.LogError($"⏱️ TimeoutExceptionApp: {timeoutEx.Message} | ErrorCode: {timeoutEx.ErrorCode}");
                    await _errorHandlingService.HandleTimeoutErrorAsync(timeoutEx);
                    return new ConnectionTimeoutFailure(timeoutEx.Message);
                case HostNotFoundException hostNotFoundEx:
                    _logger.LogError($"⏱️ TimeoutExceptionApp: {hostNotFoundEx.Message} | ErrorCode: {hostNotFoundEx.ErrorCode}");
                    await _errorHandlingService.HandleHostNotFoundErrorAsync(hostNotFoundEx);
                    return new HostNotFoundFailure(hostNotFoundEx.Message);

                case InternalServerException serverEx:
                    _logger.LogError($"🔥 InternalServerException: {serverEx.Message} | ErrorCode: {serverEx.ErrorCode}");
                    await _errorHandlingService.HandleInternalServerErrorAsync(serverEx);
                    return new InternalServerFailure(Failure.ParseStatusCode(serverEx.ErrorCode),serverEx.Message);

                case ServiceUnavailableException serviceEx:
                    _logger.LogError($"🔌 ServiceUnavailableException: {serviceEx.Message} | ErrorCode: {serviceEx.ErrorCode}");
                    await _errorHandlingService.HandleServiceUnavailableErrorAsync(serviceEx);
                    return new ServiceUnavailableFailure(serviceEx.Message);
                    
                case TooManyRequestsException tooManyRequestsEx:
                    _logger.LogError($"🚫 TooManyRequestsException: {tooManyRequestsEx.Message} | ErrorCode: {tooManyRequestsEx.ErrorCode}");
                    await _errorHandlingService.HandleTooManyRequestsErrorAsync(tooManyRequestsEx);
                    return new TooManyRequestsFailure(tooManyRequestsEx.Message);

                case UnauthorizedException unauthorizedEx:
                    _logger.LogError($"🔒 UnauthorizedException: {unauthorizedEx.Message} | ErrorCode: {unauthorizedEx.ErrorCode}");
                    await _errorHandlingService.HandleUnauthorizedErrorAsync(unauthorizedEx);
                    return new UnauthorizedFailure(unauthorizedEx.Message);     
                    
                case InvalidCredentialsException invalidCredentialsExce:
                    _logger.LogError($"🔒 InvalidCredentialsException: {invalidCredentialsExce.Message} | ErrorCode: {invalidCredentialsExce.ErrorCode}");
                    return new InvalidCredentialsFailure(resourceProvider.GetAuthMessage("InvalidCredentials"));                
                
                case LockedOutException lockedExce:
                    _logger.LogError($"🔒 LockedOutAccountException: {lockedExce.Message} | ErrorCode: {lockedExce.ErrorCode}");
                    await _errorHandlingService.HandleLockedOutErrorAsync(lockedExce);
                    return new LockedOutFailure(resourceProvider.GetAuthMessage("TemporarilyLocked"));
                   
                case ForbiddenException forbiddenEx:
                    _logger.LogError($"🚫 ForbiddenException: {forbiddenEx.Message} | ErrorCode: {forbiddenEx.ErrorCode}");
                    await _errorHandlingService.HandleForbiddenErrorAsync(forbiddenEx);
                    return new ForbiddenFailure(forbiddenEx.Message);

                case NotFoundException notFoundEx:
                    _logger.LogError($"🔍 NotFoundException: {notFoundEx.Message} | ErrorCode: {notFoundEx.ErrorCode}");
                    await _errorHandlingService.HandleNotFoundErrorAsync(notFoundEx);
                    return new NotFoundFailure(Failure.ParseStatusCode(notFoundEx.ErrorCode), notFoundEx.Message);

                case SubscriptionUnavailableException subEx:
                    _logger.LogError($"📴 SubscriptionUnavailableException: {subEx.Message} | ErrorCode: {subEx.ErrorCode}");
                    await _errorHandlingService.HandleSubscriptionUnavailableErrorAsync(subEx);
                    return new SubscriptionUnavailableFailure(subEx.ErrorCode,subEx.Message);

                case SubscriptionExpiredException expireEx:
                    _logger.LogError($"📅 SubscriptionExpiredException: {expireEx.Message} | ErrorCode: {expireEx.ErrorCode}");
                    await _errorHandlingService.HandleSubscriptionExpiredErrorAsync(expireEx);
                    return new SubscriptionExpiredFailure(Failure.ParseStatusCode(expireEx.ErrorCode), expireEx.Message);

                case BaseExceptionApp baseEx:
                    _logger.LogError($"📌 BaseExceptionApp: {baseEx.Message} | ErrorCode: {baseEx.ErrorCode}");
                    int errorCode;
                    if (int.TryParse(baseEx.ErrorCode, out errorCode))
                    {
                        return new UnknownFailure(errorCode, baseEx.Message);
                    }
                    else
                    {
                        // تعيين كود افتراضي في حال عدم نجاح التحويل
                        return new UnknownFailure(-1, baseEx.Message);
                    }

                case Exception e:
                    _logger.LogError($"⚠️ General Exception: {e.Message}");
                    return new UnknownFailure(e.Message);

                default:
                    _logger.LogError($"❓ Unknown Exception Type: {ex?.GetType().Name} - {ex?.Message}");
                    return new UnknownFailure(ex?.Message);
            }
        }

   
    }
}
