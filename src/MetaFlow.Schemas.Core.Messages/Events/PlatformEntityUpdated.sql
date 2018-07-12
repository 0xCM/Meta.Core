﻿create type [E0].[PlatformEntityUpdated] as table
(
	HostId nvarchar(75) not null,
	EntityName nvarchar(75) not null
)
GO
	
exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[WF].[SystemEvent]',
    @level0type = N'SCHEMA',
    @level0name = N'E0',
    @level1type = N'Type',
    @level1name = N'PlatformEntityUpdated',
    @level2type = NULL,
    @level2name = NULL
GO




