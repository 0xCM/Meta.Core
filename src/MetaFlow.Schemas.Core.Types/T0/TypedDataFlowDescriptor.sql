create type [T0].[TypedDataFlowDescriptor] as table
(
	SourceAssembly nvarchar(75) not null,
	TargetAssembly nvarchar(75) not null,
	DataFlowName nvarchar(75) not null,
	WorkflowTypeUri nvarchar(250) not null,
	ArgumentTypeUri nvarchar(250) null
)
