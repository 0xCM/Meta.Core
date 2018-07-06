create table [SqlStore].[ColumnComparision]
(
	ComparisonId int not null 
		constraint DF_ColumnComparision_ComparisionId 
			default(next value for [SqlT].[ColumnComparisonSeq]),
	
	ColumnId int not null,
	ComparisonPosition int not null,
	Junction nvarchar(5) null,
	ComparisonOp nvarchar(5) not null,
	Operand sql_variant not null,
	

	constraint PK_ColumnComparision primary key(ComparisonId),	
	constraint FK_ColumnComparison_QueryColumn foreign key(ColumnId)
		references [SqlStore].[TableQueryColumn](StoreKey),
	constraint UQ_ColumnComparison unique(ColumnId, ComparisonPosition)

)
GO

create sequence [SqlT].[ColumnComparisonSeq] 
	as int start with 1 cache 10

GO

