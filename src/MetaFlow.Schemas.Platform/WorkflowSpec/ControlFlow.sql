create table [WF].[ControlFlow]
(
	WorkflowName nvarchar(75) not null,
	OperationType nvarchar(75) not null,
	StepName nvarchar(75) not null,
	CreateTS datetime2(0) not null
		constraint DF_ControlFlow_CreateTS default(getdate()),
	UpdateTS datetime2(0) null,

	constraint FK_ControlFlow_WorkflowName foreign key(WorkflowName)
		references [WF].[WorkflowDefinition](WorkflowName),

	constraint FK_ControlFlow_ControlOperationType foreign key(OperationType)
		references [WF].[ControlOperationType](Identifier),
	
	constraint FK_ControlFlow_StepName foreign key(StepName)
		references [WF].[ControlOperationType](Identifier),

	constraint UQ_ControlFlow unique(WorkflowName,OperationType,StepName)



)
GO


	
