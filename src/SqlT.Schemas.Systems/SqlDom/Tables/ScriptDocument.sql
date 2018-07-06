create table [SqlDom].[ScriptDocument]
(
	ScriptId int not null
		constraint DF_ScriptDocument_ScriptId default(next value for [SqlDom].[DocumentSequence]),		
	ScriptName varchar(128) not null,
	ScriptText nvarchar(max) not null,
	CreateTS datetime2(0) not null
		constraint DF_ScriptDocument_CreateTS default(getdate()),
	UpdateTS datetime2(0) null,
)
Go

create sequence [SqlDom].[DocumentSequence]
	as int start with 1 cache 10;
