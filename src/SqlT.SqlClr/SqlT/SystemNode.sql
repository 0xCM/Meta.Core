create function [SqlT].[NodeVars]() returns table 
	(
		VarName nvarchar(250),
		VarValue nvarchar(4000)
	)
	as external name [SqlT.SqlClr].[SystemNode].[NodeVars]
GO
create procedure [SqlT].[SetVar](@VarName nvarchar(250), @VarValue nvarchar(4000))
	as external name [SqlT.SqlClr].[SystemNode].[SetVar]
GO
