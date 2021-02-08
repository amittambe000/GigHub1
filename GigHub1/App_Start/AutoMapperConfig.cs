using AutoMapper;
using GigHub1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHub1.App_Start
{
    public class AutoMapperConfig
    {

        public static IMapper Mapper { get; set; }

        public static void Init()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });

            Mapper = config.CreateMapper();
        }


    }
}