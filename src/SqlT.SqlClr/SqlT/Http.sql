create procedure [SqlT].[HttpPost](@url nvarchar(500), @json nvarchar(MAX))
	as external name [SqlT.SqlClr].[Http].[HttpPost]
