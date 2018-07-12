create type [C0].[DefineVariable] as table
(	
 	CommandNode nvarchar(75) not null,
	VariableName nvarchar(75) not null,
	VariableValue nvarchar(1024) not null
)
GO
exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[WF].[SystemCommand]',
    @level0type = N'SCHEMA',
    @level0name = N'C0',
    @level1type = N'Type',
    @level1name = N'DefineVariable',
    @level2type = NULL,
    @level2name = NULL
GO






