using DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DAL.Repositorys
{
    public interface IVehicleMakeRepository
    {
        VehicleMake GetVehicleMake(int? id);
        void DeleteVehicleMake(int id);
        IEnumerable<VehicleMake> GetVehicleMakes(string sortOrder, string currentFilter, string searchString, int? page);
       
        void Add(VehicleMake value);
        void Update(VehicleMake value);
    }
}
