CREATE PROCEDURE [SqlTest].[Proc01]
	@param1 int,
	@param2 int,
	@param3 int
AS
	SELECT @param1, @param2, @param3
RETURN 0
