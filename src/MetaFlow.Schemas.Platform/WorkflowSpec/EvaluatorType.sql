create table [WF].[EvaulatorType]
(
	TypeCode tinyint not null,
	Identifier nvarchar(75) not null,
	Label nvarchar(75) not null,
	[Description] nvarchar(250) null,
	CreateTS  datetime2(0) not null
		constraint DF_EvaulatorType_DbCreateTime default (getdate()),
	UpdateTS  datetime2(0) null,
	
	constraint PK_EvaulatorType primary key(TypeCode),
	constraint UQ_EvaulatorType_Identifier unique(Identifier),
	constraint UQ_EvaulatorType_Label unique(Label),
)
GO
/*
And
Or
Comparision
*/

create trigger [WF].[EvaulatorTypeUpdated] 
	on [WF].[EvaulatorType] after update as
	update [WF].[EvaulatorType] set 
		UpdateTS = getdate()
	from 
		[WF].[EvaulatorType] c 
	inner join 
		inserted on inserted.TypeCode = c.TypeCode
GO


exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[SqlT].[TinyTypeTable]',
    @level0type = N'SCHEMA',
    @level0name = N'WF',
    @level1type = N'Table',
    @level1name = N'EvaulatorType',
    @level2type = NULL,
    @level2name = NULL

GO
exec sp_addextendedproperty @name = N'SqlT_EnumProvider',
    @value = '',
    @level0type = 'SCHEMA',
    @level0name = 'WF',
    @level1type = 'Table',
    @level1name = 'EvaulatorType';
GO


	
