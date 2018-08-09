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

     

        public IList<VehicleMakeCoreModel> GetVehicleMakes(VehicleMakeCoreModel model)
        {
            int pageSize = 3;
            int pageNumber = (model.Page ?? 1);

        

            var vehicles = servicemake.GetVehicleMakes(model);

            //Mapper.Initialize(cfg => {
            //    cfg.CreateMap<VehicleMake, VehicleMakeViewModel>();
            //    /* etc */
            //});

            //foreach (var item in vehicles)
            //{
            //    VehicleMakeViewModel vehicleMakeViewModel = new VehicleMakeViewModel();
            //    vehicleMakeViewModel = Mapper.Map<VehicleMakeViewModel>(item);
            //    list.Add(vehicleMakeViewModel);
            //}
            IList<VehicleMakeCoreModel> pagedList = vehicles.Skip(pageNumber - 1).Take(pageSize).ToList();

            return pagedList;
        }

        public VehicleModelViewModel GetVehicleModel(int id)
        {
            var model = servicemodel.GetVehicleModel(id);

            VehicleModelViewModel mapped = Mapper.Map<VehicleModelViewModel>(model);

            return mapped;
        }

        public IPagedList<VehicleModelCoreModel> GetVehicleModels(int? makeid,VehicleModelCoreModel model)
        {
            int pageSize = 3;
            int pageNumber = (model.Page ?? 1);

            //List<VehicleModelViewModel> list = new List<VehicleModelViewModel>();

            var vehicles = servicemodel.GetVehicleModels(makeid,model);

            //Mapper.Initialize(cfg => {
            //    cfg.CreateMap<VehicleMake, VehicleMakeViewModel>();
            //    /* etc */
            //});

            //foreach (var item in vehicles)
            //{
            //    VehicleModelViewModel vehicleMakeViewModel = new VehicleModelViewModel();
            //    vehicleMakeViewModel = Mapper.Map<VehicleModelViewModel>(item);
            //    list.Add(vehicleMakeViewModel);
            //}
            IPagedList<VehicleModelCoreModel> pagedList = vehicles.ToPagedList(pageNumber, pageSize);

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
