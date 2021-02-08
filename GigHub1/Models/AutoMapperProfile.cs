using AutoMapper;
using GigHub1.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHub1.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ApplicationUser, UserDto>();
            CreateMap<Gig, GigDto>();
            CreateMap<Notification, NotificationDto>();


        }


    }
}