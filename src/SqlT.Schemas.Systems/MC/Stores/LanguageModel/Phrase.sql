create table [MC].[Phrase] 
(
	PhraseIdentifier nvarchar(75) not null,
	WordIdentifier nvarchar(75) not null,

	constraint PK_Phrase primary key(PhraseIdentifier,WordIdentifier),
	constraint FK_Phrase_Word foreign key(WordIdentifier)
		references [MC].[Word](Identifier)
)
	
