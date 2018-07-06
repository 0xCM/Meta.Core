create type [Factory].[DropSqlMessage] as table
(
	MessageNumber int not null,
	MessageLanguage nvarchar(75) null
		
)
