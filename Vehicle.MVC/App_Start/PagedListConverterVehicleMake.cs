using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using PagedList;
using DAL.Models;
using Vehicle.MVC.ViewModels;

namespace MonoProject.App_Start
{
    public class PagedListConverterVehicleMake : ITypeConverter<PagedList<VehicleMakeCoreModel>, PagedList<VehicleMakeViewModel>>
    {
        public PagedList<VehicleMakeViewModel> Convert(PagedList<VehicleMakeCoreModel> source, PagedList<VehicleMakeViewModel> destination, ResolutionContext context)
        {
            var models = (PagedList<VehicleMakeCoreModel>)source;
            var viewModels = models.Select(p => AutoMapper.Mapper.Map<VehicleMakeCoreModel, VehicleMakeViewModel>(p)).AsQueryable();
            return new PagedList<VehicleMakeViewModel>(viewModels, models.PageNumber, models.PageSize);

        }
    }
}