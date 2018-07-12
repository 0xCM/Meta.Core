create table [PF].[PlatformNavigatorType]
(
	TypeCode tinyint not null,
	Identifier nvarchar(75) not null,
	Label nvarchar(75) not null,
	[Description] nvarchar(250) null,
	CreateTS  datetime2(0) not null
		constraint DF_PlatformNavigator_CreateTS default (getdate()),
	UpdateTS  datetime2(0) null,
	
	constraint PK_PlatformNavigator primary key(TypeCode),
	constraint UQ_PlatformNavigator_Identifier unique(Identifier),
	constraint UQ_PlatformNavigator_Label unique(Label),
)
GO

create trigger [PF].[PlatformNavigatorTypeUpdated] 
	on [PF].[PlatformNavigatorType] after update as
	update [PF].[PlatformNavigatorType] set 
		UpdateTS = getdate()
	from 
		[PF].[PlatformNavigatorType] c 
	inner join 
		inserted on inserted.TypeCode = c.TypeCode
GO


exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[SqlT].[TinyTypeTable]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'Table',
    @level1name = N'PlatformNavigatorType',
    @level2type = NULL,
    @level2name = NULL
GO
exec sp_addextendedproperty @name = N'SqlT_EnumProvider',
    @value = '',
    @level0type = 'SCHEMA',
    @level0name = 'PF',
    @level1type = 'Table',
    @level1name = 'PlatformNavigatorType';
GO





