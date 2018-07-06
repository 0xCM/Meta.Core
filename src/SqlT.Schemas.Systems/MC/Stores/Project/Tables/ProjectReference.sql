create table [MC].[ProjectReference]
(
	ClientProjectId nvarchar(75) not null,
	SupplierProjectId nvarchar(75) not null,
	CreateTS datetime2(0) not null
		constraint DF_ProjectReference_CreateTS default(getdate()),	
	UpdateTS datetime2(0) null,
	
	constraint FK_ProjectReference_Client foreign key(ClientProjectId)
		references [MC].[ProjectDefinition](ProjectId),
	
	constraint FK_ProjectReference_Supplier foreign key(SupplierProjectId)
		references [MC].[ProjectDefinition](ProjectId)
			on delete cascade
			on update cascade


)

