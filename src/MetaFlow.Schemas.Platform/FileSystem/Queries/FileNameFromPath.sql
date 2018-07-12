create function [PF].[FileNameFromPath](@SrcPath nvarchar(4000)) returns nvarchar(4000) as
begin
	declare  @FileName nvarchar(4000)
		= (right(@SrcPath, charindex('\',REVERSE(@SrcPath))-1));
	return @FileName;
end

