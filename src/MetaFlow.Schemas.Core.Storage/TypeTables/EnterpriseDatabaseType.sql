create table [PF].[EnterpriseDatabaseType]
(
	TypeCode int not null,
	Identifier nvarchar(75) not null,
	Label nvarchar(75) not null,
	[Description] nvarchar(250) null,
	CreateTS  datetime2(0) not null
		constraint DF_EnterpriseDatabaseType_CreateTS default (getdate()),
	UpdateTS  datetime2(0) null,
	
	constraint PK_EnterpriseDatabaseType primary key(TypeCode),
	constraint UQ_EnterpriseDatabaseType_Identifier unique(Identifier),
	constraint UQ_EnterpriseDatabaseType_Label unique(Label),
)
GO

create trigger [PF].[EnterpriseDatabaseTypeUpdated] 
	on [PF].[EnterpriseDatabaseType] after update as
	update [PF].[EnterpriseDatabaseType] set 
		UpdateTS = getdate()
	from 
		[PF].[EnterpriseDatabaseType] c 
	inner join 
		inserted on inserted.TypeCode = c.TypeCode
GO

exec sp_addextendedproperty @name = N'SqlT_TableRole',
    @value = N'TypeTable',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'TABLE',
    @level1name = N'EnterpriseDatabaseType',
    @level2type = NULL,
    @level2name = NULL
GO

exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[SqlT].[LargeTypeTable]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'Table',
    @level1name = N'EnterpriseDatabaseType',
    @level2type = NULL,
    @level2name = NULL
GO
exec sp_addextendedproperty @name = N'SqlT_EnumProvider',
    @value = '',
    @level0type = 'SCHEMA',
    @level0name = 'PF',
    @level1type = 'Table',
    @level1name = 'EnterpriseDatabaseType';
GO





	
