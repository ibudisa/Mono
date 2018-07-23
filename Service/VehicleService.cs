using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;
using DAL;
using DAL.Domain;
using DAL.Repositorys;

namespace Service
{
    public class VehicleService 
    {

        private IDataRepository dataRepository = new DataRepository();

        public void Add(VehicleMake value)
        {
            dataRepository.Add(value);
        }

        public void Add(VehicleModel value)
        {
            dataRepository.Add(value);
        }

        public void DeleteVehicleMake(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteVehicleModel(int id)
        {
            throw new NotImplementedException();
        }

        

        public IEnumerable<VehicleMake> GetVehicleMakes(string sortOrder, string currentFilter, string searchString, int? page)
        {
            IEnumerable<VehicleMake> list = dataRepository.GetVehicleMakes(sortOrder, currentFilter, searchString, page);

            return list;

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

        

        public IEnumerable<VehicleModel> GetVehicleModels(int makeid,string sortOrder, string currentFilter, string searchString, int? page)
        {

            IEnumerable<VehicleModel> vehicleModel = dataRepository.GetVehicleModels(makeid, sortOrder, currentFilter, searchString, page);
            return vehicleModel;
        }

         

        public IEnumerable<VehicleModel> GetVehicleModels(string sortOrder, string currentFilter, string searchString, int? page)
        {
            throw new NotImplementedException();
        }
    }
}
