create type [WF].[SystemTaskEvent] as table
(
	HostId nvarchar(75) not null,
	TaskId bigint not null
)
GO

exec sp_addextendedproperty @name = N'MS_Description',
    @value = N'Represents something of interest that occurred during an identified task',
    @level0type = N'SCHEMA',
    @level0name = N'WF',
    @level1type = N'Type',
    @level1name = N'SystemTaskEvent',
    @level2type = NULL,
    @level2name = NULL
GO
exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[SqlT].[SystemEvent]',
    @level0type = N'SCHEMA',
    @level0name = N'WF',
    @level1type = N'Type',
    @level1name = N'SystemTaskEvent',
    @level2type = NULL,
    @level2name = NULL
GO





