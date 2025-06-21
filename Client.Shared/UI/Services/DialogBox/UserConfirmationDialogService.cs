//using Microsoft.Extensions.Localization;
//using MudBlazor;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using UI.Components.DialogBox;

//namespace Client.Shared.UI.Services.DialogBox
//{
//    public interface IUserConfirmationProvider
//    {
//        Task<bool> ConfirmAsync(string message, string title, string confirmText, string cancelText);
//        Task<bool> ConfirmAsync(string message, string? title = null);
//    }
    //public class UserConfirmationDialogService : IUserConfirmationProvider
    //{
    //    private readonly IDialogService _dialogService;
    //    private readonly IStringLocalizer<UserConfirmationDialogService> _localizer;

    //    public ConfirmationDialogService(
    //        IDialogService dialogService,
    //        IStringLocalizer<ConfirmationDialogService> localizer)
    //    {
    //        _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
    //        _localizer = localizer ?? throw new ArgumentNullException(nameof(localizer));
    //    }

    //    public async Task<bool> ConfirmAsync(string message, string title, string confirmText, string cancelText)
    //    {
    //        var parameters = new DialogParameters
    //        {
    //            ["ContentText"] = message,
    //            ["ButtonText"] = confirmText,
    //            ["CancelButtonText"] = cancelText,
    //            ["Color"] = Color.Warning
    //        };

    //        var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small };

    //        var dialog = _dialogService.Show<ConfirmationDialog>(title, parameters, options);
    //        var result = await dialog.Result;

    //        return result.Canceled == false && result.Data is bool confirmed && confirmed;
    //    }

    //    public async Task<bool> ConfirmAsync(string message, string? title = null)
    //    {
    //        return await ConfirmAsync(
    //            message,
    //            title ?? _localizer["ConfirmationTitle"],
    //            _localizer["Yes"],
    //            _localizer["No"]
    //        );
    //    }
    //}


//}
