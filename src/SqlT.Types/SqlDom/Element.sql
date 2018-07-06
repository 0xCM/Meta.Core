create type [SqlDom].[Element] as table
(
	ElementName varchar(250) not null,	
	ParentName varchar(250) null,
	IsAbstract bit not null,
	ElementType nvarchar(75) not null

)
		

	
