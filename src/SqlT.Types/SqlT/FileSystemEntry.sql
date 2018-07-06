create type [SqlT].[FileSystemEntry] as table
(
	FilePath nvarchar(4000) not null, 
	IsDirectory bit not null, 
	CreationTime datetime not null, 
	LastWriteTime datetime not null, 
	Size bigint not null
)
go
