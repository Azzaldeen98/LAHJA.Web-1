using Microsoft.AspNetCore.Components;
using Shared.Constants.Router;
using LAHJA.Data.UI.Templates.Subscription;
using MudBlazor;


namespace LAHJA.ContextServices
{
    public class SecureComponentService : ProtectedComponentService
    {
        private readonly TemplateSubscription subscription;
        public SecureComponentService(
                                CustomAuthenticationStateProvider authStateProvider,
                                NavigationManager navigation,
                                ISnackbar snackbar,
                                TemplateSubscription subscription) : base(authStateProvider, navigation, snackbar)
        {
            this.subscription = subscription;
        }

        public bool HasSubscription { get => _hasSubscription; }

        private bool _hasSubscription = false;
      
        public async Task<bool> HasSubscriptionAsync()
        {
            await RequiredAuthAsync();
            return await subscription.HasActiveSubscriptionAsync();
        }

        public virtual async Task RequiredSubscriptionAsync()
        {
            if (!await HasSubscriptionAsync())
            {
                GoTo(RouterPage.PLANS);
            }
        }


    }
    public class SecureComponent : ProtectedComponent
    {
        [Inject] public SecureComponentService service { get; set; }

        protected override async Task OnInitializedAsync()
        {

            await base.OnInitializedAsync();
            await service.RequiredSubscriptionAsync();

        }

    }
}
