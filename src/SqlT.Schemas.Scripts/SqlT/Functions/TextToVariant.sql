create function [SqlT].[TextToVariant](@SysTypeName sysname, @Text nvarchar(250))
	returns sql_variant as
	begin
		declare @Result sql_variant;

		set @Result = 
			case @SysTypeName
				when 'bit' then cast(convert(bit, @Text) as sql_variant)
				when 'int' then cast(convert(int, @Text) as sql_variant)
				when 'tinyint' then cast(convert(tinyint,  @Text) as sql_variant)
				when 'smallint' then cast(convert(smallint, @Text) as sql_variant)
				when 'bigint' then cast(convert(bigint, @Text) as sql_variant)
		
				when 'datetime2' then cast(convert(datetime2, @Text) as sql_variant)
				when 'datetime' then cast(convert(datetime, @Text) as sql_variant)
				when 'smalldatetime' then cast(convert(smalldatetime, @Text) as sql_variant)
				when 'date' then cast(convert(date, @Text) as sql_variant)
				when 'time' then cast(convert(time, @Text) as sql_variant)
				when 'datetimeoffset' then cast(convert(datetimeoffset, @Text) as sql_variant)

				when 'money' then cast(convert(money, @Text) as sql_variant)
				when 'smallmoney' then cast(convert(smallmoney, @Text) as sql_variant)
		
				when 'decimal' then cast(convert(decimal, @Text) as sql_variant)
				when 'numeric' then cast(convert(numeric, @Text) as sql_variant)
		
				when 'float' then cast(convert(float, @Text) as sql_variant)
				when 'real' then cast(convert(real, @Text) as sql_variant)
		

				when 'char' then cast(convert(char, @Text) as sql_variant)
				when 'uniqueidentifier' then cast(convert(uniqueidentifier, @Text) as sql_variant)
				when 'binary' then cast(convert(binary, @Text) as sql_variant)
				when 'varbinary' then cast(convert(varbinary, @Text) as sql_variant)
				when 'varchar' then cast(convert(varchar, @Text) as sql_variant)
				else cast(@Text as sql_variant) end
	
		return @Result
	END
