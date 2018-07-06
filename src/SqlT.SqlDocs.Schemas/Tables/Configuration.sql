create table [SqlDocs].[Configuration] 
(
	ConfigurationName nvarchar(75) not null
		constraint DF_Configuration_ConfigurationName default('Default'),		
	RepositoryLocation nvarchar(250) not null,
	SelectedSections nvarchar(250) null,
	CreateTS datetime2(0) 
		constraint DF_Configuration_CreateTS default(getdate()),
	UpdateTS datetime2,
	constraint PK_Configuration primary key(ConfigurationName)

)
GO
create trigger [SqlDocs].[OnConfigurationUpdated] 
	on [SqlDocs].[Configuration] after update as
		update [SqlDocs].[Configuration] set 
			UpdateTS = getdate()
		from 
			[SqlDocs].[Configuration] c 
				inner join inserted on 
					inserted.ConfigurationName = c.ConfigurationName
GO
	
