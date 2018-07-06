create table [SqlStore].[PrimaryKey]
(
    ObjectId int not null,
    TableKey   int not null,
	PrimaryKeyName sysname,
	IsClustered bit not null,
    
	constraint PK_PrimaryKey primary key(ObjectId),
	constraint UQ_PrimaryKey unique(TableKey),
    
	constraint FK_PrimaryKey_SchemaObject foreign key(ObjectId) 
		references [SqlStore].[SchemaObject](ObjectId),
    
	constraint FK_PrimaryKey_Table foreign key(TableKey) 
		references [SqlStore].[Table] (ObjectId) 
			
)
GO
