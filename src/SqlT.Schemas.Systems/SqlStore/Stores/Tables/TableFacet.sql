create table [SqlStore].[TableFacet]
(
 	StoreKey int not null 
		constraint DF_TableFacet_StoreKey 
			default(next value for [SqlStore].[StoreKeySequence]),

	ServerName nvarchar(128) null,
	DatabaseName nvarchar(128) null,
	SchemaName nvarchar(128)not null,	
	TableName nvarchar(128) not null,
	FacetName nvarchar(128) not null,
	FacetValue nvarchar(250) null,
	CreateTS datetime2(0) not null
		constraint DF_TableFacet_CreateTS default(getdate()),
	UpdateTS datetime2(0) null,
	
	constraint PK_TableFacet primary key(StoreKey),
	constraint UQ_TableFacet unique(ServerName, DatabaseName, SchemaName, TableName, FacetName)
	

)
	
