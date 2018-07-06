--See: https://docs.microsoft.com/en-us/sql/t-sql/statements/sql-server-collation-name-transact-sql
create function [SqlT].[GetServerCollations]() returns table as return
	select 
		[Name] = c.[name],
		[CodePage] = COLLATIONPROPERTY([name], 'CodePage'),
		[LCID] = COLLATIONPROPERTY([name], 'LCID'),
		[ComparisonStyle] = COLLATIONPROPERTY([name], 'ComparisonStyle'),	
		[Version] = COLLATIONPROPERTY([name], 'Version'),
		[Description] = c.[description]
	from 
		sys.fn_helpcollations() c 
	where 
		[name] like 'SQL%'
GO
EXEC sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[SqlT].[ServerCollation]',
    @level0type = N'SCHEMA',
    @level0name = N'SqlT',
    @level1type = N'Function',
    @level1name = N'GetServerCollations'
GO



