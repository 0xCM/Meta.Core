create table [Syntax].[Choice]
(
	ChoiceName nvarchar(128) not null,
	ChoiceValue nvarchar(128) not null,
	CreateTS datetime2(0) not null
		constraint DF_Choice_CreateTS default(getdate()),	

	constraint PK_Choice primary key(ChoiceName,ChoiceValue),

	constraint FK_Choice_ValueKeyword foreign key(ChoiceValue)
		references [Syntax].[Keyword](KeywordName),

)
