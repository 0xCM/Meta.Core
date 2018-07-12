create table [PF].[NodeDriveMapDefinition]
(
	SystemKey bigint not null 
		constraint DF_NodeDriveMap_SystemKey default(next value for [PF].[SystemKeySequence]),
	NodeId nvarchar(75) not null,
	DriveLetter char(1) not null,
	DataSource nvarchar(500) not null,
	UserName nvarchar(128) null,
	UserPass nvarchar(128) null,
	CreateTS datetime2(0) not null 
		constraint DF_NodeDriveMap_CreateTS default(getdate()),
	UpdateTS datetime2 (0) null,

	constraint PK_NodeDriveMap primary key(SystemKey),
	constraint UQ_NodeDriveMap unique(NodeId,DriveLetter)
)
GO
create trigger [PF].[NodeDriveMapUpdated] 
	on [PF].[NodeDriveMapDefinition] after update as
		update [PF].[NodeDriveMapDefinition] set 
			UpdateTS = getdate()
	from 
		[PF].[NodeDriveMapDefinition] x 
			inner join inserted on 
				inserted.SystemKey = x.SystemKey



	