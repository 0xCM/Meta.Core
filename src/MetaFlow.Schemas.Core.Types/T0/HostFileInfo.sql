create type [T0].[HostFileInfo] as table
(
	HostId nvarchar(75) not null,
	FilePath nvarchar(4000) not null,
	CreateTS datetime2(0) not null,
	UpdateTS datetime2(0) not null,
	FileSize bigint not null,
	FileSizeMB decimal(19,4) not null,
	FileSizeGB decimal(19,4) not null

)
	
