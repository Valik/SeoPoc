namespace SeoPoc.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _0002SiteInternalName : DbMigration
    {
        public override void Up()
        {
            Sql(@"
SET IDENTITY_INSERT dbo.City ON
INSERT INTO dbo.City (Id, Name)
     VALUES 
        (1, N'Санкт-Петербург'),
        (2, N'Москва')
SET IDENTITY_INSERT dbo.City OFF
GO

ALTER TABLE dbo.City ADD InternalName NVARCHAR(256) NULL
GO

UPDATE dbo.City SET InternalName =
CASE Id
WHEN 1 THEN N'spb'
WHEN 2 THEN N'msk'
END
GO

ALTER TABLE dbo.City ALTER COLUMN InternalName NVARCHAR(256) NOT NULL
GO
");
        }
        
        public override void Down()
        {
            Sql(@"");
        }
    }
}
