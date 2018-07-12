create type [PF].[QueueRecord] as table
(
	ConversationId uniqueidentifier,
	MessageType sysname,
	MessageBody varbinary(max)
)
GO
