

using FluentValidation;
using LAHJA.UI.Components.Auth;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Shared.Constants.Router;
using Shared.Interfaces;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace LAHJA.Data.UI.Components.Base
{

    
   public enum TypeAuth
    {
        Login,
        //ConfirmEmail,
        //ResetPassword,
        //ReSendConfirmEmail,
    }


    public interface IAuthBaseComponentCard
    {
        
    }

    public class DataBuildAuth
    {
      

        private string email = "admin@gmail.com";
        private string password = "Admin123*";

      
    }


  
    public class DataBuildAuthBase:ITVM
    {

        public string? FirstName { get; set; } = "ASG";
        public string? LastName { get; set; } = "USER";
        public int? Age { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; } 
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public string? Picture { get; set; } = "";
        public string? Nationality { get; set; }
        public string? Code { get; set; }
        public bool IsLogin { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Provider { get; set; }
        public string ReturnUrl { get; set; }
        public string RefreshToken { get; set; }
        public bool UseCookies { get; set; } = false;
        public bool UseSessionCookies { get; set; }= false;
        public string? UserRole { get; set; } = "";
    }


    public class CardAuth<T> : ComponentBaseCard<T>
    {
        [Inject] NavigationManager Navigation { get; set; }
        [Inject] IDialogService DialogService { get; set; }
        [Inject] IValidator<DataBuildAuthBase> loginValidator { get; set; }

        public override TypeComponentCard Type => throw new NotImplementedException();

        public override void Build(T db)
        {
            DataBuild = db;
        }

      private async Task<string[]> ValidateField(Expression<Func<T>> expression)
      {
            if (DataBuild != null)
            {
                var context = new ValidationContext<T>(DataBuild);
                var result = await loginValidator.ValidateAsync(context);
                var propertyName = ((MemberExpression)expression.Body).Member.Name;

                return result.Errors
                             .Where(e => e.PropertyName == propertyName)
                             .Select(e => e.ErrorMessage)
                             .ToArray();
            }

          return default;
        }
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        [Parameter] public EventCallback<DataBuildAuthBase> OnSubmitExternalLogin { get; set; }
        [Parameter] public EventCallback<T> OnSubmit { get; set; }
        [Parameter] public EventCallback<T> OnSubmitConfirmEmail { get; set; }
        [Parameter] public EventCallback<T> OnSubmitReSendConfirmEmail { get; set; }
        [Parameter] public EventCallback<T> OnSubmitResetPassword { get; set; }
        [Parameter] public bool IsLogin { set; get; } = false;
        [Parameter] public EventCallback<T> OnSubmitedForgetPassword { get; set; }
        [Parameter] public List<string> ErrorMessages
        {
            set
            {
                if (value != null && value.Count() > 0)
                    errors = value.ToArray();
            }
        }

        protected bool success;
        protected string[] errors = { };
        protected MudTextField<string> pwField1;
        protected MudForm form;
        protected bool visibleForgetPassword = false;
        protected bool isLoading = false;

        protected string firstName="aswe";
        protected string lastName="eweqwe";
        protected string picture ="";
        protected string phoneNumber="897977897";
        protected string email = "shopingcartapi90@gmail.com";
        protected string password="Test@123";
        protected string repeatPassword;
        protected string code;


  
        protected IEnumerable<string> PasswordStrength(string pw)
        {
            if (string.IsNullOrWhiteSpace(pw))
            {
                yield return "Password is required!";
                yield break;


            }
            if (pw.Length < 8)
                yield return "Password must be at least of length 8";
            if (!Regex.IsMatch(pw, @"[A-Z]"))
                yield return "Password must contain at least one capital letter";
            if (!Regex.IsMatch(pw, @"[a-z]"))
                yield return "Password must contain at least one lowercase letter";
            if (!Regex.IsMatch(pw, @"[0-9]"))
                yield return "Password must contain at least one digit";
        }

        protected string PasswordMatch(string arg)
        {
            repeatPassword = pwField1.Value;
            if (pwField1.Value != arg)
                return "Passwords don't match";
            return null;
        }

        protected async Task onSubmitResendConfirmEmail()
        {
            //var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true };
            //var dialog = DialogService.Show<ConfirmationEmail>("", new DialogParameters(), options);
            //var result = await dialog.Result;
            Navigation.NavigateTo(RouterPage.RE_SEND_CONFIRM_EMAIL, true);
            //if (!result.Cancelled)
            //{
            //    // Handle confirmation
            //}
        }

        protected async Task showResetPassword()
        {
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true };
            var dialog = DialogService.Show<ResetPasswordComponent>("", new DialogParameters(), options);
            var result = await dialog.Result;

            //if (!result.Cancelled)
            //{
            //    // Handle confirmation
            //}
        }
        protected async Task onClickForgetPassword()
        {

            //visibleForgetPassword = true;
            Navigation.NavigateTo(RouterPage.FORGET_PASSWORD);

            //StateHasChanged();
        }

   
        protected  void onCloseDialog()
        {
            //MudDialog.Cancel();

            Navigation.NavigateTo(RouterPage.REGISTER,true);

        }
        //protected void onCloseConfirmEmailDialog()
        //{
        //    MudDialog.Cancel();

        //}

      

    }



}