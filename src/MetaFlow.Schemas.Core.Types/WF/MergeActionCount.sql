create type [WF].[MergeActionCount] as table
(
	InsertCount int not null,
	UpdateCount int not null,
	DeleteCount int not null
)
GO

