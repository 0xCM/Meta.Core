create function [PF].[FindPlatformEntity](@EntityName nvarchar(75)) returns table as return
	select 
		EntityName,
		TypeUri,
		Body
	from
		[PF].[PlatformEntityStore]
	where
		EntityName = @EntityName
GO
exec sp_addextendedproperty @name = N'DM_RecordType',
    @value = N'[T0].[PlatformEntity]',
    @level0type = N'SCHEMA',
    @level0name = N'PF',
    @level1type = N'FUNCTION',
    @level1name = N'FindPlatformEntity',
    @level2type = NULL,
    @level2name = NULL


	
