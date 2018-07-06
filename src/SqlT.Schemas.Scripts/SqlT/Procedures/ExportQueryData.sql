create procedure [SqlT].ExportQueryData
(
	@Query nvarchar(500),
	@DstFile nvarchar(500)
)
as
begin

declare @var_Sql varchar(8000) =
	'bcp ' + @Query + ' queryout  "' + @DstFile + '" -c -T'

exec xp_cmdshell @var_Sql

end