CREATE TABLE [SqlTest].[Table05]
(
	[Col01] INT NOT NULL identity(1,1), 
    [Col02] TINYINT NOT NULL, 
    [Col03] SMALLINT NOT NULL, 
    [Col04] BIGINT NOT NULL,
	[Col05] datetime2(3) not null constraint DF_Table05_Col05 default(getdate()),
	constraint PK_Table05 primary key(Col01)
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Used to verify the simplest bulk insert scenario possible',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table05',
    @level2type = NULL,
    @level2name = NULL