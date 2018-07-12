create table [PF].[NavigationFolderDefinition]
(
	SystemKey bigint not null 
		constraint DF_NavigationFolder_SystemKey 
			default(next value for [PF].[SystemKeySequence]),
	FolderIdentifier nvarchar(75) not null,
	NavigatorType nvarchar(75) not null,
	FolderName nvarchar(75) not null,
	CreateTS datetime2(0) not null 
		constraint DF_NavigationFolder_CreateTS default(getdate()),
	UpdateTS datetime2(0) null,

	constraint PK_NavigationFolder primary key(SystemKey),
	constraint UQ_NavigationFolder unique(NavigatorType,FolderName),
	constraint UQ_NavigationFolder_Identifier unique(FolderIdentifier),
	constraint FK_NavigationFolder_PlatformNavigatorType foreign key(NavigatorType)
		references [PF].[PlatformNavigatorType](Identifier)
		
)
	
GO
create trigger [PF].[OnNavigationFolderUpdated] 
	on [PF].[NavigationFolderDefinition] after update as
		update [PF].[NavigationFolderDefinition] set 
			UpdateTS = getdate()
	from 
		[PF].[NavigationFolderDefinition] x 
			inner join inserted on 
				inserted.SystemKey = x.SystemKey
