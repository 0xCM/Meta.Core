create table [WF].[StepDefinition]
(	
	StepId int not null	
		constraint DF_StepDefinition_StepId default(next value for [WF].[StepDefinitionSequence]),
	WorkflowName nvarchar(75) not null,
	StepName nvarchar(75) not null,
	
	CreateTS datetime2(0) not null
		constraint DF_StepDefinition_CreateTS default(getdate()),
	UpdateTS datetime2(0) null,

	constraint PK_StepDefinition primary key(StepId),
	constraint FK_StepDefinition_WorkflowDefinition foreign key(WorkflowName)
		references [WF].[WorkflowDefinition](WorkflowName)
			on delete cascade
			on update cascade,
	constraint UQ_StepDefinition unique(WorkflowName, StepName)
	
)

GO
create sequence [WF].[StepDefinitionSequence] as
	int start with 1 cache 5
	


