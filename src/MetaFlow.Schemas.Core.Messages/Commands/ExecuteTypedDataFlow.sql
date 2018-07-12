create type [C0].[ExecuteTypedDataFlow] as table
(
	CommandNode nvarchar(75) not null,
	SourceNodeId nvarchar(75) not null,
	SourceAssembly nvarchar(75) not null,
	SourceDatabase nvarchar(128) not null,
	TargetNodeId nvarchar(75) not null,	
	TargetAssembly nvarchar(75) not null,
	TargetDatabase nvarchar(128) not null,
	DataFlowName nvarchar(75) not null
)
GO
exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[WF].[SystemCommand]',
    @level0type = N'SCHEMA',
    @level0name = N'C0',
    @level1type = N'Type',
    @level1name = N'ExecuteTypedDataFlow',
    @level2type = NULL,
    @level2name = NULL
GO








		
	
