CREATE TABLE [SqlTest].[Table09]
(
	Col01 int NOT NULL PRIMARY KEY,
	Col02 bigint not null,
	Col03 binary(50) not null,
	Col04 bit not null,
	Col05 char(12) not null,
	Col06 date not null,
	Col07 datetime not null,
	Col08 datetime2 not null,
	Col09 decimal(18,12) not null,
	Col10 float not null,
	Col11 money not null,
	Col12 nchar(100) not null,
	Col13 datetimeoffset not null,
	Col14 ntext not null,
	Col15 numeric(15,5) not null,
	Col16 nvarchar(73) not null,
	Col17 real not null,
	Col18 rowversion not null,
	Col19 smalldatetime not null,
	Col20 smallint not null,
	Col21 smallmoney not null,
	Col22 sql_variant not null,
	Col23 text not null,
	Col24 time not null,
	Col25 tinyint not null,
	Col26 uniqueidentifier not null,
	Col27 varbinary(223) not null,
	Col28 varchar(121) not null,
	Col29 xml not null, 
	Col31 image not null,
	Col32 varbinary(MAX) not null,
	Col33 varchar(MAX) not null,
	Col35 nvarchar(MAX) not null, 
    Col36 sysname NOT NULL
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'int',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table09',
    @level2type = N'COLUMN',
    @level2name = N'Col01'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'bigint',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table09',
    @level2type = N'COLUMN',
    @level2name = N'Col02'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'binary(50)',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table09',
    @level2type = N'COLUMN',
    @level2name = N'Col03'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'bit',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table09',
    @level2type = N'COLUMN',
    @level2name = N'Col04'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'char(12)',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table09',
    @level2type = N'COLUMN',
    @level2name = N'Col05'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'date',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table09',
    @level2type = N'COLUMN',
    @level2name = N'Col06'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'datetime',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table09',
    @level2type = N'COLUMN',
    @level2name = N'Col07'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'datetime2(7)',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table09',
    @level2type = N'COLUMN',
    @level2name = N'Col08'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'decimal(18,12)',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table09',
    @level2type = N'COLUMN',
    @level2name = N'Col09'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'float',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table09',
    @level2type = N'COLUMN',
    @level2name = N'Col10'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'money',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table09',
    @level2type = N'COLUMN',
    @level2name = N'Col11'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'nchar(100)',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table09',
    @level2type = N'COLUMN',
    @level2name = N'Col12'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'datetimeoffset(7)',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table09',
    @level2type = N'COLUMN',
    @level2name = N'Col13'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'ntext',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table09',
    @level2type = N'COLUMN',
    @level2name = N'Col14'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'numeric(15,5)',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table09',
    @level2type = N'COLUMN',
    @level2name = N'Col15'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'nvarchar(73)',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table09',
    @level2type = N'COLUMN',
    @level2name = N'Col16'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'real',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table09',
    @level2type = N'COLUMN',
    @level2name = N'Col17'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'rowversion',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table09',
    @level2type = N'COLUMN',
    @level2name = N'Col18'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'smalldatetime',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table09',
    @level2type = N'COLUMN',
    @level2name = N'Col19'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'smallint',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table09',
    @level2type = N'COLUMN',
    @level2name = N'Col20'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'smallmoney',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table09',
    @level2type = N'COLUMN',
    @level2name = N'Col21'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'sql_variant',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table09',
    @level2type = N'COLUMN',
    @level2name = N'Col22'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'text',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table09',
    @level2type = N'COLUMN',
    @level2name = N'Col23'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'time(7)',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table09',
    @level2type = N'COLUMN',
    @level2name = N'Col24'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'tinyint',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table09',
    @level2type = N'COLUMN',
    @level2name = N'Col26'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'uniqueidentifier',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table09',
    @level2type = N'COLUMN',
    @level2name = N'Col27'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'varbinary(223)',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table09',
    @level2type = N'COLUMN',
    @level2name = N'Col28'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'varchar(121)',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table09',
    @level2type = N'COLUMN',
    @level2name = N'Col29'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'geography',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table09',
    @level2type = N'COLUMN',
    @level2name = N'Col31'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'image',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table09',
    @level2type = N'COLUMN',
    @level2name = N'Col32'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'varbinary(MAX)',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table09',
    @level2type = N'COLUMN',
    @level2name = N'Col33'
GO

GO

EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'nvarchar(MAX)',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table09',
    @level2type = N'COLUMN',
    @level2name = N'Col35'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'sysname',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table09',
    @level2type = N'COLUMN',
    @level2name = N'Col36'