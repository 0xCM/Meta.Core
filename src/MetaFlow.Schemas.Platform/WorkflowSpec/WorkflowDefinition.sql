create table [WF].[WorkflowDefinition]
(
	WorkflowId int not null
		constraint DF_WorkflowDefinition_WorkflowId default(next value for [WF].[WorkflowDefinitionSequence]),
	SystemId nvarchar(75) not null,
	WorkflowName nvarchar(75) not null,

	CreateTS datetime2(0) not null
		constraint DF_WorkflowDefinition_CreateTS default(getdate()),
	UpdateTS datetime2(0) null,

	constraint PK_WorkflowDefinition primary key(WorkflowId),
	constraint UQ_WorkflowDefinition unique(WorkflowName)
)

GO
create sequence [WF].[WorkflowDefinitionSequence] as
	int start with 1 cache 5
	
