create type [E0].[CommandExecuted] as table
(
	HostId nvarchar(75) not null,
	TaskId bigint not null,
	CommandUri nvarchar(250) not null,
	Succeeded bit not null

)
GO

exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[WF].[SystemEvent]',
    @level0type = N'SCHEMA',
    @level0name = N'E0',
    @level1type = N'Type',
    @level1name = N'CommandExecuted',
    @level2type = NULL,
    @level2name = NULL
GO

	
