using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MonoProject.Models;
using Service;
using AutoMapper;

namespace MonoProject.Repository
{
    public class DataRepository : IDataRepository
    {
        private VehicleService vehicleService;

        public DataRepository()
        {
            vehicleService = new VehicleService();
        }

        public void AddVehicleMake(VehicleMakeViewModel value)
        {
            var data=  Mapper.Map<VehicleMake>(value);
            vehicleService.Add(data);
        }

        public void AddVehicleModel(VehicleModelViewModel value)
        {
            var data = Mapper.Map<VehicleModel>(value);
            vehicleService.Add(data);
        }

        public void DeleteVehicleMake(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteVehicleModel(int id)
        {
            throw new NotImplementedException();
        }

        public IList<VehicleMakeViewModel> GetAllVehicleMakes(int page = 1, int itemsPerPage = 30, string sortBy = "Name", bool reverse = false, string search = null)
        {
            var listmakes = vehicleService.GetAllVehicleMakes(page, itemsPerPage, sortBy, reverse, search);
            List<VehicleMakeViewModel> models = new List<VehicleMakeViewModel>();

            foreach(var item in listmakes)
            {
                var data = Mapper.Map<VehicleMakeViewModel>(item);
                models.Add(data);
            }

            return models;
        }

        public IList<VehicleModelViewModel> GetAllVehicleModels(int page, int itemsPerPage, string sortBy, bool reverse, string search)
        {
            var listmodels = vehicleService.GetAllVehicleModels(page, itemsPerPage, sortBy, reverse, search);
            List<VehicleModelViewModel> models = new List<VehicleModelViewModel>();

            foreach (var item in listmodels)
            {
                var data = Mapper.Map<VehicleModelViewModel>(item);
                models.Add(data);
            }

            return models;
        }

        public VehicleMakeViewModel GetVehicleMake(int id)
        {
            throw new NotImplementedException();
        }

        public VehicleModelViewModel GetVehicleModel(int id)
        {
            throw new NotImplementedException();
        }

        public IList<VehicleModelViewModel> GetVehicleModelById(int modelid)
        {
            throw new NotImplementedException();
        }

        public void UpdateVehicleMake(VehicleMakeViewModel value)
        {
            throw new NotImplementedException();
        }

        public void UpdateVehicleModel(VehicleModelViewModel value)
        {
            throw new NotImplementedException();
        }
    }
}