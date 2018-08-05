using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Models;
using DAL.Domain;

namespace DAL.Mapper
{
    public class ModelMapperProfile:Profile
    {
        public ModelMapperProfile()
        {
            CreateMap<VehicleMake, VehicleMakeCoreModel>().ReverseMap();
            CreateMap<VehicleModel, VehicleModelCoreModel>().ReverseMap();
        }

        public override string ProfileName
        {
            get { return "DomainToCoreModelMappings"; }
        }
        
        
        
    }
}
