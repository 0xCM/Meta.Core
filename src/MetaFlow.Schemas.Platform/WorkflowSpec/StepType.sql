create table [WF].[StepType]
(
	TypeCode tinyint not null,
	Identifier nvarchar(75) not null,
	Label nvarchar(75) not null,
	[Description] nvarchar(250) null,
	CreateTS  datetime2(0) not null
		constraint DF_StepType_DbCreateTime default (getdate()),
	UpdateTS  datetime2(0) null,
	
	constraint PK_StepType primary key(TypeCode),
	constraint UQ_StepType_Identifier unique(Identifier),
	constraint UQ_StepType_Label unique(Label),
)
GO
/*
Initializizer - Starts the workflow
Evaluator - Evaluates a step result
Finalizer - Complates the workflow
*/

create trigger [WF].[StepTypeUpdated] 
	on [WF].[StepType] after update as
	update [WF].[StepType] set 
		UpdateTS = getdate()
	from 
		[WF].[StepType] c 
	inner join 
		inserted on inserted.TypeCode = c.TypeCode
GO


exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[SqlT].[TinyTypeTable]',
    @level0type = N'SCHEMA',
    @level0name = N'WF',
    @level1type = N'Table',
    @level1name = N'StepType',
    @level2type = NULL,
    @level2name = NULL

GO
exec sp_addextendedproperty @name = N'SqlT_EnumProvider',
    @value = '',
    @level0type = 'SCHEMA',
    @level0name = 'WF',
    @level1type = 'Table',
    @level1name = 'StepType';
GO


	
