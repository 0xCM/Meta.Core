create type [SqlDac].[PackageAssociation] as table
(
	ClientPackage nvarchar(128) not null,
	SupplierPackage nvarchar(128) not null,
	DependencyType nvarchar(75) not null
)

