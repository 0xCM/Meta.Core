create function [RF].[now]() returns varchar(25) as
begin

	return convert(varchar, getdate(), 121)

end