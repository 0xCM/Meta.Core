create table [SqlStore].[ForeignKey]
(
    ObjectId int not null,
    ClientTableId   int not null,
	SupplierTableId int not null,
    
	constraint PK_ForeignKey primary key(ObjectId),
    
	constraint FK_ForeignKey_SchemaObject foreign key(ObjectId) 
		references [SqlStore].[SchemaObject](ObjectId),
    
	constraint FK_ForeignKey_ClientTableKey foreign key(ClientTableId) 
		references [SqlStore].[Table] (ObjectId) ,
			
	constraint FK_ForeignKey_SupplierTableKey foreign key(SupplierTableId) 
		references [SqlStore].[Table] (ObjectId) 

)

	 

GO

