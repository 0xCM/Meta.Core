create table [MC].[BuildCopyTask]
(
 	StoreKey int not null
		constraint DF_BuildCopyTask_StoreKey 
			default(next value for [SqlStore].[StoreKeySequence]),

	CreateTS datetime2(0) not null
		constraint DF_BuildCopyTask_CreateTS default(getdate()),	
	UpdateTS datetime2(0) null,

)
	
