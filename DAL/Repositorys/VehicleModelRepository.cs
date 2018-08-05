using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Domain;
using System.Data.Entity;
using DAL.Models;

namespace DAL.Repositorys
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        private VehicleContext context;

        public VehicleModelRepository()
        {
            this.context = new VehicleContext();
        }

        public void Add(VehicleModelCoreModel value)
        {
            var vehicleModel = AutoMapper.Mapper.Map<VehicleModel>(value);

            var vmodel = context.VehicleModels.Where(a => a.Id == value.Id).FirstOrDefault();
                if (vmodel == null)
                {
                    context.VehicleModels.Add(vehicleModel);
                    context.SaveChanges();

                }
            
        }

        public void DeleteVehicleModel(int id)
        {
            VehicleModel vehicle;
           
                vehicle = context.VehicleModels.Where(a => a.Id == id).FirstOrDefault();
                if (vehicle != null)
                {
                    context.VehicleModels.Remove(vehicle);
                    context.SaveChanges();

                }
           
        }

        public VehicleModelCoreModel GetVehicleModel(int id)
        {
            VehicleModel vehicle;

            vehicle = context.VehicleModels.Where(a => a.Id == id).FirstOrDefault();

            var vehicleModel = AutoMapper.Mapper.Map<VehicleModelCoreModel>(vehicle);

            return vehicleModel;
        }

        public IQueryable<VehicleModelCoreModel> GetVehicleModels(int? makeid, string sortOrder, string currentFilter, string searchString, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            IQueryable<VehicleModel> vehicles = null;

            if (searchString != null)
            {

                vehicles = from s in context.VehicleModels
                           where (s.Name == searchString || s.Abrv == searchString) && s.MakeId == makeid
                           select s;

            }
            else
            {
                vehicles = (from s in context.VehicleModels
                            select s);
            }


            switch (sortOrder)
            {
                case "makeid_desc":
                    vehicles = vehicles.OrderByDescending(s => s.Name);
                    break;
                case "MakeId":
                    vehicles = vehicles.OrderBy(s => s.Name);
                    break;
                case "name_desc":
                    vehicles = vehicles.OrderByDescending(s => s.Name);
                    break;
                case "Name":
                    vehicles = vehicles.OrderBy(s => s.Name);
                    break;
                case "Abrv":
                    vehicles = vehicles.OrderBy(s => s.Abrv);
                    break;
                case "abrv_desc":
                    vehicles = vehicles.OrderByDescending(s => s.Abrv);
                    break;
                default:  // Name ascending 
                    vehicles = vehicles.OrderBy(s => s.Name);
                    break;
            }

            List<VehicleModelCoreModel> list = new List<VehicleModelCoreModel>();

            foreach (var item in vehicles)
            {
                VehicleModelCoreModel vehicleMakeViewModel = new VehicleModelCoreModel();
                vehicleMakeViewModel = AutoMapper.Mapper.Map<VehicleModelCoreModel>(item);
                list.Add(vehicleMakeViewModel);
            }

            return list.AsQueryable();
        }

        public IQueryable<VehicleModelCoreModel> GetVehicleModelsById(int makeid)
        {
             
            IQueryable<VehicleModel> vehicles;
            
                vehicles = from a in context.VehicleModels
                           where a.MakeId==makeid
                           select a;

            List<VehicleModelCoreModel> list = new List<VehicleModelCoreModel>();

            foreach (var item in vehicles)
            {
                VehicleModelCoreModel vehicleMakeViewModel = new VehicleModelCoreModel();
                vehicleMakeViewModel = AutoMapper.Mapper.Map<VehicleModelCoreModel>(item);
                list.Add(vehicleMakeViewModel);
            }
            return list.AsQueryable();
             
        }

        public void Update(VehicleModelCoreModel value)
        {
            if (value != null && value.Id > 0)
            {
                
                    var CurrentVehicle = context.VehicleModels.Where(a => a.Id == value.Id).SingleOrDefault();
                    if (CurrentVehicle != null)
                    {
                        CurrentVehicle.MakeId = value.MakeId;
                        CurrentVehicle.Name = value.Name;
                        CurrentVehicle.Abrv = value.Abrv;


                        context.VehicleModels.Attach(CurrentVehicle);
                        context.Entry(CurrentVehicle).State = EntityState.Modified;
                        context.SaveChanges();
                    }
                 
            }
        }
    }
}
