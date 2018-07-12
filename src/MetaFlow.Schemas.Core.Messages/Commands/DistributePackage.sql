create type [C0].[DistributePackage] as table
(
	CommandNode nvarchar(75) not null,
	TargetNodeId nvarchar(75) not null,
	DistributionId nvarchar(75) not null
)
GO
exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[WF].[SystemCommand]',
    @level0type = N'SCHEMA',
    @level0name = N'C0',
    @level1type = N'Type',
    @level1name = N'DistributePackage',
    @level2type = NULL,
    @level2name = NULL
GO


exec sp_addextendedproperty @name = N'MS_Description',
    @value = N'Publishes most recent distribution version of a distribution to an identified node',
    @level0type = N'SCHEMA',
    @level0name = N'C0',
    @level1type = N'Type',
    @level1name = N'DistributePackage',
    @level2type = NULL,
    @level2name = NULL
GO






