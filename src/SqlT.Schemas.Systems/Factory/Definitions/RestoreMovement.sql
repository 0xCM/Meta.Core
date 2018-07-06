create table [Factory].[RestoreMovement]
(

	FactoryKey bigint not null
		constraint DF_RestoreMovement_FactoryKey 
			default(next value for [Factory].[FactorySequence]),
	RestoreIdentifier nvarchar(75) not null,
	LogicalSourceName nvarchar(128) not null,
	PhysicalTargetName nvarchar(250) not null,
	CreateTS datetime2(0) not null
		constraint DF_RestoreMovement_CreateTS default(getdate()),

	constraint PK_RestoreMovement primary key(FactoryKey),
	constraint FK_RestoreMovement_RestoreDatabase foreign key(RestoreIdentifier)
		references [Factory].[RestoreDatabase](Identifier)
			on delete cascade


)
	
