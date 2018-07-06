CREATE TABLE [SqlTest].[Table0F]
(
	[Col01] INT NOT NULL,
	[Col02] varchar(50) not null,
	[Col03] varchar(250) null,

	constraint PK_Table0F primary key(Col01),
)
GO
create index IX_Table0F on [SqlTest].[Table0F](Col02)
GO
