﻿using AutoMapper;
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
                //.ForMember(dest => dest.RoleName, opt => opt.MapFrom(source => source.AspNetRoles)) ;
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(source => source.AspNetRoles.Select(s => s.Name))) // ToList() ))// SelectMany(x => x.Name))) // Select(x => x.Name)))
                //.ForMember(dest => dest.RoleName, opt => opt.MapFrom(source => string.Join(",", source.AspNetRoles.Select(x => x.Name))))
                .ReverseMap();
                //.ForMember(dest => dest.AspNetRoles, opt => opt.Ignore());

                cfg.CreateMap<Representative, ViewRepresentativeDetails>();

                cfg.CreateMap<Representative, AddRepresentative>()
                .ReverseMap();

                cfg.CreateMap<AspNetRole, ViewRoles>()
                .ReverseMap();

                cfg.CreateMap<DocumentCurrent, ViewDocument>()
                //.ForMember(dest => dest.DocumentStatusName, opt => opt.MapFrom(src => new DocumentStatu { }))
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.AspNetUser.Email))
                .ForMember(dest => dest.DocumentStatusName, opt => opt.MapFrom(src => src.DocumentStatu.Status))
                .ForMember(dest => dest.EverifyStatusName, opt => opt.MapFrom(src => src.EverifyStatu.EVerifyStatus))
                .ForMember(dest => dest.RepresentativeName, opt => opt.MapFrom(src => src.Representative.FirstName))
                .ReverseMap();

                cfg.CreateMap<AspNetRole, ViewAspNetRoles>()
                .ReverseMap();

                cfg.CreateMap<DocumentStatu, ViewDocumentStatus>()
                .ReverseMap();
            });
        }
    }
}
