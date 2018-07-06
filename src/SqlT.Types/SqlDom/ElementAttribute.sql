create type [SqlDom].[ElementAttribute] as table
(
	ElementName varchar(250) not null,
	AttributeName varchar(250) not null,
	DataType varchar(250) not null,
	Infrastructure bit not null,
	IsReadOnly bit not null 
)
