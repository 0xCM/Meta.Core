declare 
	@DbName sysname = db_name(),
	@DbType nvarchar(75) 
		= (select cast([value] as nvarchar(75)) from sys.extended_properties  p 
				where  p.class = 0 and p.[name] = 'SqlT_DbType')


exec [MetaFlow].[PF].[RegisterHostDatabase] @DbName, @DbType