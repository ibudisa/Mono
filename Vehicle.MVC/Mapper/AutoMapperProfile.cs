using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using DAL.Domain;
using Vehicle.MVC.ViewModels;
using DAL.Models;
using PagedList;
using MonoProject.App_Start;

namespace MonoProject.Mapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<VehicleMakeCoreModel, VehicleMakeViewModel>().ReverseMap();
            CreateMap<VehicleModelCoreModel, VehicleModelViewModel>().ReverseMap();
            CreateMap<PagedList<VehicleMakeCoreModel>, PagedList<VehicleMakeViewModel>>()
            .ConvertUsing<PagedListConverterVehicleMake>();
            CreateMap<PagedList<VehicleModelCoreModel>, PagedList<VehicleModelViewModel>>()
           .ConvertUsing<PagedListConverterVehicleModel>();


        }

        public override string ProfileName
        {
            get { return "CoreToViewModelMappings"; }
        }
    }
}