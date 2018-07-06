create table [SqlStore].[SchemaObject] 
(
    ObjectId int not null,
    SchemaId  int not null,
	ObjectName sysname not null,
	
	constraint PK_Object primary key(ObjectId),
	
	constraint FK_SchemaObject_DbElement foreign key(ObjectId) 
		references [SqlStore].[Element](Id),
    
	constraint [FK_SchemaObject_Schema] foreign key(SchemaId) 
		references [SqlStore].[Schema] (Id) ,
	
)


GO

