truncate table [dbo].[CitySeoParameter]
truncate table [dbo].[DistrictSeoParameter]
truncate table [dbo].[PhraseSeoParameter]
truncate table [dbo].[AliasSeoParameter]
truncate table [dbo].[ArticleGroupSeoParameter]
delete from [dbo].[District]
GO

delete from [dbo].City
where Id > 2
Go

select * from dbo.City