using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Service.ViewModels;

namespace MonoProject.Controllers
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

            IPagedList<VehicleModelViewModel> data = vehicleService.GetVehicleModels(id, sortOrder, currentFilter, searchString, page);

            return View();
        }
    }
}