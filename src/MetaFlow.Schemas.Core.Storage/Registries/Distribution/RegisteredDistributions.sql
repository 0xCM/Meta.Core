create function [PF].[RegisteredDistributions]() returns table as return
	select 
		DistributionId,
		[Description]
	from
		[PF].[DistributionRegistry]
GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[T0].[DistributionDescription]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'FUNCTION',
    @level1name = N'RegisteredDistributions',
    @level2type = NULL,
    @level2name = NULL


