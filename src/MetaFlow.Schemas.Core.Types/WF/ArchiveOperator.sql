create type [WF].[ArchiveOperator] as table
(
	ResetOutstanding bit null,
	RetryFailures bit
)

	
