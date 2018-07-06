create type [SqlDocs].[TextFileDescription] as table
(
	SegmentName nvarchar(75) not null,
	SourcePath nvarchar(500) not null,
	ModifiedDate date null,
	FileSize bigint not null,
	FileContent nvarchar(max) not null
)

	
