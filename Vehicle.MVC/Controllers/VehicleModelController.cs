using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Vehicle.MVC.ViewModels;
using AutoMapper;

namespace Vehicle.MVC.Controllers
{
    public class VehicleModelController : Controller
    {
        // GET: VehicleModel
        public ActionResult Index(int id,string sortOrder, string currentFilter, string searchString, int? page)
        {
            VehicleService vehicleService = new VehicleService();

            ViewBag.CurrentSort = sortOrder;
            ViewBag.MakeIdSortParm = sortOrder == "MakeId" ? "makeid_desc" : "MakeId";
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

            var vehicles = vehicleService.GetVehicleModels(id, sortOrder, currentFilter, searchString, page);

            List<VehicleModelViewModel> list = new List<VehicleModelViewModel>();

            foreach (var item in vehicles)
            {
                VehicleModelViewModel vehicleMakeViewModel = new VehicleModelViewModel();
                vehicleMakeViewModel = Mapper.Map<VehicleModelViewModel>(item);
                list.Add(vehicleMakeViewModel);
            }
            IPagedList<VehicleModelViewModel> pagedList = list.ToPagedList(pageNumber, pageSize);

            return View(pagedList);
        }
    }
}