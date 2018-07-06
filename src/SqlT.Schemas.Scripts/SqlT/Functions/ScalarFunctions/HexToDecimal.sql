--Taken from http://ariely.info/Blog/tabid/83/EntryId/169/T-SQL-Converting-between-Decimal-Binary-and-Hexadecimal.aspx
create function [SqlT].[HexToDecimal](@i int) returns varbinary(16) begin
    return convert(varbinary(16),@i)
end