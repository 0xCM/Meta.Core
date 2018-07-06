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