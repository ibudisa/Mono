using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PagedList;

namespace Service
{
    public interface IVehicleMakeRepository:IRepository<VehicleMake>
    {
        VehicleMake GetVehicleMake(int id);
        void DeleteVehicleMake(int id);
        IPagedList<VehicleMakeViewModel> GetVehicleMakes(string sortOrder, string currentFilter, string searchString, int? page);
        IList<VehicleMakeViewModel> GetVehicleMakeById(int modelid);
    }
}
