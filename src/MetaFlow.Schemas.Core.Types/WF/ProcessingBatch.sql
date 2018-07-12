create type [WF].[ProcessingBatch] as table
(
	BatchNumber int not null,
	MinKey bigint not null,
	MaxKey bigint not null,
	EnqueuedTS datetime2(0) not null,
	Dequeued bit not null, 		
	DequeuedTS datetime2(0) null,
	Complete bit not null,
	CompleteTS datetime2(0) null,
	Succeeded bit not null,
	BatchMessage nvarchar(250) null


);
