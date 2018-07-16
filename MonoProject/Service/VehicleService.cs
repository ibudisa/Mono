using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class VehicleService : IVehicleService
    {
        public void Add(VehicleMake value)
        {
            throw new NotImplementedException();
        }

        public void Add(VehicleModel value)
        {
            throw new NotImplementedException();
        }

        public void DeleteVehicleMake(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteVehicleModel(int id)
        {
            throw new NotImplementedException();
        }

        public IList<VehicleMake> GetAll()
        {
            throw new NotImplementedException();
        }

        public VehicleMake GetVehicleMake(int id)
        {
            throw new NotImplementedException();
        }

        public VehicleModel GetVehicleModel(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(VehicleMake value)
        {
            throw new NotImplementedException();
        }

        public void Update(VehicleModel value)
        {
            throw new NotImplementedException();
        }

        IList<VehicleModel> IRepository<VehicleModel>.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
