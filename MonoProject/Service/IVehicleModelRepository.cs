using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    interface IVehicleModelRepository:IRepository<VehicleModel>
    {
        VehicleModel GetVehicleModel(int id);
        void DeleteVehicleModel(int id);
    }
}
