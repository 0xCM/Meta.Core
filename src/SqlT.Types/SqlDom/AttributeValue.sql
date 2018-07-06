create type [SqlDom].[AttributeValue] as table
(

	ElementName varchar(250) not null,
	AttributeName varchar(250) not null,
	AttributeValue varchar(250) not null
)
	
