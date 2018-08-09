using DAL.Domain;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DAL.Repositorys
{
    public interface IVehicleMakeRepository
    {
        VehicleMakeCoreModel GetVehicleMake(int? id);
        void DeleteVehicleMake(int id);
        IQueryable<VehicleMakeCoreModel> GetVehicleMakes(VehicleMakeCoreModel model);
       
        void Add(VehicleMakeCoreModel value);
        void Update(VehicleMakeCoreModel value);
    }
}
