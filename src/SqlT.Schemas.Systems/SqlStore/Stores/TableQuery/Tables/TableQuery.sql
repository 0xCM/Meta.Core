create table [SqlStore].[TableQuery]
(
	QueryId int not null 
		constraint DF_TableQuery_QueryId 
			default(next value for [SqlT].[TableQuerySeq]),
	QueryName nvarchar(250) not null,
	TableCatalog sysname,
	TableSchema sysname,
	TableName sysname,
	TableAlias nvarchar(128) null,
	CreateTS datetime2(0) not null
		constraint DF_TableQuery_CreateTS default(getdate()),
	UpdateTS datetime2(0) null,

	constraint PK_TableQuery primary key(QueryId),
	constraint UQ_QueryName unique(QueryName)

)
GO

create sequence [SqlT].[TableQuerySeq] 
	as int start with 1 cache 10
GO

