create type [C0].[CopyDataset] as table
(
	CommandNode nvarchar(75) not null,
 	SourceNodeId nvarchar(75) not null,
	TargetNodeId nvarchar(75) not null,
	DatasetName nvarchar(75) not null

)
GO
exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[WF].[SystemCommand]',
    @level0type = N'SCHEMA',
    @level0name = N'C0',
    @level1type = N'Type',
    @level1name = N'CopyDataset',
    @level2type = NULL,
    @level2name = NULL
GO




