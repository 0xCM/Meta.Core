﻿create table [SqlStore].[ColumnGroupType]
(
	TypeCode int not null,
	Identifier nvarchar(75) not null,
	Label nvarchar(75) null,
	[Description] nvarchar(250) null,
	CreateTS datetime2(0) constraint DF_ColumnGroupType_CreateTS default(getdate()),
	UpdateTS datetime2 (0)
	
	constraint PK_ColumnGroupType primary key(TypeCode),
	constraint UQ_ColumnGroupType_Identifier unique(Identifier),
	constraint UQ_ColumnGroupType_Label unique(Label)
)
GO
exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[DataContracts].[LargeTypeTable]',
    @level0type = N'SCHEMA',
    @level0name = N'SqlStore',
    @level1type = N'Table',
    @level1name = N'ColumnGroupType',
    @level2type = NULL,
    @level2name = NULL
GO

EXEC sp_addextendedproperty @name = N'SqlT_TableGroup',
    @value = N'TypeTable',
    @level0type = N'SCHEMA',
    @level0name = N'SqlStore',
    @level1type = N'TABLE',
    @level1name = N'ColumnGroupType',
    @level2type = NULL,
    @level2name = NULL
GO


