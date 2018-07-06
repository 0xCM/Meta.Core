CREATE PROCEDURE [SqlTest].[pTable0DInsert](@Records SqlTest.Table0DRecord readonly) as
begin

insert SqlTest.Table0D(Col01, Col02, Col03)
	select Col01, Col02, Col03 from @Records

end
