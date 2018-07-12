create type [T0].[SystemEventRegistration] as table
(
	SystemId nvarchar(75) not null,
	MessageName nvarchar(128) not null,
	Purpose nvarchar(250) null 

)

