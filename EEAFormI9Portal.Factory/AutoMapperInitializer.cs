using AutoMapper;
using EEAFormI9Portal.EF;
using EEAFormI9Portal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EEAFormI9Portal.Models;

namespace EEAFormI9Portal.Factory
{
    public class AutoMapperInitializer
    {
        public static void TwoWayMapping()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<AspNetUser, ViewUserDetails>();

                cfg.CreateMap<AspNetUser, ViewUserAndRoleDetails>()
                //.ForMember(dest => dest.Role, opt => opt.MapFrom(source => source.AspNetRoles));
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(source => source.AspNetRoles)) ;
                //.ReverseMap()
                //.ForMember(dest => dest.AspNetRoles, opt => opt.Ignore());

                cfg.CreateMap<Representative, ViewRepresentativeDetails>();

                cfg.CreateMap<Representative, AddRepresentative>()
                .ReverseMap();
            });
        }
    }
}
