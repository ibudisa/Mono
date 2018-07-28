namespace DAL.Migrations
{
    using DAL.Domain;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.Domain.VehicleContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
          
        }

        protected override void Seed(DAL.Domain.VehicleContext context)
        {
            var makes = new List<VehicleMake>
            {
            new VehicleMake{Name="BMW",Abrv="11"},
            new VehicleMake{Name="Opel",Abrv="12"},
            new VehicleMake{Name="Mercedes",Abrv="13"},

            };

            makes.ForEach(s => context.VehicleMakes.Add(s));
            context.SaveChanges();


            var models = new List<VehicleModel>
            {
            new VehicleModel{MakeId=1,Name="320d",Abrv="3333",},
             new VehicleModel{MakeId=2,Name="Insignia",Abrv="5555",},
              new VehicleModel{MakeId=3,Name="c 220cdi",Abrv="7775",},
            };
            models.ForEach(s => context.VehicleModels.Add(s));
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
