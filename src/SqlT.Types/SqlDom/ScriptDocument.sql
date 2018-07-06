create type [SqlDom].[ScriptDocument] as table
(
	ScriptName nvarchar(128) not null,
	ScriptText nvarchar(max) not null
)
	
