

using Domain.Entities.Profile;
using Domain.Entities.Profile.Response;
using Domain.ShareData.Base.Auth;
using Infrastructure.Models.AuthorizationSession;
using Infrastructure.Models.BaseFolder.Response;
using Infrastructure.Models.ModelGateway;
using Infrastructure.Models.Checkout.Request;
using Infrastructure.Models.Checkout.Response;
using Infrastructure.Models.Plans;
using Infrastructure.Models.Price.Request;
using Infrastructure.Models.Price.Response;
using Infrastructure.Models.Product.Request;
using Infrastructure.Models.Product.Response;
using Infrastructure.Models.Service.Request;
using Infrastructure.Models.Service.Response;
using Infrastructure.Models.Setting.Request;
using Infrastructure.Models.Subscriptions.Response;
using Infrastructure.Nswag;
using Domain.Entities.Profile.Request;
using Domain.Entities.ModelAi;
using Infrastructure.Models.Subscriptions.Request;


namespace Infrastructure.Mappings.Plans
{

    public class InfrastructureRemoteMappingConfig : AutoMapper.Profile
    {
        public InfrastructureRemoteMappingConfig()
        {

            /// Auth
            /// 

            //CreateMap<ProfileModelAiResponse,ModelAiResponse>().ReverseMap();

            //CreateMap<ProfileSpaceResponse, SpaceResponse>().ReverseMap();
            //CreateMap<ProfileSpaceResponse, CreateSpaceRequest>().ReverseMap();
            //CreateMap<ProfileSpaceResponse, UpdateSpaceRequest>().ReverseMap();


            //CreateMap<ProfileServiceResponse, ServiceResponse>().ReverseMap();
            //CreateMap<ProfileSubscriptionResponse, SubscriptionResponse>().ReverseMap();

            CreateMap<AccessTokenResponse, AccessTokenResponseModel>().ReverseMap();
            //CreateMap<RefreshRequestModel, RefreshRequest>().ReverseMap();
            //CreateMap<ConfirmationEmailModel, ConfirmationEmailRequest>().ReverseMap();
            CreateMap<ResendConfirmationEmailRequest, ResendConfirmationEmailModel>().ReverseMap();
            CreateMap<ResetPasswordRequest, ResetPasswordRequestModel>().ReverseMap();
         

            CreateMap<LoginRequestModel, LoginRequest>().ReverseMap();
            CreateMap<RegisterRequestModel,  RegisterRequest>()
                 .ForMember(dest => dest.FirsName, opt => opt.MapFrom(src => src.FirstName))
                //.ForMember(dest => dest.LastName, opt => opt.MapFrom(src => "string"))
                //.ForMember(dest => dest.ConfirmPassword, opt => opt.MapFrom(src => src.Password))
                //.ForMember(dest => dest.Avatar, opt => opt.MapFrom(src => "string"))
                .ReverseMap();

            CreateMap<LoginResponseModel, AccessTokenResponse>().ReverseMap();

            CreateMap<ConfirmationEmailModel, ConfirmEmailRequest>().ReverseMap();

            CreateMap<ForgotPasswordRequest, ForgetPasswordRequestModel>().ReverseMap();



            //CreateMap<DeletedResponse, DeleteResponseModel>().ReverseMap();
            //CreateMap<DeletedResponse, Domain.ShareData.Base.DeleteResponse>().ReverseMap();


            /// Checkout
            CreateMap<CheckoutRequestModel, CheckoutOptions>().ReverseMap();
            CreateMap<CheckoutOptionsModel, CheckoutOptions>().ReverseMap();
            CreateMap<CheckoutResponseModel, CheckoutResponse>().ReverseMap();
            CreateMap<SessionCreateModel, SessionCreate>().ReverseMap();


            /// Price
            CreateMap<PriceCreate, PriceCreateRequestModel>().ReverseMap();
            CreateMap<PriceUpdate, PriceUpdateRequestModel>().ReverseMap();
            CreateMap<PriceResponse, PriceResponseModel>().ReverseMap();


            /// Product

            CreateMap<ProductResponseModel, ProductResponse>().ReverseMap();
            CreateMap<ProductCreateModel, ProductCreate>().ReverseMap();
            CreateMap<ProductUpdateModel, ProductUpdate>().ReverseMap();
            //CreateMap<ProductSearchRequestModel, Product>().ReverseMap();
            /// Profile
            //CreateMap<ProfileUserResponse, UserResponse>().ReverseMap();
            //CreateMap<ProfileResponse, UserResponse>().ReverseMap();
            //CreateMap<ProfileUserRequest, UserRequest>().ReverseMap();



            //// Subscriptions 
            //CreateMap<SubscriptionResponseModel,SubscriptionResponse>().ReverseMap();
            //CreateMap<SubscriptionCreateResponse, SubscriptionCreateResponseModel>().ReverseMap();
            //CreateMap<PlanResponse, SubscriptionPlanModel>().ReverseMap();
            //CreateMap<SubscriptionCreate, SubscriptionCreateModel>().ReverseMap();
            //CreateMap<SubscriptionCreateRequest, SubscriptionCreateModel>().ReverseMap();
            CreateMap<SubscriptionResumeRequest, SubscriptionResumeRequestModel>().ReverseMap();



            //// Settings 
            //CreateMap<object, SettingResponseModel>().ReverseMap();
            //CreateMap<SettingUpdate, SettingUpdateModel>().ReverseMap();
            //CreateMap<SettingCreate, SettingCreateModel>().ReverseMap();


            //// Billing
            //CreateMap< ,CardDetailsResponseModel>().ReverseMap();
            //CreateMap< ,BillingDetailsResponseModel>().ReverseMap();
            //CreateMap< ,CardDetailsRequestModel>().ReverseMap();
            //CreateMap< ,BillingDataRequestModel>().ReverseMap();

            //// Service
            //CreateMap<ServiceResponse, ServiceResponseModel>().ReverseMap();
            //CreateMap<ServiceCreate, ServiceRequestModel>().ReverseMap();
            //CreateMap<ServiceUpdate, ServiceRequestModel>().ReverseMap();




            //// ModelGateway
            //CreateMap<ModelGatewayResponse, ModelGatewayResponseModel>().ReverseMap();
            //CreateMap<ModelGatewayCreate, ModelGatewayRequestModel>().ReverseMap();
            //CreateMap<ModelGatewayUpdate, ModelGatewayRequestModel>().ReverseMap();


            //// AuthorizationSession
            CreateMap<ValidateTokenRequest, ValidateTokenRequestModel>().ReverseMap();
            //CreateMap<CreateAuthorizationWebRequest, AuthorizationWebRequestModel>().ReverseMap();
            //CreateMap<AuthorizationSessionWebResponseModel, AuthorizationSessionWebResponse>().ReverseMap();
            CreateMap<AuthorizationSessionCoreResponseModel, AuthorizationSessionCoreResponse>().ReverseMap();
            //CreateMap<AuthorizationSessionEncryptResponseModel, TokenVm>().ReverseMap();
       
            //CreateMap<SessionVm, SessionTokenAuthResponseModel>().ReverseMap();



            // ModelAi
            //CreateMap<ModelAiResponse, ModelAiResponseEntity>().ReverseMap();
            //CreateMap<ModelPropertyValues, ModelPropertyValuesEntity>().ReverseMap();
            //CreateMap<Item, ItemEntity>().ReverseMap();
            //CreateMap<FilterModelPropertyValues, FilterModelPropertyValuesEntity>().ReverseMap();
            //CreateMap<ValueFilterModel, ValueFilterModelEntity>().ReverseMap();



        }
    }
}
