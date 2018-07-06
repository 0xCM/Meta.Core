create table [SqlDac].[PackageDependency]
(
	ClientPackage nvarchar(128) not null,
	SupplierPackage nvarchar(128) not null,
	DependencyType nvarchar(75) not null,
	CreateTS datetime2(0) constraint DF_PackageDependency_CreateTS default(getdate()),
	UpdateTS datetime2(0) 
	
	constraint PK_PackageDependency primary key(ClientPackage, SupplierPackage),
	
	constraint FK_PackageDependency_Client foreign key(ClientPackage)
		references [SqlDac].[PackageDescriptor](PackageName),

	constraint FK_PackageDependency_PackageDependencyType foreign key(DependencyType)
		references [SqlDac].[PackageDependencyType](Identifier),
	
	constraint FK_PackageDependency_Supplier foreign key(SupplierPackage)
		references [SqlDac].[PackageDescriptor](PackageName)
			on update cascade
			on delete cascade,
		
)
GO

exec sp_addextendedproperty @name = N'MS_Description',
    @value = N'Defines a dependency from one package to another',
    @level0type = N'SCHEMA',
    @level0name = N'SqlDac',
    @level1type = N'TABLE',
    @level1name = N'PackageDependency',
    @level2type = NULL,
    @level2name = NULL


