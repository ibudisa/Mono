using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Domain;
using DAL.Models;

namespace DAL.Repositorys
{
     public interface IVehicleModelRepository 
    {
        VehicleModelCoreModel GetVehicleModel(int id);
        void DeleteVehicleModel(int id);
        IQueryable<VehicleModelCoreModel> GetVehicleModels(int? makeid,VehicleModelCoreModel model);
        void Add(VehicleModelCoreModel value);
        void Update(VehicleModelCoreModel value);
        IQueryable<VehicleModelCoreModel> GetVehicleModelsById(int modelid);
    }
}
