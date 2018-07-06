create function [SqlDocs].[Configurations]() returns table as return
	select 
		ConfigurationName,
		RepositoryLocation,
		SelectedSections
	from 
		[SqlDocs].[Configuration]
GO

exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[SqlDocs].[Configuration]',
    @level0type = N'SCHEMA',
    @level0name = N'SqlDocs',
    @level1type = N'FUNCTION',
    @level1name = N'Configurations',
    @level2type = NULL,
    @level2name = NULL
	
