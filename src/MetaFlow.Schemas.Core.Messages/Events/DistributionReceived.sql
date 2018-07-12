create type [E0].[DistributionReceived] as table
(
 	HostId nvarchar(75) not null,
	DistributionId nvarchar(75) not null,	
	DistributionVersion nvarchar(75) not null,	
	DistributionPath nvarchar(500) not null
)
GO
exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[WF].[SystemEvent]',
    @level0type = N'SCHEMA',
    @level0name = N'E0',
    @level1type = N'Type',
    @level1name = N'DistributionReceived',
    @level2type = NULL,
    @level2name = NULL
GO

	
