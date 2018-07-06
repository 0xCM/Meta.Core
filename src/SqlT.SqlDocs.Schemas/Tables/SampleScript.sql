create table [SqlDocs].[SampleScript]
(
	StoreKey int not null 
		constraint DF_SampleScript_StoreKey 
			default(next value for [SqlDocs].[SampleScriptSequence]),
	SegmentName nvarchar(75) not null,
	FileLocation nvarchar(500) not null,
	ModifiedDate date null,
	FileSize bigint not null,
	ScriptText nvarchar(max) not null,
	
	CreateTS datetime2(0) constraint DF_SampleScript_CreateTS default(getdate()),
	UpdateTS datetime2,
	constraint PK_SampleScript primary key(StoreKey),
	
)
GO

create sequence [SqlDocs].[SampleScriptSequence]
	as int start with 1 cache 100;

	
