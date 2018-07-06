create table [MC].[DistributionType]
(
	TypeCode tinyint not null,
	Identifier nvarchar(75) not null,
	Label nvarchar(75) not null,
	[Description] nvarchar(250) null,
	CreateTS  datetime2(0) not null
		constraint DF_DistributionType_CreateTS default (getdate()),
	UpdateTS  datetime2(0) null,
	
	constraint PK_DistributionType primary key(TypeCode),
	constraint UQ_DistributionType_Identifier unique(Identifier),
	constraint UQ_DistributionType_Label unique(Label),
)
GO

create trigger [MC].[OnDistributionTypeUpdated] 
	on [MC].[DistributionType] after update as
	update [MC].[DistributionType] set 
		UpdateTS = getdate()
	from 
		[MC].[DistributionType] c 
	inner join 
		inserted on inserted.TypeCode = c.TypeCode
GO

exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[SqlT].[TinyTypeTable]',
    @level0type = N'SCHEMA',
    @level0name = N'MC',
    @level1type = N'Table',
    @level1name = N'DistributionType',
    @level2type = NULL,
    @level2name = NULL

GO
exec sp_addextendedproperty @name = N'SqlT_EnumProvider',
    @value = '',
    @level0type = 'SCHEMA',
    @level0name = 'MC',
    @level1type = 'Table',
    @level1name = 'DistributionType';
GO




	
