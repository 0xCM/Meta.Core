create type [T0].[FileReceipt] as table
(
	HostId nvarchar(75) not null,
 	FileId uniqueidentifier not null,
	[FileName] nvarchar(255) not null,
	FileType nvarchar(75) not null,
	ReceiptPath nvarchar(500) not null,
	WrittenTS datetime2(0) not null,
	ReceiptTS datetime2(0) not null
)

