create type [WF].[SystemEventIdentity] as table
(
	EventId uniqueidentifier not null,
	PairId uniqueidentifier null
)
GO
exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[SqlT].[SqlTableTypeProxy]',
    @level0type = N'SCHEMA',
    @level0name = N'WF',
    @level1type = N'Type',
    @level1name = N'SystemEventIdentity',
    @level2type = NULL,
    @level2name = NULL
GO





