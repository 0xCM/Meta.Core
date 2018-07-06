create table [Factory].[MergeProc]
(
  	FactoryKey bigint not null
		constraint DF_MergeProc_FactoryKey 
			default(next value for [Factory].[FactorySequence]),
	
	Identifier nvarchar(75) not null,
	MergeProcSchema nvarchar(128) not null,
	MergeProcName nvarchar(128) not null,
	SourceObjectSchema nvarchar(128) not null,
	SourceObjectName nvarchar(128) not null,
	TaretObjectSchema nvarchar(128) not null,
	TargetObjectName nvarchar(128) not null,
	SyncWithSource bit not null,
	[Description] nvarchar(250) null,
	CreateTS datetime2(0) not null
		constraint DF_MergeProc_CreateTS default(getdate()),

	constraint PK_MergeProc primary key(FactoryKey),
	constraint UQ_MergeProc unique(Identifier)

)
	
