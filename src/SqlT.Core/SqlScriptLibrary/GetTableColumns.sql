create function [SqlT].[GetTableColumns]() returns table as return
	with intrinsic_types as 
	(
		select 
			t.system_type_id,
			t.user_type_id,
			t.name,
			t.max_length,
			t.precision,
			t.scale
		from 
			sys.types t 
		where 
			user_type_id = system_type_id
	), 
	data_types as (
		select 
			t.system_type_id,
			t.user_type_id,
			t.name as type_name,
			i.name as base_type_name,
			t.max_length,
			t.precision,
			t.scale
		from 
			sys.types t inner join intrinsic_types i on i.system_type_id = t.system_type_id	
	)
	select 
		s.name as SchemaName,
		t.name as ObjectName,
		c.name as ColumnName,
		c.column_id as ColumnPosition,
		x.type_name as DataTypeName,
		x.base_type_name as BaseDataTypeName,
		c.max_length as MaxDataLength,
		c.precision as NumericPrecision,
		c.scale as NumericScale,
		c.is_nullable as IsNullable
	from 
		sys.columns c 
		inner join sys.tables t on t.object_id = c.object_id
		inner join sys.schemas s on s.schema_id = t.schema_id
		inner join data_types x on x.system_type_id = c.system_type_id and x.user_type_id = c.user_type_id
