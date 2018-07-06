create table [Factory].[RestoreDatabase]
(
 	FactoryKey bigint not null
		constraint DF_RestoreDatabase_FactoryKey 
			default(next value for [Factory].[FactorySequence]),
	
	Identifier nvarchar(75) not null,
	DatabaseName nvarchar(128) not null,
	SourceFilePath nvarchar(250) null,
	[NoUnload] bit null,
	[Replace] bit null,
	[Stats] int null,
	
	CreateTS datetime2(0) not null
		constraint DF_RestoreDatabase_CreateTS default(getdate()),

	constraint PK_RestoreDatabase primary key(FactoryKey),
	constraint UQ_RestoreDatabase unique(Identifier)

)
GO
