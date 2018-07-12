CREATE TABLE [Configuration].[ComponentConfiguration]
(
	EnvironmentName nvarchar(75) not null,
	ComponentName nvarchar(75) not null,
	SettingName nvarchar(75) not null,
	SettingValue nvarchar(MAX) not null,
	SettingDescription nvarchar(250) null,
	DbVersion rowversion,
	DbCreateUser nvarchar(75) not null constraint DF_ComponentConfiguration_CreateUser default(suser_sname()),
	DbCreateTime datetime2(7) not null constraint DF_ComponentConfiguration_CreateTime default(sysdatetime()),
	DbUpdateUser nvarchar(75) null,
	DbUpdateTime datetime2(7) null,

	constraint PK_ComponentConfiguration primary key(EnvironmentName, ComponentName, SettingName)
)
GO

create trigger [Configuration].ComponentConfigurationUpdate on [Configuration].[ComponentConfiguration] after update as
	update [Configuration].[ComponentConfiguration] set 
		DbUpdateUser = suser_sname(),
		DbUpdateTime = sysdatetime()
	from 
		[Configuration].[ComponentConfiguration] c 
	inner join 
		inserted on inserted.EnvironmentName = c.EnvironmentName 
				and inserted.ComponentName = c.ComponentName
				and inserted.SettingName = c.SettingName
GO

create synonym [Configuration].[ComponentSetting] for [Configuration].[ComponentConfiguration]
GO


EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Content specifies configuration settings for a given component  within a given environment',
    @level0type = N'SCHEMA',
    @level0name = N'Configuration',
    @level1type = N'TABLE',
    @level1name = N'ComponentConfiguration',
    @level2type = NULL,
    @level2name = NULL
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'The name of the environment to which the setting applies, e.g., LocalDev, TeamDev, Integration, QA, Prod',
    @level0type = N'SCHEMA',
    @level0name = N'Configuration',
    @level1type = N'TABLE',
    @level1name = N'ComponentConfiguration',
    @level2type = N'COLUMN',
    @level2name = N'EnvironmentName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'The name of the component to which the setting applies e.g., BillingMaster.Recon, BillingMasterRecon',
    @level0type = N'SCHEMA',
    @level0name = N'Configuration',
    @level1type = N'TABLE',
    @level1name = N'ComponentConfiguration',
    @level2type = N'COLUMN',
    @level2name = N'ComponentName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'The name of the setting that uniquley identifies it within the scope of the environment and component',
    @level0type = N'SCHEMA',
    @level0name = N'Configuration',
    @level1type = N'TABLE',
    @level1name = N'ComponentConfiguration',
    @level2type = N'COLUMN',
    @level2name = N'SettingName'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'The value of the setting',
    @level0type = N'SCHEMA',
    @level0name = N'Configuration',
    @level1type = N'TABLE',
    @level1name = N'ComponentConfiguration',
    @level2type = N'COLUMN',
    @level2name = N'SettingValue'