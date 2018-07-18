using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Service;
using MonoProject.Models;

namespace MonoProject.Repository
{
    public interface IDataRepository
    {
        void AddVehicleMake(VehicleMakeViewModel value);
        void AddVehicleModel(VehicleModelViewModel value);
        void DeleteVehicleMake(int id);
        void DeleteVehicleModel(int id);
        IList<VehicleMakeViewModel> GetAllVehicleMakes(int page = 1, int itemsPerPage = 30, string sortBy = "Name", bool reverse = false, string search = null);
        VehicleMakeViewModel GetVehicleMake(int id);
        VehicleModelViewModel GetVehicleModel(int id);
        IList<VehicleModelViewModel> GetVehicleModelById(int modelid);
        void UpdateVehicleMake(VehicleMakeViewModel value);
        void UpdateVehicleModel(VehicleModelViewModel value);
        IList<VehicleModelViewModel> GetAllVehicleModels(int page, int itemsPerPage, string sortBy, bool reverse, string search);
     
    }
}