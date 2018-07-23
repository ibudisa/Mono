using DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositorys
{
    public class DataRepository : IDataRepository
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

        public void DeleteVehicleMake(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteVehicleModel(int id)
        {
            throw new NotImplementedException();
        }

        public VehicleMake GetVehicleMake(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VehicleMake> GetVehicleMakeById(int modelid)
        {
            throw new NotImplementedException();
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

            List<VehicleMake> vehicles = new List<VehicleMake>();

            using (VehicleContext cont = new VehicleContext())
            {
                vehicles = (from s in cont.VehicleMakes
                            where s.Name == searchString || s.Abrv == searchString
                            select s).ToList();
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

        public VehicleModel GetVehicleModel(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VehicleModel> GetVehicleModels(int makeid,string sortOrder, string currentFilter, string searchString, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            List<VehicleModel> vehicles = new List<VehicleModel>();

            using (VehicleContext cont = new VehicleContext())
            {

                vehicles = (from s in cont.VehicleModels
                            where (s.Name == searchString || s.Abrv == searchString) && s.MakeId == makeid
                            select s).ToList();
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

        public void Update(VehicleMake value)
        {
            throw new NotImplementedException();
        }

        public void Update(VehicleModel value)
        {
            throw new NotImplementedException();
        }
    }
}
