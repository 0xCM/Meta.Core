create table [WF].[ControlOperationType]
(
	TypeCode tinyint not null,
	Identifier nvarchar(75) not null,
	Label nvarchar(75) not null,
	[Description] nvarchar(250) null,
	CreateTS  datetime2(0) not null
		constraint DF_ControlOperationType_DbCreateTime default (getdate()),
	UpdateTS  datetime2(0) null,
	
	constraint PK_ControlOperationType primary key(TypeCode),
	constraint UQ_ControlOperationType_Identifier unique(Identifier),
	constraint UQ_ControlOperationType_Label unique(Label),
)
GO
/*
Initialization
StepExecution
StepEvaluation
Finalization
*/

create trigger [WF].[ControlOperationTypeUpdated] 
	on [WF].[ControlOperationType] after update as
	update [WF].[ControlOperationType] set 
		UpdateTS = getdate()
	from 
		[WF].[ControlOperationType] c 
	inner join 
		inserted on inserted.TypeCode = c.TypeCode
GO


exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[SqlT].[TinyTypeTable]',
    @level0type = N'SCHEMA',
    @level0name = N'WF',
    @level1type = N'Table',
    @level1name = N'ControlOperationType',
    @level2type = NULL,
    @level2name = NULL

GO
exec sp_addextendedproperty @name = N'SqlT_EnumProvider',
    @value = '',
    @level0type = 'SCHEMA',
    @level0name = 'WF',
    @level1type = 'Table',
    @level1name = 'ControlOperationType';
GO


	
