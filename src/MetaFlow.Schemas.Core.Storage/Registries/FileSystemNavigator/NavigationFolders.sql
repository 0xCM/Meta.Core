create function [PF].[NavigationFolders]() returns table as return
	select
		FolderIdentifier,		
		NavigatorType, 
		FolderName 
	from 
		[PF].[NavigationFolderDefinition]
	
