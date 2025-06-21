using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Shared.Services.Notification
{

    public interface INotificationService
    {
        void ShowSuccess(string message);
        void ShowError(string message);
        void ShowInfo(string message);
        void ShowWarning(string message);
    }

    public class NotificationService : INotificationService
    {
        private readonly ISnackbar _snackbar;

        public NotificationService(ISnackbar snackbar)
        {
            _snackbar = snackbar;
        }

        public void ShowSuccess(string message)
        {
            _snackbar.Add(message, Severity.Success);
        }

        public void ShowError(string message)
        {
            _snackbar.Add(message, Severity.Error);
        }

        public void ShowInfo(string message)
        {
            _snackbar.Add(message, Severity.Info);
        }

        public void ShowWarning(string message)
        {
            _snackbar.Add(message, Severity.Warning);
        }
    }
}
