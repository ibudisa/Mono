using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Domain;
using System.Data.Entity;

namespace DAL.Repositorys
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        private VehicleContext vehiclect = new VehicleContext();

        public void Add(VehicleModel value)
        {
            using (VehicleContext cont = new VehicleContext())
            {
                var vmodel = cont.VehicleModels.Where(a => a.Id == value.Id).FirstOrDefault();
                if (vmodel == null)
                {
                    cont.VehicleModels.Add(value);
                    cont.SaveChanges();

                }
            }
        }

        public void DeleteVehicleModel(int id)
        {
            VehicleModel vehicle;
            using (VehicleContext cont = new VehicleContext())
            {
                vehicle = cont.VehicleModels.Where(a => a.Id == id).FirstOrDefault();
                if (vehicle != null)
                {
                    cont.VehicleModels.Remove(vehicle);
                    cont.SaveChanges();

                }
            }
        }

        public VehicleModel GetVehicleModel(int id)
        {
            VehicleModel vehicle;
            using (VehicleContext cont = new VehicleContext())
            {
                vehicle = cont.VehicleModels.Where(a => a.Id == id).FirstOrDefault();

            }
            return vehicle;
        }

        public IEnumerable<VehicleModel> GetVehicleModels(int? makeid, string sortOrder, string currentFilter, string searchString, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            IEnumerable<VehicleModel> vehicles = null;

            if (searchString != null)
            {

                vehicles = from s in vehiclect.VehicleModels
                           where (s.Name == searchString || s.Abrv == searchString) && s.MakeId == makeid
                           select s;

            }
            else
            {
                vehicles = (from s in vehiclect.VehicleModels
                            select s);
            }


            switch (sortOrder)
            {
                case "makeid_desc":
                    vehicles = vehicles.OrderByDescending(s => s.Name).ToList();
                    break;
                case "MakeId":
                    vehicles = vehicles.OrderBy(s => s.Name).ToList();
                    break;
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

        public IEnumerable<VehicleModel> GetVehicleModelsById(int makeid)
        {
             
            IEnumerable<VehicleModel> vehicles;
            using (VehicleContext cont = new VehicleContext())
            {
                vehicles = from a in cont.VehicleModels
                           where a.MakeId==makeid
                           select a;

            }
            return vehicles;
             
        }

        public void Update(VehicleModel value)
        {
            if (value != null && value.Id > 0)
            {
                using (VehicleContext cts = new VehicleContext())
                {
                    var CurrentVehicle = cts.VehicleModels.Where(a => a.Id == value.Id).SingleOrDefault();
                    if (CurrentVehicle != null)
                    {
                        CurrentVehicle.MakeId = value.MakeId;
                        CurrentVehicle.Name = value.Name;
                        CurrentVehicle.Abrv = value.Abrv;


                        cts.VehicleModels.Attach(CurrentVehicle);
                        cts.Entry(CurrentVehicle).State = EntityState.Modified;
                        cts.SaveChanges();
                    }
                }
            }
        }
    }
}
