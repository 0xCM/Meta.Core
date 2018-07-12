create type [WF].[BatchCompletion] as table
(
	BatchNumber int not null,
	CompleteTS datetime2(0) null,
	Succeeded bit not null,
	BatchMessage nvarchar(250) null
)

