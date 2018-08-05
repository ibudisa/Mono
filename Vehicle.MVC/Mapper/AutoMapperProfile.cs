using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using DAL.Domain;
using Vehicle.MVC.ViewModels;
using DAL.Models;

namespace MonoProject.Mapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<VehicleMakeCoreModel, VehicleMakeViewModel>().ReverseMap();
            CreateMap<VehicleModelCoreModel, VehicleModelViewModel>().ReverseMap();
            
        }

        public override string ProfileName
        {
            get { return "CoreToViewModelMappings"; }
        }
    }
}