using LAHJA.Mappings;
using LAHJA.ApplicationLayer.Plans;
using LAHJA.ApplicationLayer.Auth;
using LAHJA.ApplicationLayer.Profile;
using LAHJA.Data.UI.Templates.Auth;
using LAHJA.Data.UI.Templates.Plans;
using LAHJA.Data.UI.Components.Base;
using LAHJA.Data.UI.Templates.Payment;
using LAHJA.ApplicationLayer.Product;
using LAHJA.ApplicationLayer.Subscription;
using LAHJA.ApplicationLayer.Price;
using LAHJA.Data.UI.Templates.Price;
using LAHJA.Data.UI.Templates.Product;
using LAHJA.Data.UI.Templates.Subscription;
using LAHJA.Data.UI.Components;
using Application.Service.Plans;
using LAHJA.Data.UI.Templates.CreditCard;
using LAHJA.Data.UI.Templates.Billing;
using LAHJA.Data.UI.Templates.Profile;
using LAHJA.Data.UI.Components.ProFileModel;
using LAHJA.Data.UI.Components.Payment.DataBuildBillingBase;
using LAHJA.ApplicationLayer.Service;
using LAHJA.Data.UI.Templates.Services;
using LAHJA.Helpers.Services;
using Domain.ShareData;
using LAHJA.ApplicationLayer.Request;
using LAHJA.ApplicationLayer.Checkout;
using Application.Service.Service;
using LAHJA.ApplicationLayer.AuthorizationSession;
using LAHJA.Data.UI.Templates.AuthSession;
using LAHJA.ApplicationLayer.ModelAi;
using LAHJA.Data.UI.Models.ModelAi;
using LAHJA.Data.UI.Templates.ModelAi;
using LAHJA.ContextServices;

using LAHJA.Data.UI.Models.Profile;
using LAHJA.Data.UI.Models.SessionTokenAuth;
using Application.Config;
using Client.Shared.UI.ErrorHandling;
using LAHJA.Data.UI.Templates.Categories;
using LAHJA.Data.UI.Components.Plan;

namespace LAHJA
{
    

    
    public static class LAHJAConfigServices
    {

        


        public static void InstallLAHJAConfigServices(this IServiceCollection serviceCollection)
        {


            serviceCollection.AddTransient<AuthService>();

            InstallMapping(serviceCollection);
            InstallServices(serviceCollection);
            InstallHelperServices(serviceCollection);
            InstallTemplates(serviceCollection);
            InstallAppUtilityServices(serviceCollection);

    

        }


       private static  void InstallAppUtilityServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<AppUtilityComponentService>();
            serviceCollection.AddScoped<ProtectedComponentService>();
            serviceCollection.AddScoped<SecureComponentService>();
        }
       private static  void InstallMapping(this IServiceCollection serviceCollection)
        {
          
            serviceCollection.AddAutoMapper(typeof(LAHJAMappingConfig));
        }


        private static void InstallHelperServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUiStateService, UiStateService>();
            serviceCollection.AddScoped<IUserActionService, UserActionService>();
            serviceCollection.AddScoped<IErrorHandlingService, ErrorHandlingService>();
            serviceCollection.AddScoped<IManageLanguageService,ManageLanguageService>();
            //serviceCollection.AddScoped<ISafelyHandler, ClientSafelyHandlerException>();
            serviceCollection.AddScoped<SessionUserManager>();
            serviceCollection.AddScoped<LanguageService>();
            serviceCollection.AddScoped<MessageBox>();


        }  
        
        private static void InstallTemplates(this IServiceCollection serviceCollection)
        {


            ////  Auth
            serviceCollection.AddScoped<IBuilderAuthApi<DataBuildAuthBase>, BuilderAuthApiClient>();
            serviceCollection.AddScoped<IBuilderAuthComponent<DataBuildAuthBase>,BuilderAuthComponent<DataBuildAuthBase>>();
            serviceCollection.AddScoped<TemplateAuthShare<Helpers.Services.AuthService, DataBuildAuthBase>>();
            serviceCollection.AddScoped<TemplateAuth>();

            //// Plans
            serviceCollection.AddScoped<IBuilderPlansApi<DataBuildPlansBase>, BuilderPlansApiClient>();
            serviceCollection.AddScoped<IBuilderPlansComponent<DataBuildPlansBase>, BuilderPlansComponent<DataBuildPlansBase>>();
            serviceCollection.AddScoped<IBuilderPlansComponentQuery<DataBuildPlansBase, PlanViewModel>, BuilderPlansComponentQuery<DataBuildPlansBase,PlanViewModel>>();
            serviceCollection.AddScoped<IBuilderPlansComponentCommand<DataBuildPlansBase>, BuilderPlansComponentCommand<DataBuildPlansBase>>();
            serviceCollection.AddScoped<TemplatePlansShare<PlansClientService, DataBuildPlansBase, PlanViewModel>>();
            serviceCollection.AddScoped<TemplatePlans>();

            //// Categories
            serviceCollection.AddScoped<IBuilderCategoriesApi<object>, BuilderCategoriesApiClient>();
            serviceCollection.AddScoped<IBuilderCategoriesComponent<object>, BuilderCategoriesComponent<object>>();
            serviceCollection.AddScoped<TemplateCategoriesShare<PlansClientService, object>>();
            serviceCollection.AddScoped<TemplateCategories>();


            //// Payment
            serviceCollection.AddScoped<IBuilderCheckoutApi<DataBuildPaymentBase>, BuilderCheckoutApiClient>();
            serviceCollection.AddScoped<IBuilderPaymentComponent<DataBuildPaymentBase>, BuilderPaymentComponent<DataBuildPaymentBase>>();
            serviceCollection.AddScoped<TemplatePaymentShare<CheckoutClientService, DataBuildPaymentBase>>();
            serviceCollection.AddScoped<TemplatePayment>();
          

            //// Price
            serviceCollection.AddScoped<IBuilderPriceApi<DataBuildPriceBase>, BuilderPriceApiClient>();
            serviceCollection.AddScoped<IBuilderPriceComponent<DataBuildPriceBase>, BuilderPriceComponent<DataBuildPriceBase>>();
            serviceCollection.AddScoped<TemplatePriceShare<PriceClientService, DataBuildPriceBase>>();
            serviceCollection.AddScoped<TemplatePrice>();
         

            ///Product
            serviceCollection.AddScoped<IBuilderProductApi<DataBuildProductBase>, BuilderProductApiClient>();
            serviceCollection.AddScoped<IBuilderProductComponent<DataBuildProductBase>, BuilderProductComponent<DataBuildProductBase>>();
            serviceCollection.AddScoped<TemplateProductShare<ProductClientService, DataBuildProductBase>>();
            serviceCollection.AddScoped<TemplateProduct>();


            ///Subscription
            serviceCollection.AddScoped<IBuilderSubscriptionApi<DataBuildUserSubscriptionInfo>, BuilderSubscriptionApiClient>();
            serviceCollection.AddScoped<IBuilderSubscriptionComponent<DataBuildUserSubscriptionInfo>, BuilderSubscriptionComponent<DataBuildUserSubscriptionInfo>>();
            serviceCollection.AddScoped<TemplateSubscriptionShare<SubscriptionClientService, DataBuildUserSubscriptionInfo>>();
            serviceCollection.AddScoped<TemplateSubscription>();

            //// CreditCard
            serviceCollection.AddScoped<IBuilderCreditCardApi<DataBuildCreditCardBase>, BuilderCreditCardApiClient>();
            serviceCollection.AddScoped<IBuilderCreditCardComponent<DataBuildCreditCardBase>, BuilderCreditCardComponent<DataBuildCreditCardBase>>();
            serviceCollection.AddScoped<TemplateCreditCardShare<CreditCardClientService, DataBuildCreditCardBase>>();
            serviceCollection.AddScoped<TemplateCreditCard>();

            //// Billing
            serviceCollection.AddScoped<IBuilderBillingApi<DataBuildBillingBase>, BuilderBillingApiClient>();
            serviceCollection.AddScoped<IBuilderBillingComponent<DataBuildBillingBase>, BuilderBillingComponent<DataBuildBillingBase>>();
            serviceCollection.AddScoped<TemplateBillingShare<BillingClientService, DataBuildBillingBase>>();
            serviceCollection.AddScoped<TemplateBilling>();

            //// Profile
            serviceCollection.AddScoped<IBuilderProfileApi<DataBuildUserProfile>, BuilderProfileApiClient>();
            serviceCollection.AddScoped<IBuilderProfileComponent<DataBuildUserProfile>, BuilderProfileComponent<DataBuildUserProfile>>();
            serviceCollection.AddScoped<TemplateProfileShare<ProfileClientService, DataBuildUserProfile>>();
            serviceCollection.AddScoped<TemplateProfile>();


            //// Services
            serviceCollection.AddScoped<IBuilderServicesApi<DataBuildServiceBase>, BuilderServiceApiClient>();
            serviceCollection.AddScoped<IBuilderServicesComponent<DataBuildServiceBase>, BuilderServicesComponent<DataBuildServiceBase>>();
            serviceCollection.AddScoped<TemplateServicesShare<LAHJAClientService, DataBuildServiceBase>>();
            serviceCollection.AddScoped<TemplateServices>();

            //// AuthSession
            serviceCollection.AddScoped<IBuilderAuthSessionApi<DataBuildSessionTokenAuth>, BuilderAuthSessionApiClient>();
            serviceCollection.AddScoped<IBuilderAuthSessionComponent<DataBuildSessionTokenAuth>, BuilderAuthSessionComponent<DataBuildSessionTokenAuth>>();
            serviceCollection.AddScoped<TemplateAuthSessionShare<AuthorizationSessionClientService, DataBuildSessionTokenAuth>>();
            serviceCollection.AddScoped<TemplateAuthSession>();

            //// ModelAi
            serviceCollection.AddScoped<IBuilderModelAiApi<DataBuildModelAi>, BuilderModelAiApiClient>();
            serviceCollection.AddScoped<IBuilderModelAiComponent<DataBuildModelAi>, BuilderModelAiComponent<DataBuildModelAi>>();
            serviceCollection.AddScoped<TemplateModelAiShare<ModelAiClientService, DataBuildModelAi>>();
            serviceCollection.AddScoped<TemplateModelAi>();

        }
        private static void InstallServices(this IServiceCollection serviceCollection)
        {
      

            serviceCollection.AddScoped<ClientAuthService>();
            serviceCollection.AddScoped<PlansClientService>();
            serviceCollection.AddScoped<CheckoutClientService>();
            serviceCollection.AddScoped<PriceClientService>();
            serviceCollection.AddScoped<SubscriptionClientService>();
            serviceCollection.AddScoped<ProductClientService>();
            serviceCollection.AddScoped<CreditCardClientService>();
            serviceCollection.AddScoped<BillingClientService>();
            serviceCollection.AddScoped<ProfileClientService>();
            serviceCollection.AddScoped<LAHJAClientService>();
            serviceCollection.AddScoped<RequestClientService>();
            serviceCollection.AddScoped<SpaceClientService>();
            serviceCollection.AddScoped<AuthorizationSessionClientService>();
            serviceCollection.AddScoped<ModelAiClientService>();
           
           
        }
       
    }
}
