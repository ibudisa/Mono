using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
     public interface IVehicleModelRepository:IRepository<VehicleModel>
    {
        VehicleModel GetVehicleModel(int id);
        void DeleteVehicleModel(int id);
        IList<VehicleModel> GetAllVehicleModels(int page = 1, int itemsPerPage = 30, string sortBy = "FirstName", bool reverse = false, string search = null);
    }
}
