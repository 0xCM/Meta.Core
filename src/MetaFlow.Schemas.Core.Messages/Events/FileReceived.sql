create type [E0].[FileReceived] as table
(
	HostId nvarchar(75) not null,
 	FileId uniqueidentifier not null,
	[FileName] nvarchar(255) not null,
	FileType nvarchar(75) not null,
	ReceiptPath nvarchar(500) not null,
	ReceiptTS datetime2(0) not null,
	UpdatedTS datetime2(0) not null
)

GO
exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[WF].[SystemEvent]',
    @level0type = N'SCHEMA',
    @level0name = N'E0',
    @level1type = N'Type',
    @level1name = N'FileReceived',
    @level2type = NULL,
    @level2name = NULL
GO




