create table [SqlStore].[PrimaryKeyColumn] 
(
    PrimaryKeyId  int not null,
    TableId int not null,

    constraint PK_PrimaryKeyColumn primary key(PrimaryKeyId,TableId),    
	constraint FK_PrimaryKeyColumn_PrimaryKey foreign key (PrimaryKeyId) 
		references [SqlStore].[PrimaryKey] (ObjectId),    
	constraint FK_PrimaryKeyColumn_TableColumn foreign key(TableId)
		 references [SqlStore].[TableColumn] (ElementId)
)


GO
