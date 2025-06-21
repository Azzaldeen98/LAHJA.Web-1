using MudBlazor;

namespace Client.Shared.UI.Services.DialogBox
{
    public interface IConfirmationDialogService
    {
        /// <summary>
        /// يعرض حوار تأكيد ويرجع true إذا تم تأكيد الإلغاء.
        /// </summary>
        Task<bool> ConfirmCancellationAsync();
        Task<bool> ShowConfirmationAsync(
          string message,
          string title,
          string confirmText = "Yes",
          string cancelText = "No",
          Color color = Color.Warning,
          MaxWidth maxWidth = MaxWidth.ExtraSmall);
    }

}
