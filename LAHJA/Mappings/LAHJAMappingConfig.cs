using Domain.Entities.Plans.Response;
using LAHJA.Data.UI.Components.Base;
using Domain.Entities.Auth.Request;
using LAHJA.Data.UI.Components.Category;
using LAHJA.Data.UI.Templates.Payment;
using Domain.Entities.Checkout;
using LAHJA.Data.UI.Components.Plan;
using LAHJA.Data.UI.Components.Payment.DataBuildBillingBase;
using Domain.Entities.Billing.Response;
using LAHJA.Data.UI.Components.ProFileModel;
using Domain.Entities.Profile;
using LAHJA.Data.UI.Components.Payment.CreditCard;
using Domain.Entities.Billing.Request;
using LAHJA.Data.UI.Templates.Subscription;
using Domain.Entities.Subscriptions.Request;
using Domain.Entities.Subscriptions.Response;
using LAHJA.Data.UI.Components.Subscription;
using Domain.Entities.Service.Request;
using Domain.Entities.Request.Response;
using LAHJA.Data.UI.Templates.Services;
using LAHJA.ApiClient.Models;
using Domain.Entities.Request.Request;
using Domain.Entities.Event.Request;
using Domain.Entities.Profile.Response;
using Domain.Entities.Auth.Response;
using Domain.Entities.AuthorizationSession;
using LAHJA.Data.UI.Models;
using Domain.Entities.Service.Response;
using Domain.Entities.Profile.Request;
using LAHJA.Data.UI.Components.ServiceCard;
using Domain.Entities.ModelAi;
using LAHJA.Helpers;
using LAHJA.Data.UI.Components.Render;
using LAHJA.Data.UI.Models.Profile;
using LAHJA.Data.UI.Models.Space;
using LAHJA.Data.UI.Models.SessionTokenAuth;
using Domain.Entities;

namespace LAHJA.Mappings
{
    public class LAHJAMappingConfig : AutoMapper.Profile
    {

        public LAHJAMappingConfig()
        {


            CreateMap<DataBuildAuthBase,Domain.Entity.Login >().ReverseMap();

            //CreateMap<Domain.Entity.Plan, PlanViewModel>().ReverseMap();
            //CreateMap<Domain.Entity.PlanFeature, PlanFeatureViewModel>().ReverseMap();


            CreateMap<LoginRequest, VitsModel.Auth.LoginRequest>().ReverseMap();
            CreateMap<LoginResponse, AccessTokenResponse>().ReverseMap();
            CreateMap<RegisterRequest, VitsModel.Auth.RegisterRequest>().ReverseMap();

            


            CreateMap<AA1,BB1>()
            .ForAllMembers(opt => opt.MapFrom((src, dest, destMember, context) =>{
                return Helper.MapDataComponentRender(src, dest, destMember);
            }));



            //CreateMap<PlansGroupResponse,PlansFeture>()
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src=>src.ProductName))
            //    .ForMember(dest => dest.Services, opt => opt.Ignore())
            //    .ForMember(dest => dest.numberOfServices, opt => opt.Ignore())
            //    .ReverseMap();

            //CreateMap<PlanSubscriptionFeaturesResponse, Service>()
            //    .ForMember(dest => dest.Price, opt => opt.MapFrom(src => (decimal)src.Amount))
            //    .ReverseMap();
            //CreateMap<PlanTechnicalFeaturesResponse, NumberOfService>().ReverseMap();

           // CreateMap<PlansGroupResponse, PlanViewModelResponse>()
           //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProductName))
           //.ReverseMap();


            CreateMap<PlanSubscriptionFeaturesResponse, PlanTechnicalServiceResponse>()
                .ForMember(dest => dest.TechnicalServiceFeatures, opt => opt.Ignore())
            .ReverseMap();

            CreateMap<PlanTechnicalFeaturesResponse, PlanQuantitativeFeatureResponse>().ReverseMap();




            //CreateMap<PlanInfoResponse, PlanViewModel>()
            //    .ForMember(dest => dest.PlanDescription, opt => opt.MapFrom(src => src.Description))
            //    .ForMember(dest => dest.TechnologyServices, opt => opt.Ignore())
            //    .ForMember(dest => dest.ServiceDetailsList, opt => opt.Ignore())
            //    .ReverseMap();          
            
            
            CreateMap<PlanTechnicalServiceResponse, TechnologyService>()
                .ForMember(dest => dest.TechnicalServices, opt => opt.Ignore())
            .ReverseMap();

            CreateMap<PlanQuantitativeFeatureResponse, DigitalService>()
             .ForMember(dest => dest.ServiceType, opt => opt.MapFrom(src => src.Name))
             .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.Price))
           .ReverseMap();
            
            
            CreateMap<DataBuildAuthBase, LoginRequest>().ReverseMap();
            CreateMap<DataBuildAuthBase, RefreshRequest>().ReverseMap();
            CreateMap<DataBuildAuthBase, ExternalLoginRequest>().ReverseMap();
            CreateMap<DataBuildAuthBase, RegisterRequest>().ReverseMap();
            CreateMap<DataBuildAuthBase, ForgetPasswordRequest>().ReverseMap();
            CreateMap<DataBuildAuthBase, ResendConfirmationEmail>().ReverseMap();
            CreateMap<DataBuildAuthBase, ResetPasswordRequest>()
                 .ForMember(dest => dest.NewPassword, opt => opt.MapFrom(src => src.Password))
                 .ForMember(dest => dest.ResetCode, opt => opt.MapFrom(src => src.Code))
                .ReverseMap();
            CreateMap<DataBuildAuthBase, ConfirmationEmail>()
                .ForMember(dest => dest.ChangedEmail, opt => opt.MapFrom(src => src.Email))
                .ReverseMap();
            //CreateMap<DataBuildAuthBase, RegisterRequest>().ReverseMap();

          

            /// Plans
            CreateMap<ContainerPlans, CategoryComponent>()
                  .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                  .ReverseMap();
            CreateMap<PlanFeature, DigitalService>()
                  .ForMember(dest => dest.ServiceType, opt => opt.MapFrom(src => src.Name))
                  .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.Price))
                .ReverseMap();
            CreateMap<PlanFeature, TechnologyService>()
                  .ForMember(dest => dest.TechnicalServices, opt => opt.Ignore())
                .ReverseMap();
             CreateMap<SubscriptionPlan, PlanViewModel>().ReverseMap();
             CreateMap<SubscriptionResponse, UserSubscription>().ReverseMap();
             CreateMap<PlanFeature, PlanFeatureViewModel>().ReverseMap();


            /// Payment
            
            CreateMap<CheckoutRequest, DataBuildPaymentBase>().ReverseMap();

            /// Billing

            CreateMap<BillingDetailsResponse, DataBuildBillingBase>().ReverseMap();
            CreateMap<DataBuildBillingBase, BillingDetailsRequest>().ReverseMap();



            ///  CreditCard
            CreateMap<CardDetails, CardDetailsResponse>().ReverseMap();
            CreateMap<CardDetails, CardDetailsRequest>().ReverseMap();


            ///  Subscription
            CreateMap<SubscriptionResponse, DataBuildUserSubscriptionInfo>().ReverseMap();
            CreateMap<DataBuildUserSubscriptionInfo, SubscriptionRequest>().ReverseMap();
            CreateMap<DataBuildUserSubscriptionInfo, SubscriptionCreate>().ReverseMap();


            /// Profile

             CreateMap<ProfileResponse, DataBuildUserProfile>()
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Image))
                .ReverseMap();   
            CreateMap<ProfileRequest, DataBuildUserProfile>()
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Image))
                .ReverseMap();
            CreateMap<RequestResponse, DataBuildServiceBase>().ReverseMap();  
            CreateMap< DataBuildServiceBase, Data.UI.Models.QueryRequestTextToText>()
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Text))
                .ReverseMap();  
            CreateMap<RequestResponse, Data.UI.Models.QueryRequestTextToText>()
                .ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.Token))
                .ReverseMap();  
            CreateMap<RequestResponse, EventRequest>().ReverseMap();   
            CreateMap<DataBuildServiceBase, Data.UI.Models.QueryRequestTextToSpeech>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src.Text))
                .ReverseMap();
            CreateMap<DataBuildServiceBase, RequestCreate>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Text))
                .ReverseMap();
            CreateMap<DataBuildUserProfile,ProfileUserRequest>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ImageUri))
                .ReverseMap();

            CreateMap<DataBuildSpace,ProfileSpaceResponse>().ReverseMap();
            CreateMap<DataBuildServiceInfo, ServiceResponse>().ReverseMap();
            CreateMap<DataBuildUserSubscriptionInfo, ProfileSubscriptionResponse>().ReverseMap();
            CreateMap<DataBuildUserSubscriptionInfo, SubscriptionResponse>().ReverseMap();
            CreateMap<DataBuildUserProfile, ProfileUserResponse>().ReverseMap();
            CreateMap<DataBuildUserModelAi, ProfileModelAiResponse>().ReverseMap();
            CreateMap<SessionTokenAuthResponse,SessionTokenAuth>()
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime.DateTime))
                .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.CreationDate.DateTime))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime.Value.DateTime))
                .ReverseMap();



            //// Services - (ModelAi)
            CreateMap<ModelPropertyValues, ModelPropertyValuesEntity>().ReverseMap();
            CreateMap<ModelAiResponse, ModelAiResponseEntity>().ReverseMap();





            //.ForMember(dest => dest.ServiceDetailsList, opt => opt.MapFrom(src => src.Features
            //    .Where(feature => feature.IsFixed==true) 
            //    .Select(feature => new TechnologyService
            //    {
            //        Name = feature.Name,
            //        Description = feature.Description,
            //        Active= feature.Active,
            //        Id= feature.Id,
            //        TechnicalServices= null,

            //    }).ToList())) 
            //.ForMember(dest => dest.TechnologyServices, opt => opt.MapFrom(src => src.Features
            //    .Where(feature => !feature.IsFixed==false) 
            //    .Select(feature => new TechnologyService
            //    {
            //        Name = feature.Name,
            //        Description = feature.Description,
            //        Active = feature.Active,
            //        Id = feature.Id,
            //        TechnicalServices = null,
            //    }).ToList())) 
            //.ReverseMap();




            //CreateMap<TechnologyService, NumberOfService>().ReverseMap();
        }
    }
}
