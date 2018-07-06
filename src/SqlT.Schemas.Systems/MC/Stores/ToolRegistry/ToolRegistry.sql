create table [MC].[ToolRegistry]
(
	StoreKey bigint not null 
		constraint DF_ToolRegistry_SystemKey 
			default(next value for [SqlStore].[StoreKeySequence]),
	ToolId nvarchar(75) not null,
	ExecutableName nvarchar(75) not null,
	ExecutablePath nvarchar(250) null,
	CreateTS datetime2(0) not null 
		constraint DF_ToolRegistry_CreateTS default(getdate()),
	UpdateTS datetime2 (0) null,
	
	constraint PK_ToolRegistry primary key(StoreKey),
	constraint UQ_ToolRegistry unique(ToolId)

)
GO
create trigger [MC].[OnToolRegistryUpdated] 
	on [MC].[ToolRegistry] after update as
		update [MC].[ToolRegistry] set 
			UpdateTS = getdate()
	from 
		[MC].[ToolRegistry] x 
			inner join inserted on 
				inserted.StoreKey = x.StoreKey
GO



	