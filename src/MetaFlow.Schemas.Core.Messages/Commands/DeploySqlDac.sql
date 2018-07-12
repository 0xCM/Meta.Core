create type [C0].[DeploySqlDac] as table
(
	CommandNode nvarchar(75) not null,
  	DatabaseServer nvarchar(75) not null,
	PackageName nvarchar(75) not null
)
GO
exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[WF].[SystemCommand]',
    @level0type = N'SCHEMA',
    @level0name = N'C0',
    @level1type = N'Type',
    @level1name = N'DeploySqlDac',
    @level2type = NULL,
    @level2name = NULL
GO







	
