namespace SeoPoc.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _0001_CityDistrict : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.City",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 256),
                        SeoParameterValuesJson = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.District",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 256),
                        CityId = c.Int(nullable: false),
                        SeoParameterValuesJson = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.City", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.SeoUrlAlias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TitleFormat = c.String(),
                        Url = c.String(),
                        CityId = c.Int(),
                        DistrictId = c.Int(),
                        PriceFrom = c.Int(),
                        PriceTo = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.District", "CityId", "dbo.City");
            DropIndex("dbo.District", new[] { "CityId" });
            DropTable("dbo.SeoUrlAlias");
            DropTable("dbo.District");
            DropTable("dbo.City");
        }
    }
}
