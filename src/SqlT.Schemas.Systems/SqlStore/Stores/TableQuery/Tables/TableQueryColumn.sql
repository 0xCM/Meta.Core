create table [SqlStore].[TableQueryColumn]
(
	StoreKey int not null 
		constraint DF_TableQueryColumn_ColumnId 
			default(next value for [SqlStore].[StoreKeySequence]),
	QueryId int not null,
	ColumnPosition int not null,
	ColumnName sysname,
	ColumnAlias nvarchar(128) null,
	CreateTS datetime2(0) not null
		constraint DF_TableQueryColumn_CreateTS default(getdate()),
	UpdateTS datetime2(0) null,

	constraint PK_TableQueryColumn primary key(StoreKey),
	constraint UQ_TableQueryColumn_Position unique(QueryId, ColumnPosition),
	constraint UQ_TableQueryColumn_Name unique(QueryId, ColumnName),

	constraint FK_TableQueryColumn_TableQuery foreign key(QueryId)
		references [SqlStore].[TableQuery](QueryId),

)

GO
