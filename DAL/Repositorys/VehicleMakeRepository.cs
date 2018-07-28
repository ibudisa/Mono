using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Domain;
using System.Data.Entity;

namespace DAL.Repositorys
{
    public class VehicleMakeRepository : IVehicleMakeRepository
    {
        public void Add(VehicleMake value)
        {
            using (VehicleContext cont = new VehicleContext())
            {
                var vmake = cont.VehicleMakes.Where(a => a.Id == value.Id).FirstOrDefault();
                if (vmake == null)
                {
                    cont.VehicleMakes.Add(value);
                    cont.SaveChanges();

                }
            }
        }

        public void DeleteVehicleMake(int id)
        {
            VehicleMake vehicle;
            using (VehicleContext cont = new VehicleContext())
            {
                vehicle = cont.VehicleMakes.Where(a => a.Id == id).FirstOrDefault();
                if (vehicle != null)
                {
                    cont.VehicleMakes.Remove(vehicle);
                    cont.SaveChanges();

                }
            }
        }

        public VehicleMake GetVehicleMake(int? id)
        {
            VehicleMake vehicle;
            using (VehicleContext cont = new VehicleContext())
            {
                vehicle = cont.VehicleMakes.Where(a => a.Id == id).FirstOrDefault();
                 
            }
            return vehicle;
        }

       

        public IEnumerable<VehicleMake> GetVehicleMakes(string sortOrder, string currentFilter, string searchString, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            IEnumerable<VehicleMake> vehicles = null;

            using (VehicleContext cont = new VehicleContext())
            {
                if (searchString != null)
                {
                    vehicles = (from s in cont.VehicleMakes
                                where s.Name == searchString || s.Abrv == searchString
                                select s).ToList();
                }
                else
                {
                    vehicles = (from s in cont.VehicleMakes
                                select s).ToList();
                }
            }



            switch (sortOrder)
            {
                case "name_desc":
                    vehicles = vehicles.OrderByDescending(s => s.Name).ToList();
                    break;
                case "Name":
                    vehicles = vehicles.OrderBy(s => s.Name).ToList();
                    break;
                case "Abrv":
                    vehicles = vehicles.OrderBy(s => s.Abrv).ToList();
                    break;
                case "abrv_desc":
                    vehicles = vehicles.OrderByDescending(s => s.Abrv).ToList();
                    break;
                default:  // Name ascending 
                    vehicles = vehicles.OrderBy(s => s.Name).ToList();
                    break;
            }

            return vehicles;
        }

        public void Update(VehicleMake value)
        {
            if (value != null && value.Id > 0)
            {
                using (VehicleContext cts = new VehicleContext())
                {
                    var CurrentVehicle = cts.VehicleMakes.Where(a => a.Id == value.Id).SingleOrDefault();
                    if (CurrentVehicle != null)
                    {

                        CurrentVehicle.Name = value.Name;
                        CurrentVehicle.Abrv = value.Abrv;
                        

                        cts.VehicleMakes.Attach(CurrentVehicle);
                        cts.Entry(CurrentVehicle).State = EntityState.Modified;
                        cts.SaveChanges();
                    }
                }
            }
        }
    }
}
