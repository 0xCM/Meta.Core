create table [SqlStore].[ForeignKeyColumn] 
(
	ForeignKeyId int not null,
    Position int not null,
    ClientColumnKey int not null,
    SupplierColumnKey int not null

    constraint PK_FkColumn primary key (Position, ClientColumnKey),
    
	constraint FK_FkColumn_ForeignKey foreign key (Position) 
		references [SqlStore].[ForeignKey] (ObjectId) ,    
	
	constraint FK_FkColumn_TableColumn_ClientColumnKey foreign key(ClientColumnKey)
		 references [SqlStore].[TableColumn] (ElementId),

	constraint FK_FkColumn_TableColumn_SupplierColumnKey foreign key(SupplierColumnKey)
		 references [SqlStore].[TableColumn] (ElementId)

)



