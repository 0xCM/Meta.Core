create table [PF].[EnterpriseServerType]
(
	TypeCode int not null,
	Identifier nvarchar(75) not null,
	Label nvarchar(75) not null,
	[Description] nvarchar(250) null,
	CreateTS  datetime2(0) not null
		constraint DF_EnterpriseServerType_DbCreateTime default (getdate()),
	UpdateTS  datetime2(0) null,
	
	constraint PK_EnterpriseServerType primary key(TypeCode),
	constraint UQ_EnterpriseServerType_Identifier unique(Identifier),
	constraint UQ_EnterpriseServerType_Label unique(Label),
)
GO

create trigger [PF].[EnterpriseServerTypeUpdated] 
	on [PF].[EnterpriseServerType] after update as
	update [PF].[EnterpriseServerType] set 
		UpdateTS = getdate()
	from 
		[PF].[EnterpriseServerType] c 
	inner join 
		inserted on inserted.TypeCode = c.TypeCode
GO

exec sp_addextendedproperty @name = N'SqlT_TableRole',
    @value = N'TypeTable',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'TABLE',
    @level1name = N'EnterpriseServerType',
    @level2type = NULL,
    @level2name = NULL
GO

exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[SqlT].[LargeTypeTable]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'Table',
    @level1name = N'EnterpriseServerType',
    @level2type = NULL,
    @level2name = NULL



	
