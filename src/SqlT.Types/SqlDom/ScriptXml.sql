create type [SqlDom].[ScriptXml] as table
(
	ScriptName varchar(128) not null,
	SourceText nvarchar(max) not null,
	XmlFormat xml not null
)

