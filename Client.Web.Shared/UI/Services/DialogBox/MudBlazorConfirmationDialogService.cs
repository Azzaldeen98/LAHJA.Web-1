using Microsoft.Extensions.Localization;
using MudBlazor;
using Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Client.Shared.UI.Services.DialogBox
{

    public class MudBlazorConfirmationDialogService : IConfirmationDialogService, ITScope
    {
        private readonly IDialogService _dialogService;

        public MudBlazorConfirmationDialogService(IDialogService dialogService)
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
            { "ContentText", message },
            { "ButtonTrueText", confirmText },
            { "ButtonFalseText", cancelText },
            { "Color", color }
        };

            var options = new DialogOptions
            {
                CloseButton = true,
                MaxWidth = maxWidth
            };

            //var dialog = _dialogService.Show<DialogBox>(title, parameters, options);
            //var result = await dialog.Result;

            //return result.Canceled == false && result.Data is bool confirmed && confirmed;

            return true;
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
