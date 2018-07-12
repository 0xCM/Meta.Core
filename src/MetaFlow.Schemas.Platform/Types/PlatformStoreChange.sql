create type [PF].[PlatformStoreChange] as table
(
 	StoreName nvarchar(128) not null,
	SystemKey bigint not null,
	ChangeType char(1) not null,
	ChangeTS datetime2(0) not null

)
	
