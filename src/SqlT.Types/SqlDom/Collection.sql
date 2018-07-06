create type [SqlDom].[Collection] as table
(
	ElementName varchar(250) not null,
	CollectionName varchar(250) not null,	
	ItemType varchar(250) not null,
	IsReadOnly bit not null 
)
		

	
