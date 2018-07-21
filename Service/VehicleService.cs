using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;

namespace Service
{
    public class VehicleService : IVehicleService
    {
        public void Add(VehicleMake value)
        {
            using (VehicleContext angular = new VehicleContext())
            {
                var vmake = angular.VehicleMakes.Where(a => a.Id == value.Id).FirstOrDefault();
                if (vmake == null)
                {
                    angular.VehicleMakes.Add(value);
                    angular.SaveChanges();

                }
            }
        }

        public void Add(VehicleModel value)
        {
            using (VehicleContext angular = new VehicleContext())
            {
                var vmodel = angular.VehicleModels.Where(a => a.Id == value.Id).FirstOrDefault();
                if (vmodel == null)
                {
                    angular.VehicleModels.Add(value);
                    angular.SaveChanges();

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

        

        public IList<VehicleMake> GetVehicleMakes(int page = 1, int itemsPerPage = 30, string sortBy = "Name", bool reverse = false, string search = null)
        {
            List<VehicleMake> vehicles = new List<VehicleMake>();

            using (VehicleContext angular = new VehicleContext())
            {
                vehicles = angular.VehicleMakes.ToList();
            }

                // searching
                if (!string.IsNullOrWhiteSpace(search))
                {
                    search = search.ToLower();
                    vehicles = vehicles.Where(x =>
                    x.Name.ToLower().Contains(search) ||
                    x.Abrv.ToLower().Contains(search)).ToList();
                }

            // sorting (done with the System.Linq.Dynamic library available on NuGet)
            vehicles = vehicles.OrderBy(sortBy + (reverse ? " descending" : "")).ToList();

            // paging
            var vehiclesPaged = vehicles.Skip((page - 1) * itemsPerPage).Take(itemsPerPage).ToList();

            return vehiclesPaged;
        
    }

        public VehicleMake GetVehicleMake(int id)
        {
            throw new NotImplementedException();
        }

        public IList<VehicleMake> GetVehicleMakeById(int modelid)
        {
            throw new NotImplementedException();
        }

        public VehicleModel GetVehicleModel(int id)
        {
            throw new NotImplementedException();
        }

        public IList<VehicleModel> GetVehicleModelById(int modelid)
        {
            throw new NotImplementedException();
        }

        public void Update(VehicleMake value)
        {
            throw new NotImplementedException();
        }

        public void Update(VehicleModel value)
        {
            throw new NotImplementedException();
        }

        

        public IList<VehicleModel> GetVehicleModels(int page, int itemsPerPage, string sortBy , bool reverse , string search )
        {
            List<VehicleModel> vehicles = new List<VehicleModel>();

            using (VehicleContext angular = new VehicleContext())
            {
                vehicles = angular.VehicleModels.ToList();
            }

            // searching
            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();
                vehicles = vehicles.Where(x =>
                x.Name.ToLower().Contains(search) ||
                x.Abrv.ToLower().Contains(search)).ToList();
            }

            // sorting (done with the System.Linq.Dynamic library available on NuGet)
            vehicles = vehicles.OrderBy(sortBy + (reverse ? " descending" : "")).ToList();

            // paging
            var vehiclesPaged = vehicles.Skip((page - 1) * itemsPerPage).Take(itemsPerPage).ToList();

            return vehiclesPaged;
        }
    }
}
