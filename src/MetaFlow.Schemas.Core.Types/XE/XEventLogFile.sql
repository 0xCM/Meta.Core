create type [XE].[XEventLogFile] as table
(
 	FilePath nvarchar(500) not null, 
	IsDirectory bit not null, 
	CreationTime datetime2(7) not null, 
	LastWriteTime datetime2(7) not null, 
	Size bigint not null

)