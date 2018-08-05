using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using DAL.Mapper;

namespace MonoProject.App_Start
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
           AutoMapper.Mapper.Initialize(x =>
            {
                x.AddProfile<DAL.Mapper.ModelMapperProfile>();
                x.AddProfile<MonoProject.Mapper.AutoMapperProfile>();
            });
        }
    }
}