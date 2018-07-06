create table [SqlStore].[ColumnRoleAssignment] 
(
	StoreKey int not null 
		constraint DF_ColumnRoleAssignment_StoreKey default(next value for [SqlStore].[SqlStoreKey]),
		
	ServerName nvarchar(128) not null,
	DatabaseName nvarchar(128) not null,
	ObjectSchema nvarchar(128) not null,
	ObjectName nvarchar(128) not null,
	ColumnName nvarchar(128) not null,
	ColumnRole nvarchar(75) not null,

	CreateTS datetime2(0) not null
		constraint DF_ColumnRoleAssignment default(getdate()),
	UpdateTS datetime2(0) null,

	constraint PK_ColumnRoleAssignment primary key(StoreKey),
	constraint UQ_ColumnRoleAssignment unique(ServerName, DatabaseName, ObjectSchema, ObjectName, ColumnName),
	--constraint FK_ColumnRoleAssignment_ColumnRoleType foreign key (ColumnRole)
	--	references [SqlStore].[ColumnRoleType](Identifier)
	

)

GO
create sequence [SqlStore].[SqlStoreKey] 
	as int start with 1

	
