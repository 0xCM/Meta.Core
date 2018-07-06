CREATE type [SqlTest].[Table04Record] as table
(
	[Id] INT NOT NULL, 
	Code nvarchar(10) not null,
	StartDate date not null,
	EndDate date not null
)
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Documentation for [SqlTest].[Table04Rrecord]',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'Type',
    @level1name = N'Table04Record'
GO
