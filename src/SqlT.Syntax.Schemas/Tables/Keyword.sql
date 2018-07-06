create table [Syntax].[Keyword]
(
	KeywordName nvarchar(128) not null,	
	[Description] nvarchar(250) null,
	CreateTS datetime2(0) not null
		constraint DF_Keyword_CreateTS default(getdate()),	
	UpdateTS datetime2(0) null,

	constraint PK_Keyword primary key(KeywordName)

)
GO

