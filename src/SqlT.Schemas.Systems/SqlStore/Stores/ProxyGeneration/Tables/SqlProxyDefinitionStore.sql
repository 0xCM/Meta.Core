create table [SqlStore].[SqlProxyDefinitionStore]
(
	StoreKey int not null 
		constraint DF_SqlProxyDefinition_StoreKey default(next value for [SqlStore].[StoreKeySequence]),
	AssemblyDesignator nvarchar(75) not null,
	ProfileName nvarchar(75) not null,
	SourceNode nvarchar(75) not null,
	SourceDatabase nvarchar(128),
	TargetAssembly nvarchar(128),
	ProfileText nvarchar(max) not null 
		constraint CK_SqlProxyDefinition_ProfileText check(isjson(ProfileText)>0),    
	CreateTS  datetime2(0) not null
		constraint DF_SqlProxyDefinition_CreateTS default (getdate()),
	UpdateTS  datetime2(0) null,

	constraint PK_SqlProxyDefinition  primary key(StoreKey),
	constraint UQ_SqlProxyDefinition unique(AssemblyDesignator,ProfileName),
)

GO

