create procedure SqlTest.pTable02Insert(@Col01 int output, @Col02 datetime2(7), @Col03 bigint) as
begin
	set nocount on
	set @Col01 = next value for SqlTest.Seq02
	insert SqlTest.Table02(Col01, Col02, Col03) values (@Col01, @Col02, @Col03)
	set nocount off
	return @Col01
end