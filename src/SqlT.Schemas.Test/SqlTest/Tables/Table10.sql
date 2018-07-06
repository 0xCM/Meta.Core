CREATE TABLE [SqlTest].[Table10]
(
	Col01 bigint not null constraint DF_Col01_Table10Key default (next value for [SqlTest].[Seq10]),
	Col02 nvarchar(75) not null,
	Col03 decimal(24,6) null,
	Col04 date not null,
	DbCreateTime datetime2(3) not null constraint DF_Table10_DbCreateTime default(getdate()),
	DbUpdateTime datetime2(3) null,

	constraint PK_Table10 primary key(Col01),
	constraint UQ_Table10 unique(Col02)
)
GO
create trigger [SqlTest].Table10Updated on [SqlTest].[Table10] after update as
	update [SqlTest].[Table10] set 
		DbUpdateTime = getdate()
	from 
		[SqlTest].[Table10] c 
	inner join 
		inserted on inserted.Col01 = c.Col01
GO

EXEC sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[SqlTest].[Table10Record]',
    @level0type = N'SCHEMA',
    @level0name = N'SqlTest',
    @level1type = N'Table',
    @level1name = N'Table10'
GO