namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Vehiclev1 : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.VehicleMake",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Name = c.String(unicode: false),
            //            Abrv = c.String(unicode: false),
            //        })
            //    .PrimaryKey(t => t.Id);
            
            //CreateTable(
            //    "dbo.VehicleModel",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            MakeId = c.Int(),
            //            Name = c.String(unicode: false),
            //            Abrv = c.String(unicode: false),
            //        })
            //    .PrimaryKey(t => t.Id)
            //    .ForeignKey("dbo.VehicleMake", t => t.MakeId)
            //    .Index(t => t.MakeId);
            
        }
        
        public override void Down()
        {
            //DropForeignKey("dbo.VehicleModel", "MakeId", "dbo.VehicleMake");
            //DropIndex("dbo.VehicleModel", new[] { "MakeId" });
            //DropTable("dbo.VehicleModel");
            //DropTable("dbo.VehicleMake");
        }
    }
}
