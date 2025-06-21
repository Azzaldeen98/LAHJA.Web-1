using Shared.Exceptions;
using Shared.Exceptions.Base;
using Shared.Exceptions.Server;
using Shared.Exceptions.Subscription;


namespace Client.Shared.Execution
{

   
    public interface IExceptionEventDispatcher
    {
        event Func<BadRequestException, Task>? BadRequestOccurred;
        event Func<TimeoutExceptionApp, Task>? TimeoutOccurred;
        event Func<InternalServerException, Task>? InternalServerErrorOccurred;
        event Func<ServiceUnavailableException, Task>? ServiceUnavailableOccurred;
        event Func<TooManyRequestsException, Task>? TooManyRequestsOccurred;
        event Func<UnauthorizedException, Task>? UnauthorizedOccurred;
        event Func<ForbiddenException, Task>? ForbiddenOccurred;
        event Func<NotFoundException, Task>? NotFoundOccurred;
        event Func<SubscriptionUnavailableException, Task>? SubscriptionUnavailableOccurred;
        event Func<SubscriptionExpiredException, Task>? SubscriptionExpiredOccurred;
        event Func<BaseExceptionApp, Task>? BaseExceptionOccurred;
        event Func<Exception, Task>? GeneralExceptionOccurred;
        event Func<Exception, Task>? UnknownExceptionOccurred;
    }


    public class ExceptionEventDispatcher: IExceptionEventDispatcher
    {
        // تعريف الأحداث مع تمرير Exception والمعلومات الإضافية إذا احتجنا
        public event Func<BadRequestException, Task>? BadRequestOccurred;
        public event Func<TimeoutExceptionApp, Task>? TimeoutOccurred;
        public event Func<InternalServerException, Task>? InternalServerErrorOccurred;
        public event Func<ServiceUnavailableException, Task>? ServiceUnavailableOccurred;
        public event Func<TooManyRequestsException, Task>? TooManyRequestsOccurred;
        public event Func<UnauthorizedException, Task>? UnauthorizedOccurred;
        public event Func<ForbiddenException, Task>? ForbiddenOccurred;
        public event Func<NotFoundException, Task>? NotFoundOccurred;
        public event Func<SubscriptionUnavailableException, Task>? SubscriptionUnavailableOccurred;
        public event Func<SubscriptionExpiredException, Task>? SubscriptionExpiredOccurred;
        public event Func<BaseExceptionApp, Task>? BaseExceptionOccurred;
        public event Func<Exception, Task>? GeneralExceptionOccurred;
        public event Func<Exception, Task>? UnknownExceptionOccurred;

        // طريقة عامة لرفع الأحداث حسب نوع الاستثناء
        public async Task DispatchAsync(Exception ex)
        {
            switch (ex)
            {
                case BadRequestException badEx:
                    if (BadRequestOccurred != null) 
                        await BadRequestOccurred.Invoke(badEx);
                    break;

                case TimeoutExceptionApp timeoutEx:
                    if (TimeoutOccurred != null) 
                        await TimeoutOccurred.Invoke(timeoutEx);
                    break;

                case InternalServerException serverEx:
                    if (InternalServerErrorOccurred != null) 
                        await InternalServerErrorOccurred.Invoke(serverEx);
                    break;

                case ServiceUnavailableException serviceEx:
                    if (ServiceUnavailableOccurred != null) 
                        await ServiceUnavailableOccurred.Invoke(serviceEx);
                    break;

                case TooManyRequestsException tooManyRequestsEx:
                    if (TooManyRequestsOccurred != null) 
                        await TooManyRequestsOccurred.Invoke(tooManyRequestsEx);
                    break;

                case UnauthorizedException unauthorizedEx:
                    if (UnauthorizedOccurred != null) 
                        await UnauthorizedOccurred.Invoke(unauthorizedEx);
                    break;

                case ForbiddenException forbiddenEx:
                    if (ForbiddenOccurred != null) 
                        await ForbiddenOccurred.Invoke(forbiddenEx);
                    break;

                case NotFoundException notFoundEx:
                    if (NotFoundOccurred != null) 
                        await NotFoundOccurred.Invoke(notFoundEx);
                    break;

                case SubscriptionUnavailableException subEx:
                    if (SubscriptionUnavailableOccurred != null) 
                        await SubscriptionUnavailableOccurred.Invoke(subEx);
                    break;

                case SubscriptionExpiredException expireEx:
                    if (SubscriptionExpiredOccurred != null) 
                        await SubscriptionExpiredOccurred.Invoke(expireEx);
                    break;

                case BaseExceptionApp baseEx:
                    if (BaseExceptionOccurred != null) 
                        await BaseExceptionOccurred.Invoke(baseEx);
                    break;

                case Exception e:
                    if (GeneralExceptionOccurred != null) 
                        await GeneralExceptionOccurred.Invoke(e);
                    break;

                default:
                    if (UnknownExceptionOccurred != null) 
                        await UnknownExceptionOccurred.Invoke(ex);
                    break;
            }
        }
    }
}
