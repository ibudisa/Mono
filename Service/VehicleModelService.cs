using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositorys;
using DAL.Domain;

namespace Service
{
    public class VehicleModelService
    {
        private IVehicleModelRepository repository = new VehicleModelRepository();

        public VehicleModel GetVehicleModel(int id)
        {
            var vehiclemodel = repository.GetVehicleModel(id);

            return vehiclemodel;
        }

        public IEnumerable<VehicleModel> GetVehicleModelById(int makeid)
        {
            var models = repository.GetVehicleModelsById(makeid);

            return models;
        }

        public IEnumerable<VehicleModel> GetVehicleModels(int? makeid, string sortOrder, string currentFilter, string searchString, int? page)
        {

            IEnumerable<VehicleModel> vehicleModel = repository.GetVehicleModels(makeid, sortOrder, currentFilter, searchString, page);
            return vehicleModel;
        }
 

        public void Add(VehicleModel value)
        {
            repository.Add(value);
        }

        public void DeleteVehicleModel(int id)
        {
            repository.DeleteVehicleModel(id);
        }
        public void Update(VehicleModel value)
        {
            repository.Update(value);
        }
    }
}
