create table [PF].[TypedDataFlowRegistry] 
(
	SystemKey bigint not null 
		constraint DF_TypedDataFlow_SystemKey 
			default(next value for [PF].[SystemKeySequence]),
	SourceAssembly nvarchar(75) not null,
	TargetAssembly nvarchar(75) not null,
	DataFlowName nvarchar(75) not null,
	WorkflowTypeUri nvarchar(250) not null,
	ArgumentTypeUri nvarchar(250) null,
	CreateTS datetime2(0) not null 
		constraint DF_DataFlow_CreateTS default(getdate()),
	UpdateTS datetime2(0) null,
	
	constraint PK_TypedDataFlow primary key(SystemKey),
	constraint UQ_TypedDataFlow unique(SourceAssembly, TargetAssembly, DataFlowName),
)
GO
create trigger [PF].[OnTypedDataFlowRegistryUpdated] 
	on [PF].[TypedDataFlowRegistry] after update as
		update [PF].[TypedDataFlowRegistry] set 
			UpdateTS = getdate()
	from 
		[PF].[TypedDataFlowRegistry] x 
			inner join inserted on 
				inserted.SystemKey = x.SystemKey


