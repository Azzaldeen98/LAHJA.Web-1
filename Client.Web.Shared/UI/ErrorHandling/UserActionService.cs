using Microsoft.AspNetCore.Components;
using MudBlazor;
using Shared.Constants.Router;
using System.Threading.Tasks;

namespace Client.Shared.UI.ErrorHandling
{
   

    public interface IUserActionService
    {

        public void NavigationTo(string url, Dictionary<string, object>? parametrs=null);
        public void ShowSnackBar(string message, Severity severity = Severity.Error);

        public  Task<bool?> ShowMessageBox(string title,string message, string? yesText = "", string? noText = "", string? cancelText = "");
        public  Task<bool?> ShowMessageBox(string message, string? yesText = "", string? noText = "", string? cancelText = "");


    }

    public class UserActionService : IUserActionService
    {
        private readonly NavigationManager navigation;
        private readonly ISnackbar snackbar;
        private readonly IDialogService dialog;
        public UserActionService(NavigationManager navigation, ISnackbar snackbar, IDialogService dialog)
        {
            this.navigation = navigation;
            this.snackbar = snackbar;
            this.dialog = dialog;
        }

        public void NavigationTo(string url, Dictionary<string, object>? parameters = null)
        {
            if (parameters != null && parameters.Any())
            {
                var query = string.Join("&", parameters.Select(kvp =>
                    $"{Uri.EscapeDataString(kvp.Key)}={Uri.EscapeDataString(kvp.Value?.ToString() ?? "")}"
                ));

                if (!url.Contains('?'))
                    url += "?" + query;
                else
                    url += "&" + query;
            }

            navigation.NavigateTo(url, true);
        }



        public async Task<bool?> ShowMessageBox(string message, string yesText = "", string noText = "",string cancelText="")
        {
            return await ShowMessageBox("",message, yesText,noText, cancelText);
        }

        public async Task<bool?> ShowMessageBox(string title, string message, string yesText="", string noText="",string cancelText="")
        {
            var options = new DialogOptions { FullWidth = false, MaxWidth= MaxWidth.Small }; 
           return await dialog?.ShowMessageBox(title, message,yesText: yesText, noText: noText,cancelText: cancelText, options: options);
           
        }



        public void ShowSnackBar(string message, Severity severity = Severity.Error)
        {
            snackbar?.Add(message, severity);
        }
    }






}
