create table [SqlStore].[ComparisionOperator]
(
	[Name] nvarchar(75) not null,
	Symbol nvarchar(5) not null,
	constraint PK_ComparisonOperator primary key(Name),
	constraint UQ_ComparisonOperator unique(Symbol)
)

GO

