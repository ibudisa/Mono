using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositorys;
using DAL.Domain;
using DAL.Models;

namespace Service
{
    public class VehicleModelService
    {
        private IVehicleModelRepository repository = new VehicleModelRepository();

        public VehicleModelCoreModel GetVehicleModel(int id)
        {
            var vehiclemodel = repository.GetVehicleModel(id);

            return vehiclemodel;
        }

        public IQueryable<VehicleModelCoreModel> GetVehicleModelById(int makeid)
        {
            var models = repository.GetVehicleModelsById(makeid);

            return models;
        }

        public IQueryable<VehicleModelCoreModel> GetVehicleModels(int? makeid, string sortOrder, string currentFilter, string searchString, int? page)
        {

            IQueryable<VehicleModelCoreModel> vehicleModel = repository.GetVehicleModels(makeid, sortOrder, currentFilter, searchString, page);
            return vehicleModel;
        }
 

        public void Add(VehicleModelCoreModel value)
        {
            repository.Add(value);
        }

        public void DeleteVehicleModel(int id)
        {
            repository.DeleteVehicleModel(id);
        }
        public void Update(VehicleModelCoreModel value)
        {
            repository.Update(value);
        }
    }
}
