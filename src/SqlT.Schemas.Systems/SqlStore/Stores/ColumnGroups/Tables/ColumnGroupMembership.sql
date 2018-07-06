create table [SqlStore].[ColumnGroupMembership] 
(
	StoreKey int not null 
		constraint DF_ColumnGroupMembership_StoreKey 
			default(next value for [SqlStore].[SqlStoreKey]),
	ServerName nvarchar(128) not null,
	DatabaseName nvarchar(128) not null,
	ObjectSchema nvarchar(128) not null,
	ObjectName nvarchar(128) not null,
	ColumnName nvarchar(128) not null,
	GroupTypeName nvarchar(75) not null,


	CreateTS datetime2(0) not null
		constraint DF_ColumnGroupMembership default(getdate()),

	constraint PK_ColumnGroupMembership primary key(StoreKey),
	constraint UQ_ColumnGroupMembership unique(GroupTypeName, ServerName, DatabaseName, ObjectSchema, ObjectName, ColumnName),
	--constraint FK_ColumnGroupMembership_ColumnRoleType foreign key (ColumnRole)
	--	references [SqlStore].[ColumnRoleType](Identifier)
	

)

GO
