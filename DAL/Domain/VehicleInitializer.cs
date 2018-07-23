using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace DAL.Domain
{
    public class VehicleInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<VehicleContext>
    {
        protected override void Seed(VehicleContext context)
        {
            var makes = new List<VehicleMake>
            {
            new VehicleMake{Name="BMW",Abrv="11"},
            new VehicleMake{Name="Opel",Abrv="12"},
            new VehicleMake{Name="Mercedes",Abrv="13"},

            };

            makes.ForEach(s => context.VehicleMakes.Add(s));
            context.SaveChanges();
            base.Seed(context);
        }
    }
}