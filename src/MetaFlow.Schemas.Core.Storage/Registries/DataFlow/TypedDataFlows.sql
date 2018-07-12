create function [PF].[TypedDataFlows]() returns table as return
	select 
		SourceAssembly,
		TargetAssembly,
		DataFlowName,
		WorkflowTypeUri,
		ArgumentTypeUri
	from 
		[PF].[TypedDataFlowRegistry]
GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[T0].[TypedDataFlowDescriptor]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'FUNCTION',
    @level1name = N'TypedDataFlows',
    @level2type = NULL,
    @level2name = NULL


