using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Domain;


namespace DAL.Repositorys
{
     public interface IVehicleModelRepository 
    {
        VehicleModel GetVehicleModel(int id);
        void DeleteVehicleModel(int id);
        IEnumerable<VehicleModel> GetVehicleModels(int? makeid, string sortOrder, string currentFilter, string searchString, int? page);
        void Add(VehicleModel value);
        void Update(VehicleModel value);
        IEnumerable<VehicleModel> GetVehicleModelsById(int modelid);
    }
}
