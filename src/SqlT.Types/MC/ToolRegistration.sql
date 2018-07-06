create type [MC].[ToolRegistration] as table
(
	ToolId nvarchar(75) not null,
	ExecutableName nvarchar(75) not null,
	ExecutablePath nvarchar(250) null
)
GO
exec sp_addextendedproperty @name = N'MS_Description',
    @value = N'Identifies an executable used for system build/construction or operational purposes',
    @level0type = N'SCHEMA',
    @level0name = N'MC',
    @level1type = N'Type',
    @level1name = N'ToolRegistration',
    @level2type = NULL,
    @level2name = NULL







	
