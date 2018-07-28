using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic;
using DAL;
using DAL.Domain;
using DAL.Repositorys;

namespace Service
{
    public class VehicleMakeService 
    {

        private IVehicleMakeRepository dataRepository = new VehicleMakeRepository();

        public void Add(VehicleMake value)
        {
            dataRepository.Add(value);
        }

       

        public void DeleteVehicleMake(int id)
        {
            dataRepository.DeleteVehicleMake(id);
        }

       

        public IEnumerable<VehicleMake> GetVehicleMakes(string sortOrder, string currentFilter, string searchString, int? page)
        {
            IEnumerable<VehicleMake> list = dataRepository.GetVehicleMakes(sortOrder, currentFilter, searchString, page);

            return list;

        }

        public VehicleMake GetVehicleMake(int? id)
        {
           var vehiclemake= dataRepository.GetVehicleMake(id);

            return vehiclemake;
        }


        public void Update(VehicleMake value)
        {
            dataRepository.Update(value);
        }
        
    }
}
