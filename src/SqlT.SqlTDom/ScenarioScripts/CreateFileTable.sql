create table [Platform].[Commands] 
	as filetable filestream_on PlatformFileShare
	with(filetable_directory = N'commands')