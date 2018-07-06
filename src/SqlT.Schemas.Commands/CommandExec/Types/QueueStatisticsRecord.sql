create type [CommandExec].[QueueStatisticRecord] as table
(
	QueueName nvarchar(75) not null,
	CommandName nvarchar(250) not null,
	CommandCount int not null
)
GO
