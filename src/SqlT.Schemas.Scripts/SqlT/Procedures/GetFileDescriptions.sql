create procedure [SqlT].[GetFileDescriptions](@FileState nvarchar(50), @FileType nvarchar(50)) as
begin
declare @var_sql nvarchar(500) = 
	'select ' +
	'path_locator.ToString() as FileId, ' +  
	'''' + @FileState + '''' +  ' as FileStateName, ' +
	'''' + @FileType + '''' +  ' as FileTypeName, ' +
	'file_stream.GetFileNamespacePath(1) as FilePath, ' +
	'cached_file_size as FileSize ,' +
	'creation_time as CreationTime ' + 
	'from Files.' + @FileState + @FileType

exec sp_sqlexec @var_sql

end
GO

EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Retrieves descriptions for the files that match with the supplied state and file type',
    @level0type = N'SCHEMA',
    @level0name = N'SqlT',
    @level1type = N'PROCEDURE',
    @level1name = N'GetFileDescriptions',
    @level2type = NULL,
    @level2name = NULL
GO