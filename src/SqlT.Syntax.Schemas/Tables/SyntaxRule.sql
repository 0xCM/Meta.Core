create table [Syntax].[SyntaxRule] 
(
	RuleName nvarchar(128) not null,
	[Description] nvarchar(250) null,
	CreateTS datetime2(0) not null
		constraint DF_SyntaxRule_CreateTS default(getdate()),	
	UpdateTS datetime2(0) null,



)
	
