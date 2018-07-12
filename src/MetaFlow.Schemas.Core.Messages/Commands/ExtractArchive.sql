create type [C0].[ExtractArchive] as table
(	
	CommandNode nvarchar(75) not null,
	ArchivePath nvarchar(250) not null,
	TargetFolder nvarchar(250) not null
)
GO	
exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[WF].[SystemCommand]',
    @level0type = N'SCHEMA',
    @level0name = N'C0',
    @level1type = N'Type',
    @level1name = N'ExtractArchive',
    @level2type = NULL,
    @level2name = NULL
GO








		
	
	
