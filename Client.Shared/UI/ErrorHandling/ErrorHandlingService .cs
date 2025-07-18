﻿using Client.Shared.Helpers;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Shared.Constants.Router;
using Shared.Exceptions;
using Shared.Exceptions.Server;
using Shared.Exceptions.Subscription;
using System.Collections;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace Client.Shared.UI.ErrorHandling
{
    public interface IErrorHandlingService
    {
        public Task HandleExceptionAsync(Exception ex);
        public Task HandleUnauthorizedErrorAsync(UnauthorizedException ex);
        public Task HandleLockedOutErrorAsync(LockedOutException ex);
        public Task HandleServiceUnavailableErrorAsync(ServiceUnavailableException ex);
        public Task HandleInternalServerErrorAsync(InternalServerException ex);
        public Task HandleTooManyRequestsErrorAsync(TooManyRequestsException ex);
        public Task HandleForbiddenErrorAsync(ForbiddenException ex);
        public Task HandleSubscriptionUnavailableErrorAsync(SubscriptionUnavailableException? ex=null);
        public Task HandleSubscriptionExpiredErrorAsync(SubscriptionExpiredException ex);
        public Task HandleTimeoutErrorAsync(TimeoutExceptionApp ex);
        public Task HandleHostNotFoundErrorAsync(HostNotFoundException ex);
        public Task HandleBadRequestErrorAsync(BadRequestException ex);
        public Task HandleNotFoundErrorAsync(NotFoundException ex);
    }

    public interface IBuildErrorHandlingServiceEvent
    {
        public Func<Exception, Task> HandleException { get; set; }
        public Func<UnauthorizedException, Task> HandleUnauthorizedError { get; set; }
        public Func<ServiceUnavailableException, Task> HandleServiceUnavailableError { get; set; }
        public Func<InternalServerException, Task> HandleInternalServerError { get; set; }
        public Func<TooManyRequestsException, Task> HandleTooManyRequestsError { get; set; }
        public Func<ForbiddenException, Task> HandleForbiddenError { get; set; }
        public Func<SubscriptionUnavailableException, Task> HandleSubscriptionUnavailableError { get; set; }
        public Func<SubscriptionExpiredException, Task> HandleSubscriptionExpiredError { get; set; }
        public Func<TimeoutExceptionApp, Task> HandleTimeoutError { get; set; }
        public Func<BadRequestException, Task> HandleBadRequestError { get; set; }
        public Func<NotFoundException, Task> HandleNotFoundError { get; set; }

    }

    public class ErrorHandlingService : IErrorHandlingService
    {

        private readonly IUserActionService userActionService;
        private readonly CustomStringLocalizer localizerHttpError;
        private readonly CustomStringLocalizer localizerAuthError;
        private readonly CustomStringLocalizer localizerShared;
        public ErrorHandlingService(IUserActionService userActionService)
        {
            this.userActionService = userActionService;

            
            localizerHttpError = new CustomStringLocalizer("Client.Shared.Resources.Messages.Errors.HttpMessageErrors");
            localizerShared = new CustomStringLocalizer("Client.Shared.Resources.SharedResource");
            localizerAuthError = new CustomStringLocalizer("Client.Shared.Resources.Messages.Errors.AuthMessages");

        }


        public async Task HandleExceptionAsync(Exception ex)
        {
            //throw new NotImplementedException();
        }

        public async Task HandleTooManyRequestsErrorAsync(TooManyRequestsException? ex = null)
        {
            var message = localizerHttpError.GetLocalizedString("TooManyRequests409");
            var result = await userActionService.ShowMessageBox(message:message, yesText: localizerShared.GetLocalizedString("yes"), noText: localizerShared.GetLocalizedString("no"));
            if (result == true) { }
            else { }
        }
        public async Task HandleServiceUnavailableErrorAsync(ServiceUnavailableException? ex = null)
        {
            var message = localizerHttpError.GetLocalizedString("ServiceUnavailable503");
            var result = await userActionService.ShowMessageBox(message:message, yesText: localizerShared.GetLocalizedString("yes"), noText: localizerShared.GetLocalizedString("no"));
            if (result == true) { }
            else { }
        }     
        public async Task HandleForbiddenErrorAsync(ForbiddenException? ex = null)
        {
            var message = localizerHttpError.GetLocalizedString("Forbidden403");
            var result = await userActionService.ShowMessageBox(message: message, yesText: localizerShared.GetLocalizedString("yes"), noText: localizerShared.GetLocalizedString("no"));
            if (result == true) { }
            else { }
        }

        public async Task HandleInternalServerErrorAsync(InternalServerException? ex = null)
        {
            var message = localizerHttpError.GetLocalizedString("InternalServer500");
            var result = await userActionService.ShowMessageBox(message: message, yesText: localizerShared.GetLocalizedString("yes"), noText: localizerShared.GetLocalizedString("no"));

            if (result == true) { }
            else { }
        }

        public async Task HandleUnauthorizedErrorAsync(UnauthorizedException? ex = null)
        {
            //userActionService.NavigationTo($"{RouterPage.LOGIN}/");
            userActionService.ShowSnackBar(ex.Message);
        }

        public async Task HandleSubscriptionUnavailableErrorAsync(SubscriptionUnavailableException? ex=null)
        {
          
            var message = localizerHttpError.GetLocalizedString("SubscriptionUnavailable904");
            var result = await userActionService.ShowMessageBox(message: message, yesText: localizerShared.GetLocalizedString("yes"), noText: localizerShared.GetLocalizedString("no"));
            if (result == true)
            {
                userActionService.NavigationTo(RouterPage.PLANS);
            }
            else { }

        }

        public async Task HandleTimeoutErrorAsync(TimeoutExceptionApp? ex = null)
        {
            var message = localizerHttpError.GetLocalizedString("GatewayTimeout504");
            userActionService.ShowSnackBar(message);
        }

        public async Task HandleNotFoundErrorAsync(NotFoundException? ex = null)
        {
            var message = localizerHttpError.GetLocalizedString("NotFound404");
            userActionService.ShowSnackBar(message);
        }

        public async Task HandleSubscriptionExpiredErrorAsync(SubscriptionExpiredException? ex = null)
        {
            var message = localizerHttpError.GetLocalizedString("SubscriptionExpired905");
            var result = await userActionService.ShowMessageBox(message, yesText: localizerShared.GetLocalizedString("yes"), noText: localizerShared.GetLocalizedString("no"));
            if (result == true) {
                userActionService.NavigationTo(RouterPage.PLANS);
            }
            else { }
            
        }

        public async Task HandleBadRequestErrorAsync(BadRequestException ex)
        {
            var message = localizerHttpError.GetLocalizedString("BadRequest400");

            var result = await userActionService.ShowMessageBox(message: message, yesText: localizerShared.GetLocalizedString("yes"), noText: localizerShared.GetLocalizedString("no"));
            if (result == true)
            {
                //userActionService.NavigationTo(RouterPage.PLANS);
            }
            else { }
        }

        public async Task HandleLockedOutErrorAsync(LockedOutException ex)
        {
            
                var message = localizerAuthError.GetLocalizedString("TemporarilyLocked");
                var result = await userActionService.ShowMessageBox(message: message, yesText: localizerShared.GetLocalizedString("yes"), noText: localizerShared.GetLocalizedString("no"));
                if (result == true) { }
                else { }
        }

        public Task HandleHostNotFoundErrorAsync(HostNotFoundException ex)
        {
           userActionService.NavigationTo($"{RouterPage.ERROR}/");
           return Task.CompletedTask;
        }
    }
}
