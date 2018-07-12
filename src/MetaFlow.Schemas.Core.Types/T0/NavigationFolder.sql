create type [T0].[NavigationFolder] as table
(
	FolderIdentifier nvarchar(75) not null,
	NavigatorType nvarchar(75) not null,
	FolderName nvarchar(75) not null	
)
	
