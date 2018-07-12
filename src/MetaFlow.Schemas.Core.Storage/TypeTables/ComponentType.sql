create table [PF].[ComponentType]
(
	TypeCode tinyint not null,
	Identifier nvarchar(75) not null,
	Label nvarchar(75) not null,
	[Description] nvarchar(250) null,
	CreateTS  datetime2(0) not null
		constraint DF_Component_DbCreateTime default (getdate()),
	UpdateTS  datetime2(0) null,
	
	constraint PK_Component primary key(TypeCode),
	constraint UQ_Component_Identifier unique(Identifier),
	constraint UQ_Component_Label unique(Label),
)
GO

create trigger [PF].[ComponentTypeUpdated] 
	on [PF].[ComponentType] after update as
	update [PF].[ComponentType] set 
		UpdateTS = getdate()
	from 
		[PF].[ComponentType] c 
	inner join 
		inserted on inserted.TypeCode = c.TypeCode
GO

exec sp_addextendedproperty @name = N'SqlT_TableRole',
    @value = N'TypeTable',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'TABLE',
    @level1name = N'ComponentType',
    @level2type = NULL,
    @level2name = NULL
GO

exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[SqlT].[TinyTypeTable]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'Table',
    @level1name = N'ComponentType',
    @level2type = NULL,
    @level2name = NULL





