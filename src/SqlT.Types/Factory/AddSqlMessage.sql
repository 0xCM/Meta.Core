create type [Factory].[AddSqlMessage] as table
(
	MessageIdentifier nvarchar(75) not null,
	MessageNumber int null,
	MessageLanguage nvarchar(75) null,
	Severity tinyint null,
	MessageText nvarchar(255) not null,
	EventLog bit null,
	ReplaceExisting bit null
		
)
