create function [PF].[FolderFromPath](@SrcPath nvarchar(4000)) returns nvarchar(4000) as
begin
	declare 
	@SrcDir nvarchar(4000) = left(@SrcPath, len(@SrcPath) - charindex('\',reverse(@SrcPath)))
	return @SrcDir
end

