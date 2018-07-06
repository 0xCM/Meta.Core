create type [SqlDac].[PackageVariable] as table
(
	PackageName nvarchar(128) not null,
	VariableName nvarchar(128) not null
)
