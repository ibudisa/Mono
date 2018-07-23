using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Service;
using DAL;
using Vehicle.MVC.ViewModels;
using AutoMapper;

namespace Vehicle.MVC.Controllers
{
    public class VehicleMakeController : Controller
    {
        // GET: VehicleMake
         public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
            {
            VehicleService vehicleService = new VehicleService();

                ViewBag.CurrentSort = sortOrder;
                ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
                ViewBag.AbrvSortParm = sortOrder == "Abrv" ? "abrv_desc" : "Abrv";

                if (searchString != null)
                {
                    page = 1;
                }
                else
                {
                    searchString = currentFilter;
                }

                ViewBag.CurrentFilter = searchString;

            int pageSize = 3;
            int pageNumber = (page ?? 1);

            List<VehicleMakeViewModel> list = new List<VehicleMakeViewModel>();

            var vehicles = vehicleService.GetVehicleMakes(sortOrder, currentFilter, searchString, page);

            foreach (var item in vehicles)
            {
                VehicleMakeViewModel vehicleMakeViewModel = new VehicleMakeViewModel();
                vehicleMakeViewModel = Mapper.Map<VehicleMakeViewModel>(item);
                list.Add(vehicleMakeViewModel);
            }
            IPagedList<VehicleMakeViewModel> pagedList = list.ToPagedList(pageNumber, pageSize);

           

            return View(pagedList);
            
        }
    }
}