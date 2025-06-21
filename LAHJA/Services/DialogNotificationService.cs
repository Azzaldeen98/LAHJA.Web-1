using FluentValidation;
using LAHJA.UI.Components.ServiceCard;
using MudBlazor;
using Shared.Interfaces;
using System.Diagnostics.CodeAnalysis;
using Severity = MudBlazor.Severity;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace LAHJA.Services
{

    public interface IDialogNotificationService : ITScope
    {
        Task<IDialogReference> ShowDialogAsync<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TComponent>(
          string title,
          string message,
          object? model = null,
          MaxWidth maxWidth = MaxWidth.Medium) where TComponent : IComponent;
        void ShowSnackbar(string message, Severity severity);
    }

    public class DialogNotificationService : IDialogNotificationService
    {
        private readonly IDialogService _dialogService;
        private readonly ISnackbar _snackbar;

        public DialogNotificationService(IDialogService dialogService, ISnackbar snackbar)
        {
            _dialogService = dialogService;
            _snackbar = snackbar;
        }

        public async Task<IDialogReference> ShowDialogAsync<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] TComponent>(
        string title,
        string message,
        object? model = null,
        MaxWidth maxWidth = MaxWidth.Medium)
        where TComponent : IComponent
        {
            var parameters = new DialogParameters
            {
                ["ContentText"] = message
            };

            if (model != null)
            {
                parameters["Model"] = model;
            }

            var options = new DialogOptions
            {
                CloseButton = true,
                MaxWidth = maxWidth,
                FullWidth = true
            };

            return await _dialogService.ShowAsync<TComponent>(title, parameters, options);
        }
        public void ShowSnackbar(string message, Severity severity)
        {
            _snackbar.Add(message, severity);
        }
    }

}
