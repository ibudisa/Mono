using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Vehicle.MVC.ViewModels;
using AutoMapper;
using Vehicle.MVC.Repositorys;
using DAL.Models;

namespace Vehicle.MVC.Controllers
{
    public class VehicleModelController : Controller
    {
        // GET: VehicleModel
        public ActionResult Index(int? id,string sortOrder, string currentFilter, string searchString, int? page)
        {
            VehicleRepository vehicle = VehicleRepository.TheOnly;

            ViewBag.CurrentSort = sortOrder;
            ViewBag.MakeIdSortParm = sortOrder == "MakeId" ? "makeid_desc" : "MakeId";
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.AbrvSortParm = sortOrder == "Abrv" ? "abrv_desc" : "Abrv";

            ViewBag.Makeid = id;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            VehicleModelCoreModel model = new VehicleModelCoreModel();
            model.Filter = currentFilter;
            model.SearchString = searchString;
            model.SortValue = sortOrder;
            model.Page = page;

            PagedList<VehicleModelCoreModel> pagedList = vehicle.GetVehicleModels(id,model) as PagedList<VehicleModelCoreModel>;

            var outputList = Mapper.Map<PagedList<VehicleModelCoreModel>, PagedList<VehicleModelViewModel>>(pagedList);

            return View(outputList);
        }
    }
}