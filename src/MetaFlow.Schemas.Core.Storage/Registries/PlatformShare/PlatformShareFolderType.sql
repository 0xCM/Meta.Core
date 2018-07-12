create table [PF].[PlatformShareFolderType]
(
	SystemKey bigint not null 
		constraint DF_PlatformShareFolderType_SystemKey 
			default(next value for [PF].[SystemKeySequence]),
	Identifier nvarchar(75) not null,
	ShareType nvarchar(75) not null,
	RelativePath nvarchar(150) not null,
	CreateTS  datetime2(0) not null
		constraint DF_PlatformShareFolderType_CreateTS default (getdate()),
	UpdateTS  datetime2(0) null,	

	constraint PK_PlatformShareFolderType primary key(SystemKey),
	constraint UQ_PlatformShareFolderType unique(ShareType,RelativePath)
)
GO
create trigger [PF].[OnPlatformShareFolderTypeUpdated] 
	on [PF].[PlatformShareFolderType] after update as
	update [PF].[PlatformShareFolderType] set 
		UpdateTS = getdate()
	from 
		[PF].[PlatformShareFolderType] x 
			inner join inserted on 
				inserted.SystemKey = x.SystemKey

