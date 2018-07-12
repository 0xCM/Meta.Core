create type [PF].[CommandRegistration] as table
(
	SystemId nvarchar(75) not null,
	CommandName nvarchar(75) not null,
	Purpose nvarchar(250) null 
)
	
