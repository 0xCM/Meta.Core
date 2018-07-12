create table [PF].[PlatformShareRegistry]
(
	SystemKey bigint not null 
		constraint DF_PlatformShareStore_SystemKey 
			default(next value for [PF].[SystemKeySequence]),
	NodeId nvarchar(75) not null,
	ShareName nvarchar(75) not null,
	ShareType nvarchar(75) not null,
	HostPath nvarchar(500) not null,
	UncPath nvarchar(500) not null,
	CreateTS  datetime2(0) not null
		constraint DF_PlatformShareStore_CreateTS default (getdate()),
	UpdateTS  datetime2(0) null,	

	constraint PK_PlatformShareStore primary key(SystemKey),
	constraint FK_PlatformShareStore_PlatformNode foreign key(NodeId)
		references [PF].[PlatformServerRegistry](NodeId)

	
)
GO
create trigger [PF].[PlatformShareStoreUpdated] 
	on [PF].[PlatformShareRegistry] after update as
	update [PF].[PlatformShareRegistry] set 
		UpdateTS = getdate()
	from 
		[PF].[PlatformShareRegistry] x 
			inner join inserted on 
				inserted.SystemKey = x.SystemKey
