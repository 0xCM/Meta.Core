create table  [SqlStore].[GenerationProfile]
(
	StoreKey int not null 
		constraint DF_GenerationProfile_StoreKey default(next value for [SqlStore].[StoreKeySequence]),
	AssemblyDesignator nvarchar(75) not null,
	ProfileName nvarchar(75) not null,
	SourceNode nvarchar(75) not null,
	SourceDatabase nvarchar(128),
	TargetAssembly nvarchar(128),
	ProfileText nvarchar(max) not null 
		constraint CK_GenerationProfile_ProfileText check(isjson(ProfileText)>0),    
	CreateTS  datetime2(0) not null
		constraint DF_GenerationProfile_CreateTS default (getdate()),
	UpdateTS  datetime2(0) null,

	constraint PK_GenerationProfile primary key(StoreKey),
	constraint UQ_GenerationProfile unique(AssemblyDesignator,ProfileName)

)
	
