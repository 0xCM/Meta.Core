create type [T0].[SystemCommandRegistration] as table
(
	SystemId nvarchar(75) not null,
	MessageName nvarchar(75) not null,
	Purpose nvarchar(250) null 
)
	
