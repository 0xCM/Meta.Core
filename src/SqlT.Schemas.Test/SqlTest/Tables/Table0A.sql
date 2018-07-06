CREATE TABLE [SqlTest].Table0A
(
	Col01 int NOT NULL PRIMARY KEY,
	Col02 bigint null,
	Col03 binary(50) null,
	Col04 bit null,
	Col05 char(50) null,
	Col06 date null,
	Col07 datetime null,
	Col08 datetime2 null,
	Col09 decimal(18,12) null,
	Col10 float null,
	Col11 money null,
	Col12 nchar(100) null,
	Col13 numeric(15,5) null,
	Col14 nvarchar(73) null,
	Col15 real null,
	Col16 smalldatetime null,
	Col17 smallint null,
	Col18 smallmoney null,
	Col19 sql_variant null,
	Col20 tinyint null,
	Col21 uniqueidentifier null,
	Col22 varbinary(223) null,
	Col23 varchar(121) null,
	Col24 varbinary(MAX) null,
	Col25 varchar(MAX) null,
	Col26 nvarchar(MAX) null, 
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'int',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table0A',
    @level2type = N'COLUMN',
    @level2name = N'Col01'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'bigint',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table0A',
    @level2type = N'COLUMN',
    @level2name = N'Col02'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'binary(50)',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table0A',
    @level2type = N'COLUMN',
    @level2name = N'Col03'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'bit',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table0A',
    @level2type = N'COLUMN',
    @level2name = N'Col04'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'char(12)',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table0A',
    @level2type = N'COLUMN',
    @level2name = N'Col05'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'date',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table0A',
    @level2type = N'COLUMN',
    @level2name = N'Col06'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'datetime',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table0A',
    @level2type = N'COLUMN',
    @level2name = N'Col07'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'datetime2(7)',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table0A',
    @level2type = N'COLUMN',
    @level2name = N'Col08'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'decimal(18,12)',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table0A',
    @level2type = N'COLUMN',
    @level2name = N'Col09'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'float',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table0A',
    @level2type = N'COLUMN',
    @level2name = N'Col10'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'money',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table0A',
    @level2type = N'COLUMN',
    @level2name = N'Col11'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'nchar(100)',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table0A',
    @level2type = N'COLUMN',
    @level2name = N'Col12'
GO
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'numeric(15,5)',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table0A',
    @level2type = N'COLUMN',
    @level2name = N'Col13'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'nvarchar(73)',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table0A',
    @level2type = N'COLUMN',
    @level2name = N'Col14'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'real',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table0A',
    @level2type = N'COLUMN',
    @level2name = N'Col15'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'smalldatetime',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table0A',
    @level2type = N'COLUMN',
    @level2name = N'Col16'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'smallint',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table0A',
    @level2type = N'COLUMN',
    @level2name = N'Col17'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'smallmoney',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table0A',
    @level2type = N'COLUMN',
    @level2name = N'Col18'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'sql_variant',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table0A',
    @level2type = N'COLUMN',
    @level2name = N'Col19'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'tinyint',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table0A',
    @level2type = N'COLUMN',
    @level2name = N'Col20'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'uniqueidentifier',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table0A',
    @level2type = N'COLUMN',
    @level2name = N'Col21'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'varbinary(223)',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table0A',
    @level2type = N'COLUMN',
    @level2name = N'Col22'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'varchar(121)',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table0A',
    @level2type = N'COLUMN',
    @level2name = N'Col23'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'varbinary(MAX)',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table0A',
    @level2type = N'COLUMN',
    @level2name = N'Col24'
GO

EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'varchar(MAX)',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table0A',
    @level2type = N'COLUMN',
    @level2name = N'Col25'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'nvarchar(MAX)',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table0A',
    @level2type = N'COLUMN',
    @level2name = N'Col26'
GO
