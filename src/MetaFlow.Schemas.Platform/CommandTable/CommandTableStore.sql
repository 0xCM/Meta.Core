create table [WF].[CommandTable]
(
	CommandTableId int not null
		constraint DF_CommandTable_SpecifierKey 
			default(next value for [WF].[CommandTableSequence]),
	CommandName nvarchar(75) not null,
	TargetNodeId nvarchar(75) not null,
	TargetSystem nvarchar(75) not null,
	CorrelationToken nvarchar(250) null,
	Arg1Name nvarchar(75) null,
	Arg1Value nvarchar(250) null,
	Arg2Name nvarchar(75) null,
	Arg2Value nvarchar(250) null,
	Arg3Name nvarchar(75) null,
	Arg3Value nvarchar(250) null,
	Arg4Name nvarchar(75) null,
	Arg4Value nvarchar(250) null,
	Arg5Name nvarchar(75) null,
	Arg5Value nvarchar(250) null,
	Arg6Name nvarchar(75) null,
	Arg6Value nvarchar(250) null,
	CreateTS datetime2(0) not null 
		constraint DF_CommandTable_CreateTS default(getdate()),

)
GO
exec sp_addextendedproperty @name = N'SqlT_DataContract',
    @value = N'[WF].[CommandTableEntry]',
    @level0type = N'SCHEMA',
    @level0name = N'WF',
    @level1type = N'Table',
    @level1name = N'CommandTable',
    @level2type = NULL,
    @level2name = NULL
GO



create sequence [WF].[CommandTableSequence] 
	as int start with 1 cache 10
GO
