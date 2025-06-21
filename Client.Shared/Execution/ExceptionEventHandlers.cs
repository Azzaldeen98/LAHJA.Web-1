using Client.Shared.UI.Services.Navigation;
using Shared.Exceptions;
using Shared.Exceptions.Base;
using Shared.Exceptions.Server;
using Shared.Exceptions.Subscription;
using MudBlazor;
using Client.Shared.UI.Services.Notification;

namespace Client.Shared.Execution
{

    public interface IExceptionEventHandlers
    {
        Task HandleBadRequest(BadRequestException ex);
        Task HandleTimeout(TimeoutExceptionApp ex);
        Task HandleInternalServerError(InternalServerException ex);
        Task HandleServiceUnavailable(ServiceUnavailableException ex);
        Task HandleTooManyRequests(TooManyRequestsException ex);
        Task HandleUnauthorized(UnauthorizedException ex);
        Task HandleForbidden(ForbiddenException ex);
        Task HandleNotFound(NotFoundException ex);
        Task HandleSubscriptionUnavailable(SubscriptionUnavailableException ex);
        Task HandleSubscriptionExpired(SubscriptionExpiredException ex);
        Task HandleBaseException(BaseExceptionApp ex);
        Task HandleGeneralException(Exception ex);
        Task HandleUnknownException(Exception ex);
    }

    public class ExceptionEventHandlers : IExceptionEventHandlers
    {
        private readonly INavigationService _navigationService;
        private readonly INotificationService _notificationService;

        public ExceptionEventHandlers(INavigationService navigationService,
                                      INotificationService notificationService)
        {
            _navigationService = navigationService;
            _notificationService = notificationService;
        }

        public async Task HandleBadRequest(BadRequestException ex)
        {
             _notificationService.ShowSuccess($"طلب خاطئ: {ex.Message}");
        }

        public async Task HandleTimeout(TimeoutExceptionApp ex)
        {
             _notificationService.ShowWarning("انتهت مهلة الاتصال. الرجاء المحاولة لاحقًا.");
        }

        public async Task HandleInternalServerError(InternalServerException ex)
        {
             _notificationService.ShowError("حدث خطأ في الخادم الداخلي.");
        }

        public async Task HandleServiceUnavailable(ServiceUnavailableException ex)
        {
             _notificationService.ShowWarning("الخدمة غير متاحة حالياً، يرجى المحاولة لاحقًا.");
        }

        public async Task HandleTooManyRequests(TooManyRequestsException ex)
        {
             _notificationService.ShowWarning("تم إرسال العديد من الطلبات، يرجى الانتظار قليلاً.");
        }

        public Task HandleUnauthorized(UnauthorizedException ex)
        {
            _navigationService.GoTo("/login");
            return Task.CompletedTask;
        }

        public async Task HandleForbidden(ForbiddenException ex)
        {
             _notificationService.ShowWarning("ليس لديك صلاحية الوصول لهذه العملية.");
        }

        public async Task HandleNotFound(NotFoundException ex)
        {
             _notificationService.ShowWarning("المورد المطلوب غير موجود.");
        }

        public async Task HandleSubscriptionUnavailable(SubscriptionUnavailableException ex)
        {
             _notificationService.ShowWarning("الاشتراك غير متاح.");
            
        }

        public async Task HandleSubscriptionExpired(SubscriptionExpiredException ex)
        {
             _notificationService.ShowWarning("انتهت صلاحية الاشتراك.");
          
        }

        public Task HandleBaseException(BaseExceptionApp ex)
        {
            // يمكن تسجيل الخطأ أو تنفيذ إجراءات أخرى
            return Task.CompletedTask;
        }

        public async Task HandleGeneralException(Exception ex)
        {
             _notificationService.ShowError("حدث خطأ غير متوقع، يرجى المحاولة لاحقًا.");
        }

        public async Task HandleUnknownException(Exception ex)
        {
             _notificationService.ShowError("حدث خطأ غير معروف.");
        }
    }
}
