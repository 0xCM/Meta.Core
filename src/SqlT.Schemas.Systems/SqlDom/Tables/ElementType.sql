create table [SqlDom].[ElementType]
(
	TypeCode int not null,
	Identifier nvarchar(75) not null,
	Label nvarchar(75) null,
	[Description] nvarchar(250) null,
	CreateTS datetime2(0) constraint DF_ElementType_CreateTS default(getdate()),
	UpdateTS datetime2 (0)
	
	constraint PK_ElementType primary key(TypeCode),
	constraint UQ_ElementType_Identifier unique(Identifier),
	constraint UQ_ElementType_Label unique(Label)
)
GO
exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[DataContracts].[LargeTypeTable]',
    @level0type = N'SCHEMA',
    @level0name = N'SqlDom',
    @level1type = N'Table',
    @level1name = N'ElementType',
    @level2type = NULL,
    @level2name = NULL
GO

exec sp_addextendedproperty @name = N'SqlT_EnumProvider',
    @value = '',
    @level0type = 'SCHEMA',
    @level0name = 'SqlDom',
    @level1type = 'Table',
    @level1name = 'ElementType';
GO




	


