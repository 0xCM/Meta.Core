create type [E0].[DatabaseDeployed] as table
(
  	HostId nvarchar(75) not null,
	DatabaseName nvarchar(128) not null,
	DatabaseVersion nvarchar(75) not null
)

GO
exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[WF].[SystemEvent]',
    @level0type = N'SCHEMA',
    @level0name = N'E0',
    @level1type = N'Type',
    @level1name = N'DatabaseDeployed',
    @level2type = NULL,
    @level2name = NULL
GO

exec sp_addextendedproperty @name = N'SqlT_FormatString',
    @value = N'Version @DatabaseVersion of the @DatabaseName database was deployed to @HostId',
    @level0type = N'SCHEMA',
    @level0name = N'E0',
    @level1type = N'Type',
    @level1name = N'DatabaseDeployed',
    @level2type = NULL,
    @level2name = NULL
GO







