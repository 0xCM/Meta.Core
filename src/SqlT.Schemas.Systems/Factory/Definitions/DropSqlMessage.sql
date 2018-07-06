create table [Factory].[DropSqlMessage]
(
 	FactoryKey bigint not null
		constraint DF_DropSqlMessage_FactoryKey 
			default(next value for [Factory].[FactorySequence]),

	MessageNumber int not null,
	MessageLanguage nvarchar(75) null,
	CreateTS datetime2(0) not null
		constraint DF_DropSqlMessage_CreateTS default(getdate()),
	UpdateTS datetime2(0) null,
	constraint PK_DropSqlMessage primary key(FactoryKey)

)
	
