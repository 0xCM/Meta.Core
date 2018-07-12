create type [T0].[FileStreamIdentifier] as table
(
	row_id int not null,
	stream_id uniqueidentifier not null
)
GO
