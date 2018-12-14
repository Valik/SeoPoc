namespace SeoPoc.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _0002_SeoParams : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DistrictSeoParameter",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(maxLength: 256),
                        Alias = c.String(maxLength: 256),
                        DistrictId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.District", t => t.DistrictId, cascadeDelete: true)
                .Index(t => t.DistrictId);
            
            CreateTable(
                "dbo.CitySeoParameter",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(maxLength: 256),
                        Alias = c.String(maxLength: 256),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            DropColumn("dbo.City", "SeoParameterValuesJson");
            DropColumn("dbo.District", "SeoParameterValuesJson");
        }
        
        public override void Down()
        {
            AddColumn("dbo.District", "SeoParameterValuesJson", c => c.String());
            AddColumn("dbo.City", "SeoParameterValuesJson", c => c.String());
            DropForeignKey("dbo.CitySeoParameter", "CityId", "dbo.City");
            DropForeignKey("dbo.DistrictSeoParameter", "DistrictId", "dbo.District");
            DropIndex("dbo.CitySeoParameter", new[] { "CityId" });
            DropIndex("dbo.DistrictSeoParameter", new[] { "DistrictId" });
            DropTable("dbo.CitySeoParameter");
            DropTable("dbo.DistrictSeoParameter");
        }
    }
}
