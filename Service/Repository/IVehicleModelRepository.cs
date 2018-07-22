using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PagedList;

namespace Service
{
     public interface IVehicleModelRepository:IRepository<VehicleModel>
    {
        VehicleModel GetVehicleModel(int id);
        void DeleteVehicleModel(int id);
        IPagedList<VehicleModelViewModel> GetVehicleModels(string sortOrder, string currentFilter, string searchString, int? page);
    }
}
