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
using Domain.Entities.Plans;
using Domain.Entities.User;
using Infrastructure.Models.User;
using Infrastructure.Models;
using Infrastructure.DataSource.Seeds.Models;
using Infrastructure.Nswag;
using Domain.Entities.Auth.Response;

namespace Infrastructure.Mappings.Plans
{

    public class ApplicationMappingConfig : AutoMapper.Profile
    {
        public ApplicationMappingConfig()
        {




         
       



            //CreateMap<LoginResponseModel, UserModel>()
            //    .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.userId))
            //.ReverseMap();

        




        }
    }
}
