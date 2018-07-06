create table [SqlDac].[PackageVariable]
(
	PackageName nvarchar(128) not null,
	VariableName nvarchar(128) not null,

	CreateTS datetime2(0) constraint DF_PackageVariable_CreateTS default(getdate()),
	UpdateTS datetime2 (0),

	constraint PK_PackageVariable primary key(PackageName, VariableName)

)
GO

exec sp_addextendedproperty @name = N'MS_Description',
    @value = N'Associates a SqlCmd variable with a package',
    @level0type = N'SCHEMA',
    @level0name = N'SqlDac',
    @level1type = N'TABLE',
    @level1name = N'PackageVariable',
    @level2type = NULL,
    @level2name = NULL

