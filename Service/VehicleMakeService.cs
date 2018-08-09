using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;
using DAL;
using DAL.Domain;
using DAL.Repositorys;
using DAL.Models;

namespace Service
{
    public class VehicleMakeService 
    {

        private IVehicleMakeRepository dataRepository = new VehicleMakeRepository();

        public void Add(VehicleMakeCoreModel value)
        {
            dataRepository.Add(value);
        }

       

        public void DeleteVehicleMake(int id)
        {
            dataRepository.DeleteVehicleMake(id);
        }

       

        public IEnumerable<VehicleMakeCoreModel> GetVehicleMakes(VehicleMakeCoreModel model)
        {
            IQueryable<VehicleMakeCoreModel> list = dataRepository.GetVehicleMakes(model);

            return list;

        }

        public VehicleMakeCoreModel GetVehicleMake(int? id)
        {
           var vehiclemake= dataRepository.GetVehicleMake(id);

            return vehiclemake;
        }


        public void Update(VehicleMakeCoreModel value)
        {
            dataRepository.Update(value);
        }
        
    }
}
