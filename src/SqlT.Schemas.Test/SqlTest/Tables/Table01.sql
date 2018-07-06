CREATE TABLE SqlTest.[Table01]
(
	Col01 INT NOT NULL,
	Col02 bigint,
	Col03 nvarchar(50) NOT NULL,
	Col04 nvarchar(Max),
	Col05 SqlTest.Primitive01,
	constraint PK_Table01 primary key(Col01) 
) on FileGroupA
GO

EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'SQL Test Table01',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'Table',
    @level1name = N'Tabl01',
    @level2type = N'CONSTRAINT',
    @level2name = N'PK_Table01'
Go

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'SQL Test Table01',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table01',
    @level2type = NULL,
    @level2name = NULL
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Col01 Description Text',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table01',
    @level2type = N'COLUMN',
    @level2name = N'Col01'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Col03 Description Text',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table01',
    @level2type = N'COLUMN',
    @level2name = N'Col03'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Col04 Description Text',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table01',
    @level2type = N'COLUMN',
    @level2name = N'Col04'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Col02 Description Text',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'TABLE',
    @level1name = N'Table01',
    @level2type = N'COLUMN',
    @level2name = N'Col02'
