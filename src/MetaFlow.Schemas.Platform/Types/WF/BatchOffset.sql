create type [WF].[BatchOffset] as table
(
	OffSetBy int not null,
	MinKey bigint not null,
	MaxKey bigint not null,
	[BatchSize] int not null
)
