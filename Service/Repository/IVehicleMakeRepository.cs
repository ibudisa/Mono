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
        IList<VehicleMake> GetVehicleMakes(int page = 1, int itemsPerPage = 30, string sortBy = "FirstName", bool reverse = false, string search = null);
        IList<VehicleMake> GetVehicleMakeById(int modelid);
    }
}
