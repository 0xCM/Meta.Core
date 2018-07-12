create type [WF].[ProcessingBatch] as table
(
	BatchNumber int not null,
	MinKey bigint not null,
	MaxKey bigint not null,
	[BatchSize] int not null,
	TotalCount int not null
);
GO
