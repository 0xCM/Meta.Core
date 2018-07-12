create type [WF].[SystemEvent] as table
(
	HostId nvarchar(75) not null
)
GO

exec sp_addextendedproperty @name = N'MS_Description',
    @value = N'Represents something of interest that occurred on an identified host',
    @level0type = N'SCHEMA',
    @level0name = N'WF',
    @level1type = N'Type',
    @level1name = N'SystemEvent',
    @level2type = NULL,
    @level2name = NULL
GO
