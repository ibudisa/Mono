using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Service;
using Service.ViewModels;

namespace MonoProject.Controllers
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

               IPagedList <VehicleMakeViewModel> data= vehicleService.GetVehicleMakes(sortOrder, currentFilter, searchString, page);
                
                return View(data);
            
        }
    }
}