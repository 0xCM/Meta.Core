create table [SqlStore].[TableColumnFacet]
(
 	StoreKey int not null 
		constraint DF_TableColumnFacet_StoreKey 
			default(next value for [SqlStore].[StoreKeySequence]),

	ServerName nvarchar(128) null,
	DatabaseName nvarchar(128) null,
	SchemaName nvarchar(128)not null,	
	TableName nvarchar(128) not null,
	ColumnName nvarchar(128) not null,
	FacetName nvarchar(128) not null,
	FacetValue nvarchar(150) null,
	CreateTS datetime2(0) not null
		constraint DF_TableColumnFacet_CreateTS default(getdate()),
	UpdateTS datetime2(0) null,

	constraint PK_TableColumnFacet primary key(StoreKey),
	constraint UQ_TableColumnFacet unique(ServerName, DatabaseName, SchemaName, TableName, ColumnName, FacetName)
	

)
	
