using Client.Shared.UI.Components.DialogBox;
using MudBlazor;



namespace Client.Shared.UI.Services.DialogBox
{

    public class ConfirmationDialogService : IConfirmationDialogService
    {
        private readonly IDialogService _dialogService;

        public ConfirmationDialogService(IDialogService dialogService)
        {
            _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
        }

        public async Task<bool> ShowConfirmationAsync(
            string message,
            string title,
            string confirmText = "Yes",
            string cancelText = "No",
            Color color = Color.Warning,
            MaxWidth maxWidth = MaxWidth.ExtraSmall)
        {
            var parameters = new DialogParameters
            {
                { "Message", message },
                { "ButtonOKLabel", confirmText },
                { "ButtonCancelLabel", cancelText },
                { "PrimaryColor", color }
            };

            var options = new DialogOptions
            {
                CloseButton = true,
                MaxWidth = maxWidth
            };

            var dialog = _dialogService.Show<ShareDialogBox>(title, parameters, options);
            var result = await dialog.Result;

            return result.Canceled == false && result.Data is bool confirmed && confirmed;

            //return true;
        }

        // اختياري: طريقة جاهزة لتأكيد الإلغاء يمكن تخصيصها من الخارج
        public Task<bool> ConfirmCancellationAsync()
        {
            // تُستخدم قيم افتراضية أو يمكن أن تُمرر من الخارج في الطبقة الأعلى
            return ShowConfirmationAsync(
                message: "Are you sure you want to cancel?",
                title: "Confirmation",
                confirmText: "Yes",
                cancelText: "No"
            );
        }
    }


}
