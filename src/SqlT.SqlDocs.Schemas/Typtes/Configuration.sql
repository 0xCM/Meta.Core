create type [SqlDocs].[Configuration] as table
(
	ConfigurationName nvarchar(75) not null,
	RepositoryLocation nvarchar(250) not null,
	SelectedSections nvarchar(250) null

)
	
