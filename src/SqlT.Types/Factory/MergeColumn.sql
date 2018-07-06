create type [Factory].[MergeColumn] as table
(
	ColumnPosition int not null,
	SourceColumn nvarchar(128) not null,
	TargetColumn nvarchar(128) not null,
	IsMatchColumn bit not null
)
