using MudBlazor;

namespace Client.Shared.UI.Services.DialogBox
{

    public interface IMessageDialogService: IDialogServiceBase<DialogResult>
    {
         Task<DialogResult> ShowAsync(string message, string? title=null);
    }

    public class MessageDialogService : IMessageDialogService
    {
        private readonly IDialogService _dialogService;

        public MessageDialogService(IDialogService dialogService)
        {
            _dialogService = dialogService;
        }

        public async Task<DialogResult?> ShowAsync(string message, string? title = null)
        {
            var parameters = new DialogParameters
            {
                ["ContentText"] = message,
                ["ButtonText"] = "حسناً",
                ["Color"] = Color.Primary
            };

            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small };

            var dialog =await _dialogService.ShowAsync<MudDialog>(title, parameters, options);
           return await dialog.Result;
        }
    }

}
