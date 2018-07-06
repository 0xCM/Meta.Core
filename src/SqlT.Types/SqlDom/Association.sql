create type [SqlDom].[Association] as table
(
	ElementName varchar(250) not null,
	AssociationName varchar(250) not null,	
	AssociationType varchar(250) not null,
	IsReadOnly bit not null 

)

GO

