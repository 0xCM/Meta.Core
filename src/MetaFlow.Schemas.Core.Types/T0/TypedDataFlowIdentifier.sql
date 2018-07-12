create type [T0].[TypedDataFlowIdentifier] as table
(
	SourceAssembly nvarchar(75) not null,
	TargetAssembly nvarchar(75) not null,
	DataFlowName nvarchar(75) not null
)
	
