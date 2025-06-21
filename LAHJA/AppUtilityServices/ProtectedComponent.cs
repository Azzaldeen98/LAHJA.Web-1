using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using Shared.Constants;
using System.Globalization;
using Shared.Constants.Router;
using Domain.ShareData.Base;
using MudBlazor;


namespace LAHJA.ContextServices
{
    public class ProtectedComponentService : AppUtilityComponentService
    {
        private readonly CustomAuthenticationStateProvider AuthStateProvider;

        public ProtectedComponentService(CustomAuthenticationStateProvider authStateProvider, NavigationManager navigation, ISnackbar snackbar):base(navigation,snackbar)
        {
            AuthStateProvider = authStateProvider;
        }

        public bool IsAuth { get => _isAuth; }
        protected bool _isAuth = false;

        private async Task<bool> isAuthAsync()
        {
            var authState = await AuthStateProvider.GetAuthenticationStateAsync();
            if (authState != null)
                _isAuth = authState?.User?.Identity?.IsAuthenticated ?? false;
            return _isAuth;
        }
        public virtual async Task RequiredAuthAsync()
        {
            if (!await isAuthAsync())
            {
                GoToWithReload(RouterPage.LOGIN);
            }
        }
    }
    public class ProtectedComponent : AppUtilityComponent
    {
        [Inject] public ProtectedComponentService service { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }
        protected override async Task OnInitializedAsync()
        {
            await service.RequiredAuthAsync();


        }
    
      
    }
}
