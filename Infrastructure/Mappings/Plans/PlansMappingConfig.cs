using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using AutoMapper;
using Infrastructure.Models.Plans;
using Infrastructure.Models.Plans.Response;
using Domain.Entities.Plans.Response;
using Domain.ShareData.Base;

namespace Infrastructure.Mappings.Plans
{

    public class PlansMappingConfig : AutoMapper.Profile
    {
        public PlansMappingConfig()
        {




            CreateMap<PlanResponseModel, PlanResponse>().ReverseMap();
            CreateMap<PlansContainerModel, PlansContainerResponse>().ReverseMap();
            CreateMap<PlanSubscriptionResponseModel, BaseSubscription>().ReverseMap();
            CreateMap<PlansGroupModel, PlansGroupResponse>().ReverseMap();
            CreateMap<PlanSubscriptionFeaturesModel, PlanSubscriptionFeaturesResponse>().ReverseMap();
            CreateMap<PlanTechnicalFeaturesModel, PlanTechnicalFeaturesResponse>().ReverseMap();
            CreateMap<PlanSubscriptionResponseModel, PlanSubscriptionResponse>().ReverseMap();


            CreateMap<PlanFeatureModel, PlanFeature>().ReverseMap();
            CreateMap<SubscriptionPlanModel, SubscriptionPlan>().ReverseMap();
            CreateMap<ContainerPlansModel, ContainerPlans>().ReverseMap();
            CreateMap<ContainerPlansModel, ContainerPlans>().ReverseMap();
            CreateMap<PlanCreateModel, PlanCreate>().ReverseMap();
            CreateMap<PlanServicesUpdateModel, PlanServicesUpdate>().ReverseMap();




            //    .ForMember(dest => dest.likes, opt => opt.MapFrom(src => src.likes != null ? src.likes.Count : 0))
            //.ReverseMap();

            //CreateMap<DailyCareTimesUpdate, DailyCareTimes>()
            //       .ForMember(dest => dest.time, opt => opt.MapFrom(src => Helper.ConvertToTimeSpan(src.time)))
            //       .ReverseMap();
            //CreateMap<JoinBroadcastLive, IndexJoinBroadcastLive>()
            //         .ForMember(dest => dest.user, opt => opt.Ignore())
            //.ReverseMap();



        }
    }
}
