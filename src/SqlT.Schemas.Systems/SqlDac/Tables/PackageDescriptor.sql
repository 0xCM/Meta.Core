create table [SqlDac].[PackageDescriptor]
(
	PackageName nvarchar(128) not null,
	PackageAuthor nvarchar(128) not null,
	[Description] nvarchar(250) not null,
	CreateTS datetime2(0) constraint DF_PackageDescriptor_CreateTS default(getdate()),
	UpdateTS datetime2,

	constraint PK_PackageDescriptor primary key(PackageName)
	
)
GO

