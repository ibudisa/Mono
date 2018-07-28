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
using DAL.Domain;
using Vehicle.MVC.Repositorys;
using System.Net;
using System.Data.Entity.Infrastructure;

namespace Vehicle.MVC.Controllers
{
    public class VehicleMakeController : Controller
    {

       
        // GET: VehicleMake
         public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
            {
               VehicleRepository vehicle = VehicleRepository.TheOnly;

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


            IPagedList<VehicleMakeViewModel> pagedlist = vehicle.GetVehicleMakes(sortOrder, currentFilter, searchString, page);          

            return View(pagedlist);
            
        }

        public ActionResult Create()
        {
            var make = new VehicleMakeViewModel();
            
            return View(make);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Abrv,")]VehicleMakeViewModel make)
        {
            VehicleRepository vehicle = VehicleRepository.TheOnly;

            if (ModelState.IsValid)
            {
                vehicle.Add(make);
               
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {

            VehicleRepository vehicle = VehicleRepository.TheOnly;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var make = vehicle.GetVehicleMake(id);
            
            if (make == null)
            {
                return HttpNotFound();
            }
            return View(make);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VehicleMakeViewModel make)
        {
            VehicleRepository vehicle = VehicleRepository.TheOnly;
            if (make == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
                try
                {

                vehicle.Update(make); 
                   
                }
                catch (RetryLimitExceededException  ec/* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            VehicleRepository vehicle = VehicleRepository.TheOnly;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var make = vehicle.GetVehicleMake(id);
            if (make == null)
            {
                return HttpNotFound();
            }
            return View(make);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VehicleRepository vehicle = VehicleRepository.TheOnly;

            var make = vehicle.GetVehicleMake(id);
            
            vehicle.DeleteVehicleMake(id);

            return RedirectToAction("Index");
        }


        public ActionResult Details(int? id)
        {

            VehicleRepository vehicle = VehicleRepository.TheOnly;
            var d = vehicle.GetVehicleMake(id);

            return View(d);

        }

    }
}