create table [SqlDom].[ScriptXml]
(
	ScriptId int not null
		constraint DF_ScriptXml_ScriptId default(next value for [SqlDom].[ScriptXmlSequence]),		
	ScriptName varchar(128) not null,
	SourceText nvarchar(max) not null,
	XmlFormat xml not null,
	CreateTS datetime2(0) not null
		constraint DF_ScriptXml_CreateTS default(getdate()),
	UpdateTS datetime2(0) null,
	constraint PK_ScriptXml primary key(ScriptId),
	constraint UQ_ScriptXml unique(ScriptName)
)
Go

create sequence [SqlDom].[ScriptXmlSequence]
	as int start with 1 cache 10;
