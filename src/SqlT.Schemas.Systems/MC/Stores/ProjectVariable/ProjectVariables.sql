create function [MC].[ProjectVariables](@ProjectId nvarchar(75)) returns table as return
	select
		ProjectId,
		VariableName,
		VariableValue
	from
		[MC].[ProjectVariableDefinition]
	where
		ProjectId = @ProjectId
GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[MC].[ProjectVariable]',
    @level0type = N'SCHEMA',
    @level0name = N'MC',
    @level1type = N'FUNCTION',
    @level1name = N'ProjectVariables',
    @level2type = NULL,
    @level2name = NULL


