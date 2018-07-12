create type [T0].[QueueRecord] as table
(
	ConversationId uniqueidentifier,
	MessageType sysname,
	MessageBody varbinary(max)
)
GO
