using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Shared.Services.DialogBox
{
    public interface IConfirmationDialogService
    {
        Task<bool?> ShowConfirmAsync(string title, string message, string confirmText = "yes", string cancelText = "no");
    }

    public interface IMessageDialogService
    {
        Task ShowMessageAsync(string title, string message);
    }


    public class ConfirmationDialogService : IConfirmationDialogService
    {
        private readonly MudBlazor.IDialogService _dialogService;

        public ConfirmationDialogService(MudBlazor.IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        public async Task<bool?> ShowConfirmAsync(string title, string message, string confirmText = "نعم", string cancelText = "لا")
        {
            var parameters = new DialogParameters
            {
                ["ContentText"] = message,
                ["ButtonText"] = confirmText,
                ["CancelButtonText"] = cancelText,
                ["Color"] = Color.Primary
            };

            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small };

            var dialog = _dialogService.Show<MudDialogConfirm>(title, parameters, options);
            var result = await dialog.Result;
            return !result.Cancelled;
        }
    }

    public class MessageDialogService : IMessageDialogService
    {
        private readonly MudBlazor.IDialogService _dialogService;

        public MessageDialogService(MudBlazor.IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        public async Task ShowMessageAsync(string title, string message)
        {
            var parameters = new DialogParameters
            {
                ["ContentText"] = message,
                ["ButtonText"] = "حسناً",
                ["Color"] = Color.Primary
            };

            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small };

            var dialog = _dialogService.Show<MudDialog>(title, parameters, options);
            await dialog.Result;
        }
    }

}
