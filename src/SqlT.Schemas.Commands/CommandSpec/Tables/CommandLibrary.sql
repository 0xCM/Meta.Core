create sequence [CommandSpec].[CommandLibrarySequence] as int start with 1 cache 100
GO

CREATE TABLE [CommandSpec].[CommandLibrary]
(
	CommandLibraryKey int not null constraint DF_CommandLibraryKey default(next value for [CommandSpec].CommandLibrarySequence),
	CommandSpecName nvarchar(150) not null,	
	CommandName nvarchar(250) not null,
	CommandJson nvarchar(max) not null
		constraint CK_CommandLibrary_CommandJson check(isjson(CommandJson)>0),
	DbCreateTime datetime2(3) not null constraint DF_CommandLibrary_DbCreateTime default(getdate()),
	DbUpdateTime datetime2(3) null,

	constraint UQ_CommandLibrary unique(CommandSpecName),
	constraint FK_CommandLibrary_CommandDefinition foreign key(CommandName) 
		references [CommandSpec].CommandDefinition(CommandName)

)
GO
create trigger [CommandSpec].CommandLibraryUpdated on [CommandSpec].CommandLibrary after update as
	update [CommandSpec].CommandLibrary set 
		DbUpdateTime = getdate()
	from 
		[CommandSpec].CommandLibrary x 
	inner join 
		inserted on inserted.CommandLibraryKey = x.CommandLibraryKey
GO

