create table [PF].[PlatformEntityStore]
(	
	SystemKey bigint not null 
		constraint DF_PlatformEntity_SystemKey default(next value for [PF].[SystemKeySequence]),
	EntityName nvarchar(75) not null,
	TypeUri nvarchar(250) not null,
	Body nvarchar(max) not null
		constraint CK_PlatformEntity_ResultBody check(isjson(Body)>0),  
		
	CreateTS datetime2(0) not null
		constraint DF_PlatformEntity_CreateTS default(getdate()),
	UpdateTS datetime2(0) null,

	constraint PK_PlatformEntityStore primary key(SystemKey),
	constraint UQ_PlatformEntityStore unique(EntityName)	
)
GO




GO
		









	

	
