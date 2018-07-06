create table [MC].[XsdDocumentStore]
(
	StoreKey bigint not null 
		constraint DF_XsdDocumentStore_SystemKey 
			default(next value for [SqlStore].[StoreKeySequence]),
	
	SourcePath nvarchar(500) not null,
	DocumentName nvarchar(500) not null,
	Processed bit not null,
	ProcessingError nvarchar(500) null,
	XmlContent xml not null,

	CreateTS datetime2(0) not null 
		constraint DF_XsdDocument_CreateTS default(getdate()),
	UpdateTS datetime2 (0) null,
	
	constraint PK_XsdDocument primary key(StoreKey),
	--constraint UQ_XsdDocument_Name unique(DocumentName),
	constraint UQ_XsdDocument_Path unique(SourcePath)


)
	
