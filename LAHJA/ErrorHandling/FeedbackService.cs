using Shared.Exceptions.Base;
using Shared.Exceptions.Server;
using Shared.Exceptions.Subscription;
using Shared.Exceptions;
using Blazorise;
using Client.Shared.UI.Services.Navigation;

namespace LAHJA.Helpers.Services
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
            await _notificationService.Success($"طلب خاطئ: {ex.Message}");
        }

        public async Task HandleTimeout(TimeoutExceptionApp ex)
        {
            await _notificationService.Warning("انتهت مهلة الاتصال. الرجاء المحاولة لاحقًا.");
        }

        public async Task HandleInternalServerError(InternalServerException ex)
        {
            await _notificationService.Error("حدث خطأ في الخادم الداخلي.");
        }

        public async Task HandleServiceUnavailable(ServiceUnavailableException ex)
        {
            await _notificationService.Warning("الخدمة غير متاحة حالياً، يرجى المحاولة لاحقًا.");
        }

        public async Task HandleTooManyRequests(TooManyRequestsException ex)
        {
            await _notificationService.Warning("تم إرسال العديد من الطلبات، يرجى الانتظار قليلاً.");
        }

        public Task HandleUnauthorized(UnauthorizedException ex)
        {
            _navigationService.GoTo("/login");
            return Task.CompletedTask;
        }

        public async Task HandleForbidden(ForbiddenException ex)
        {
            await _notificationService.Warning("ليس لديك صلاحية الوصول لهذه العملية.");
        }

        public async Task HandleNotFound(NotFoundException ex)
        {
            await _notificationService.Warning("المورد المطلوب غير موجود.");
        }

        public async Task HandleSubscriptionUnavailable(SubscriptionUnavailableException ex)
        {
            await _notificationService.Warning("الاشتراك غير متاح.");
        }

        public async Task HandleSubscriptionExpired(SubscriptionExpiredException ex)
        {
            await _notificationService.Warning("انتهت صلاحية الاشتراك.");
        }

        public Task HandleBaseException(BaseExceptionApp ex)
        {
            // يمكن تسجيل الخطأ أو تنفيذ إجراءات أخرى
            return Task.CompletedTask;
        }

        public async Task HandleGeneralException(Exception ex)
        {
            await _notificationService.Error("حدث خطأ غير متوقع، يرجى المحاولة لاحقًا.");
        }

        public async Task HandleUnknownException(Exception ex)
        {
            await _notificationService.Error("حدث خطأ غير معروف.");
        }
    }

}
