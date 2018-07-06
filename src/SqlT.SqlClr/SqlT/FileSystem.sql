create function [SqlT].[Dir](@SrcPath nvarchar(4000), @Filter nvarchar(250)) returns table 
	(
		FilePath nvarchar(4000), 
		IsDirectory bit, 
		CreationTime datetime, 
		LastWriteTime datetime, 
		Size bigint
	)
	as external name [SqlT.SqlClr].[FileSystem].[Dir]
GO

create procedure [SqlT].[CopyFile](@SrcPath nvarchar(4000), @DstPath nvarchar(4000))
	as external name [SqlT.SqlClr].[FileSystem].[CopyFile]
GO
create procedure [SqlT].[CopyFolder](@SrcPath nvarchar(4000), @DstPath nvarchar(4000))
	as external name [SqlT.SqlClr].[FileSystem].[CopyFolder]
GO

create procedure [SqlT].[WriteTextToFile](@SrcText nvarchar(MAX), @DstPath nvarchar(500))
	as external name [SqlT.SqlClr].[FileSystem].[WriteTextToFile]
GO

create function [SqlT].[Drives]() returns table 
	(
		DrivePath nvarchar(250) 
	)
	as external name [SqlT.SqlClr].[FileSystem].[Drives]
GO
