create table [MC].[ProjectType]
(
	TypeCode tinyint not null,
	Identifier nvarchar(75) not null,
	Label nvarchar(75) not null,
	[Description] nvarchar(250) null,
	CreateTS  datetime2(0) not null
		constraint DF_ProjectType_CreateTS default (getdate()),
	UpdateTS  datetime2(0) null,
	
	constraint PK_ProjectType primary key(TypeCode),
	constraint UQ_ProjectType_Identifier unique(Identifier),
	constraint UQ_ProjectType_Label unique(Label),
)
GO

create trigger [MC].[OnProjectTypeUpdated] 
	on [MC].[ProjectType] after update as
	update [MC].[ProjectType] set 
		UpdateTS = getdate()
	from 
		[MC].[ProjectType] c 
	inner join 
		inserted on inserted.TypeCode = c.TypeCode
GO
exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[SqlT].[TinyTypeTable]',
    @level0type = N'SCHEMA',
    @level0name = N'MC',
    @level1type = N'Table',
    @level1name = N'ProjectType',
    @level2type = NULL,
    @level2name = NULL

GO
exec sp_addextendedproperty @name = N'SqlT_EnumProvider',
    @value = '',
    @level0type = 'SCHEMA',
    @level0name = 'MC',
    @level1type = 'Table',
    @level1name = 'ProjectType';
GO
