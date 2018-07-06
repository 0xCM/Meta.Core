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
