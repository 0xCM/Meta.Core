declare 
	@SchemaExists bit 
		= case
			when schema_id('SqlT') is null then 1 else 0 end;

declare @Sql  nvarchar(250) 
		= case  @SchemaExists 
					when 1  
						then 'raiserror(''SqlT schema already exists'',0,1)'
					else 'create schema SqlT'
				end;
			
exec @Sql;

drop function if exists [SqlT].[Binary2Int]
GO

--Taken from http://ariely.info/Blog/tabid/83/EntryId/169/T-SQL-Converting-between-Decimal-Binary-and-Hexadecimal.aspx
create function [SqlT].[Binary2Int] (@i varchar(16)) returns int as begin
    set @i = right( replicate('0',16) + @i, 16)
    return
        substring(@i, 1,1) * 32768 +
        substring(@i, 2,1) * 16384 +
        substring(@i, 3,1) *  8192 +
        substring(@i, 4,1) *  4096 +
        substring(@i, 5,1) *  2048 +
        substring(@i, 6,1) *  1024 +
        substring(@i, 7,1) *   512 +
        substring(@i, 8,1) *   256 +
        substring(@i, 9,1) *   128 +
        substring(@i,10,1) *    64 +
        substring(@i,11,1) *    32 +
        substring(@i,12,1) *    16 +
        substring(@i,13,1) *     8 +
        substring(@i,14,1) *     4 +
        substring(@i,15,1) *     2 +
        substring(@i,16,1) *     1
END;
GO

drop function if exists [SqlT].[DecimalToHex]
GO

--Taken from http://ariely.info/Blog/tabid/83/EntryId/169/T-SQL-Converting-between-Decimal-Binary-and-Hexadecimal.aspx
create function [SqlT].[DecimalToHex](@i int) returns varbinary(16) begin
    return convert(varbinary(16),@i)
end
GO

drop function if exists [SqlT].[HexToDecimal]
GO

--Taken from http://ariely.info/Blog/tabid/83/EntryId/169/T-SQL-Converting-between-Decimal-Binary-and-Hexadecimal.aspx
create function [SqlT].[HexToDecimal](@i int) returns varbinary(16) begin
    return convert(varbinary(16),@i)
end
GO

drop function if exists [SqlT].[IntToBinary]
GO

--Taken from http://ariely.info/Blog/tabid/83/EntryId/169/T-SQL-Converting-between-Decimal-Binary-and-Hexadecimal.aspx
-- MAX VALUE: 65535 which is binary 1111111111111111
create function [SqlT].[Int2Binary] (@i int) returns nvarchar(16) as begin
    return
        case when convert(varchar(16), @i & 32768 ) > 0 then '1' else '0'   end +
        case when convert(varchar(16), @i & 16384 ) > 0 then '1' else '0'   end +
        case when convert(varchar(16), @i &  8192 ) > 0 then '1' else '0'   end +
        case when convert(varchar(16), @i &  4096 ) > 0 then '1' else '0'   end +
        case when convert(varchar(16), @i &  2048 ) > 0 then '1' else '0'   end +
        case when convert(varchar(16), @i &  1024 ) > 0 then '1' else '0'   end +
        case when convert(varchar(16), @i &   512 ) > 0 then '1' else '0'   end +
        case when convert(varchar(16), @i &   256 ) > 0 then '1' else '0'   end +
        case when convert(varchar(16), @i &   128 ) > 0 then '1' else '0'   end +
        case when convert(varchar(16), @i &    64 ) > 0 then '1' else '0'   end +
        case when convert(varchar(16), @i &    32 ) > 0 then '1' else '0'   end +
        case when convert(varchar(16), @i &    16 ) > 0 then '1' else '0'   end +
        case when convert(varchar(16), @i &     8 ) > 0 then '1' else '0'   end +
        case when convert(varchar(16), @i &     4 ) > 0 then '1' else '0'   end +
        case when convert(varchar(16), @i &     2 ) > 0 then '1' else '0'   end +
        case when convert(varchar(16), @i &     1 ) > 0 then '1' else '0'   end
END;

