create type [T0].[SqlMessageSpec] as table
(
	MessageNumber int not null, 
	SystemId nvarchar(75) not null,
	MessageName nvarchar(75) not null,
	Severity int not null,
	FormatString nvarchar(255) not null	
)
	
