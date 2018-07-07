﻿create table [SqlDac].[PackageDependencyType]
(
	TypeCode tinyint not null,
	Identifier nvarchar(75) not null,
	Label nvarchar(75) null,
	Description nvarchar(250) null,
	CreateTS datetime2(0) constraint DF_PackageDependencyType_CreateTS default(getdate()),
	UpdateTS datetime2 (0)
	
	constraint PK_PackageDependencyType primary key(TypeCode),
	constraint UQ_PackageDependencyType_Identifier unique(Identifier),
	constraint UQ_PackageDependencyType_Label unique(Label)
)
GO
exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[DataContracts].[TinyTypeTable]',
    @level0type = N'SCHEMA',
    @level0name = N'SqlDac',
    @level1type = N'Table',
    @level1name = N'PackageDependencyType',
    @level2type = NULL,
    @level2name = NULL
GO

EXEC sp_addextendedproperty @name = N'SqlT_TableRole',
    @value = N'TypeTable',
    @level0type = N'SCHEMA',
    @level0name = N'SqlDac',
    @level1type = N'TABLE',
    @level1name = N'PackageDependencyType',
    @level2type = NULL,
    @level2name = NULL
GO

