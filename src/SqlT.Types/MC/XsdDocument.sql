create type [MC].[XsdDocument] as table
(
	SourcePath nvarchar(250) not null,
	DocumentName nvarchar(250) not null,
	Processed bit not null,
	ProcessingError nvarchar(500) null,
	XmlContent xml not null
	

)

