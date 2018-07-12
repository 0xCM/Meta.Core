create type [PF].[TypedDataFlow] as table
(
	SourceAssembly nvarchar(75) not null,
	TargetAssembly nvarchar(75) not null,
	DataFlowName nvarchar(75) not null,
	TypeUri nvarchar(250) not null
)
