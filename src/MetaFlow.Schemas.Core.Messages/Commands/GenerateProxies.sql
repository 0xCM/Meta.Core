create type [C0].[GenerateProxies] as table
(
	CommandNode nvarchar(75) not null,
	GenerationProfilePath nvarchar(250) not null,
	PLL bit not null
)
GO
exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[WF].[SystemCommand]',
    @level0type = N'SCHEMA',
    @level0name = N'C0',
    @level1type = N'Type',
    @level1name = N'GenerateProxies',
    @level2type = NULL,
    @level2name = NULL
GO





	
