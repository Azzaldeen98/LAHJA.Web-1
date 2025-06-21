using LAHJA.Data.UI.Components;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Shared.Constants;
using System.Globalization;


namespace LAHJA.ContextServices
{
    public class AppUtilityComponentService
    {
        protected readonly NavigationManager Navigation;
        protected readonly ISnackbar snackbar;

        public string lg { set => _lg = value; get => _lg; }

        private string _lg = string.IsNullOrWhiteSpace(CultureInfo.CurrentUICulture.Name)
                                 ? ConstantsApp.DEFAULT_LANGUAGE
                                 : CultureInfo.CurrentUICulture.Name;

        public AppUtilityComponentService(NavigationManager navigation, ISnackbar snackbar)
        {
            Navigation = navigation;
            this.snackbar = snackbar;
        }

        public void GoToWithReload(string url)
        {
            Navigation.NavigateTo(url, true);
        }

        public void GoTo(string url)
        {
            Navigation.NavigateTo(url);
        }


        public void ShowErrorNotify(string message)
        {

            snackbar.Add(message, severity: Severity.Error);
        }

        public void ShowSuccessNotify(string message)
        {

            snackbar.Add(message, severity: Severity.Success);
        }
        public void ShowWarningNotify(string message)
        {

            snackbar.Add(message, severity: Severity.Warning);
        }
    }


    public class AppUtilityComponent : ComponentBase
    {
        [Inject] public AppUtilityComponentService services { get; set; }
        [Inject] public MessageBox MessageBox { get; set; }

        public string lg { set => services.lg = value; get => services?.lg ?? ConstantsApp.DEFAULT_LANGUAGE; }



        public void GoToWithReload(string url)
        {
            services.GoToWithReload(url);
        }

        public void GoTo(string url)
        {
            services.GoTo(url);
        }


        public void ShowErrorNotify(string message)
        {

            services.ShowErrorNotify(message);
        }

        public void ShowSuccessNotify(string message)
        {
            services.ShowSuccessNotify(message);
        }
        public void ShowWarningNotify(string message)
        {

            services.ShowWarningNotify(message);
        }


    }
}
