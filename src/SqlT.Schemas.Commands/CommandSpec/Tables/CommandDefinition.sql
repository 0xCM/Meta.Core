
create table [CommandSpec].CommandDefinition
(
	CommandDefinitionKey int not null constraint DF_CommandDefinitionKey default(next value for [CommandSpec].DefinitionSequence),
	CommandName nvarchar(250) not null,
	CommandDescription nvarchar(500) null,
	DbCreateTime datetime2(3) not null constraint DF_CommandDefinition_DbCreateTime default(getdate()),
	DbUpdateTime datetime2(3) null,
	constraint PK_CommandDefinition primary  key(CommandDefinitionKey),
	constraint UQ_CommandDefinition unique(CommandName)
)
GO

create sequence [CommandSpec].DefinitionSequence as int start with 1 cache 100
GO

create trigger [CommandSpec].CommandDefinitionUpdated on [CommandSpec].CommandDefinition after update as
	update [CommandSpec].CommandDefinition set 
		DbUpdateTime = getdate()
	from 
		[CommandSpec].CommandDefinition x 
	inner join 
		inserted on inserted.CommandDefinitionKey = x.CommandDefinitionKey
GO

