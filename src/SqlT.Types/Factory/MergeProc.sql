create type [Factory].[MergeProc] as table
(
	MergeProcSchema nvarchar(128) not null,
	MergeProcName nvarchar(128) not null,
	SourceObjectSchema nvarchar(128) not null,
	SourceObjectName nvarchar(128) not null,
	TaretObjectSchema nvarchar(128) not null,
	TargetObjectName nvarchar(128) not null,
	SyncWithSource bit not null,
	Documentation nvarchar(250) null

)
GO
	
