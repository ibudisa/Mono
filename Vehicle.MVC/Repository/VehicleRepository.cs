using DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;
using Vehicle.MVC.ViewModels;
using AutoMapper;
using PagedList;
using DAL.Models;

namespace Vehicle.MVC.Repositorys
{
    public class VehicleRepository
    {
        private VehicleMakeService servicemake = new Service.VehicleMakeService();
        private VehicleModelService servicemodel = new VehicleModelService();

        private static readonly VehicleRepository theOneAndOnly;

        static VehicleRepository()
        {
            theOneAndOnly = new VehicleRepository();
        }
        public static VehicleRepository TheOnly
        {
            get { return theOneAndOnly; }
        }

        private VehicleRepository()
        {
        }

         
     

        public void Add(VehicleMakeViewModel value)
        {
             
            var mapped = Mapper.Map<VehicleMakeCoreModel>(value);
            servicemake.Add(mapped);
        }

        public void Add(VehicleModelViewModel value)
        {
            var mapped = Mapper.Map<VehicleModelCoreModel>(value);
            servicemodel.Add(mapped);
        }

        public void DeleteVehicleMake(int id)
        {
            servicemake.DeleteVehicleMake(id);
        }

        public void DeleteVehicleModel(int id)
        {
            servicemodel.DeleteVehicleModel(id);
        }

        public VehicleMakeViewModel GetVehicleMake(int? id)
        {
            var item = servicemake.GetVehicleMake(id);
            var mapped = Mapper.Map<VehicleMakeViewModel>(item);
            return mapped;
        }

     

        public IPagedList<VehicleMakeViewModel> GetVehicleMakes(string sortOrder, string currentFilter, string searchString, int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            List<VehicleMakeViewModel> list = new List<VehicleMakeViewModel>();

            var vehicles = servicemake.GetVehicleMakes(sortOrder, currentFilter, searchString, page);

            //Mapper.Initialize(cfg => {
            //    cfg.CreateMap<VehicleMake, VehicleMakeViewModel>();
            //    /* etc */
            //});

            foreach (var item in vehicles)
            {
                VehicleMakeViewModel vehicleMakeViewModel = new VehicleMakeViewModel();
                vehicleMakeViewModel = Mapper.Map<VehicleMakeViewModel>(item);
                list.Add(vehicleMakeViewModel);
            }
            IPagedList<VehicleMakeViewModel> pagedList = list.ToPagedList(pageNumber, pageSize);

            return pagedList;
        }

        public VehicleModelViewModel GetVehicleModel(int id)
        {
            var model = servicemodel.GetVehicleModel(id);

            VehicleModelViewModel mapped = Mapper.Map<VehicleModelViewModel>(model);

            return mapped;
        }

        public IPagedList<VehicleModelViewModel> GetVehicleModels(int? makeid,string sortOrder, string currentFilter, string searchString, int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);

            List<VehicleModelViewModel> list = new List<VehicleModelViewModel>();

            var vehicles = servicemodel.GetVehicleModels(makeid,sortOrder, currentFilter, searchString, page);

            //Mapper.Initialize(cfg => {
            //    cfg.CreateMap<VehicleMake, VehicleMakeViewModel>();
            //    /* etc */
            //});

            foreach (var item in vehicles)
            {
                VehicleModelViewModel vehicleMakeViewModel = new VehicleModelViewModel();
                vehicleMakeViewModel = Mapper.Map<VehicleModelViewModel>(item);
                list.Add(vehicleMakeViewModel);
            }
            IPagedList<VehicleModelViewModel> pagedList = list.ToPagedList(pageNumber, pageSize);

            return pagedList;
    
        }

        public void Update(VehicleMakeViewModel value)
        {
            var mapped = Mapper.Map<VehicleMakeCoreModel>(value);
            servicemake.Update(mapped);
        }

        public void Update(VehicleModelViewModel value)
        {
            var mapped = Mapper.Map<VehicleModelCoreModel>(value);
            servicemodel.Update(mapped);
        }

      
    }
}
