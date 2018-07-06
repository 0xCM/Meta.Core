create table [Factory].[AddSqlMessage]
(
	
	FactoryKey bigint not null
		constraint DF_AddSqlMessage_FactoryKey 
			default(next value for [Factory].[FactorySequence]),
	MessageIdentifier nvarchar(75) not null,
	MessageNumber int not null
		constraint DF_AddSqlMessage_MessageNumber 
			default(next value for [Factory].[MessageNumberSequence]),
	MessageLanguage nvarchar(75) null,			
	Severity tinyint null,
	MessageText nvarchar(255) not null,
	EventLog bit null,
	ReplaceExisting bit null,
	CreateTS datetime2(0) not null
		constraint DF_AddSqlMessage_CreateTS default(getdate()),
	UpdateTS datetime2(0) null,
	constraint PK_AddSqlMessage primary key(FactoryKey)

)
GO
create sequence [Factory].[MessageNumberSequence]
	as int start with 50001 no cache no cycle
	
