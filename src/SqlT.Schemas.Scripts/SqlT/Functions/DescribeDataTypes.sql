create function [SqlT].[DescribeDataTypes]() returns table as return
	select 
		ServerName = @@SERVERNAME collate database_default,
		DatabaseName = db_name() collate database_default,
		SchemaName = s.[name] collate database_default,
		TypeName = t.[name] collate database_default, 
		IsUserDefined = t.is_user_defined,
		[MaxLength] = t.[max_length],
		[Precision] = t.[precision],
		[Scale] = t.[scale],
		IsNullable = t.is_nullable,
		IsClrType = t.is_assembly_type
	from sys.types t 
			inner join sys.schemas s on 
				t.schema_id = s.[schema_id] 
		where 
			t.is_table_type = 0
GO

EXEC sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[SqlT].[DataTypeDescription]',
    @level0type = N'SCHEMA',
    @level0name = N'SqlT',
    @level1type = N'Function',
    @level1name = N'DescribeDataTypes'
GO







