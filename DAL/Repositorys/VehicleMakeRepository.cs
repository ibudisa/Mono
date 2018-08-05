using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Domain;
using System.Data.Entity;
using DAL.Models;
using AutoMapper;


namespace DAL.Repositorys
{
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        private VehicleContext context;

        public VehicleMakeRepository()
        {
            this.context = new VehicleContext();
        }

        public void Add(VehicleMakeCoreModel value)
        {
            var vehicleMake =AutoMapper.Mapper.Map<VehicleMake>(value);
            var vmake = context.VehicleMakes.Where(a => a.Id == value.Id).FirstOrDefault();
            if (vmake == null)
            {
                context.VehicleMakes.Add(vehicleMake);
                context.SaveChanges();

            }
             
        }

        public void DeleteVehicleMake(int id)
        {
            VehicleMake vehicle;
              vehicle = context.VehicleMakes.Where(a => a.Id == id).FirstOrDefault();
                if (vehicle != null)
                {
                    context.VehicleMakes.Remove(vehicle);
                    context.SaveChanges();

                }
            
        }

        public VehicleMakeCoreModel GetVehicleMake(int? id)
        {
            VehicleMake vehicle;
            
            vehicle = context.VehicleMakes.Where(a => a.Id == id).FirstOrDefault();

            var vehicleMake = AutoMapper.Mapper.Map<VehicleMakeCoreModel>(vehicle);

            return vehicleMake;
        }

       

        public IQueryable<VehicleMakeCoreModel> GetVehicleMakes(string sortOrder, string currentFilter, string searchString, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            IQueryable<VehicleMake> vehicles = null;

              if (searchString != null)
                {
                    vehicles = from s in context.VehicleMakes
                                where s.Name == searchString || s.Abrv == searchString
                                select s;
                }
                else
                {
                vehicles = from s in context.VehicleMakes
                           select s;
                }
            



            switch (sortOrder)
            {
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

            List<VehicleMakeCoreModel> list = new List<VehicleMakeCoreModel>();

            foreach (var item in vehicles)
            {
                VehicleMakeCoreModel vehicleMakeViewModel = new VehicleMakeCoreModel();
                vehicleMakeViewModel =AutoMapper.Mapper.Map<VehicleMakeCoreModel>(item);
                list.Add(vehicleMakeViewModel);
            }

            return list.AsQueryable();
        }

        public void Update(VehicleMakeCoreModel value)
        {
           var vehicleMakeViewModel = AutoMapper.Mapper.Map<VehicleMake>(value);
            if (value != null && value.Id > 0)
            {
                
                    var CurrentVehicle = context.VehicleMakes.Where(a => a.Id == value.Id).SingleOrDefault();
                    if (CurrentVehicle != null)
                    {

                        CurrentVehicle.Name = value.Name;
                        CurrentVehicle.Abrv = value.Abrv;
                        

                        context.VehicleMakes.Attach(CurrentVehicle);
                        context.Entry(CurrentVehicle).State = EntityState.Modified;
                        context.SaveChanges();
                    }
                 
            }
        }
    }
}
