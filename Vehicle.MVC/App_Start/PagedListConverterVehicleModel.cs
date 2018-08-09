using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using DAL.Models;
using Vehicle.MVC.ViewModels;
using PagedList;

namespace MonoProject.App_Start
{
    public class PagedListConverterVehicleModel : ITypeConverter<PagedList<VehicleModelCoreModel>, PagedList<VehicleModelViewModel>>
    {
        public PagedList<VehicleModelViewModel> Convert(PagedList<VehicleModelCoreModel> source, PagedList<VehicleModelViewModel> destination, ResolutionContext context)
        {
            var models = (PagedList<VehicleModelCoreModel>)source;
            var viewModels = models.Select(p => AutoMapper.Mapper.Map<VehicleModelCoreModel, VehicleModelViewModel>(p)).AsQueryable();
            return new PagedList<VehicleModelViewModel>(viewModels, models.PageNumber, models.PageSize);

        }
    }
}