create table [Factory].[MergeColumn]
(
  	FactoryKey bigint not null
		constraint DF_MergeColumn_FactoryKey 
			default(next value for [Factory].[FactorySequence]),
	
	MergeProc nvarchar(75) not null,
	ColumnPosition int not null,
	SourceColumn nvarchar(128) not null,
	TargetColumn nvarchar(128) not null,
	IsMatchColumn bit not null,

	CreateTS datetime2(0) not null
	constraint DF_MergeColumn_CreateTS default(getdate()),

	constraint PK_MergeColumn primary key(FactoryKey),
	constraint UQ_MergeColumn unique(MergeProc,ColumnPosition),

	constraint FK_MergeColumn_MergeProc foreign key(MergeProc)
		references [Factory].[MergeProc](Identifier)
			on delete cascade
			on update cascade






)