create type [CommandSpec].[CommandDefinitionRecord] as table
(
	CommandName nvarchar(250) not null,
	CommandDescription nvarchar(500) null

)
