create type [XE].[XEventDataBlock] as table
(
	[object_name] nvarchar(128) not null,
	[file_name] nvarchar(500) not null,
	file_offset int not null,
	event_data xml

)
GO
