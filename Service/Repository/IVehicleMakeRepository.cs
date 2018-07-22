using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IVehicleMakeRepository:IRepository<VehicleMake>
    {
        VehicleMake GetVehicleMake(int id);
        void DeleteVehicleMake(int id);
        IList<VehicleMake> GetVehicleMakes(string sortOrder, string currentFilter, string searchString, int? page);
        IList<VehicleMake> GetVehicleMakeById(int modelid);
    }
}
