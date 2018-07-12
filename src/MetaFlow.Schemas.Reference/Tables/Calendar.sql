create table [RF].[Calendar]
(
	DateKey int not null,	
	[DateName] nvarchar(10) not null,
	CalendarDate date not null,	
	[DayOfWeek] tinyint not null,	
	[DayOfMonth] tinyint not null,
	[DayOfYear] smallint not null,
	[DayName] nvarchar(15) not null,	
	[Week] tinyint not null,
	[Month] int not null,	
	[MonthName] nvarchar(15) not null,	
	[Year] int not null,
	IsWeekday bit not null,
	IsFedHoliday BIT not null, 
	IsFirstDayOfMonth bit not null,
	FirstDateOfMonth date not null,
	IsLastDayOfMonth bit not null,
	LastDateOfMonth date not null,
	IsFirstDayOfYear bit not null,
	IsLastDayOfYear bit not null,

	constraint PK_Calendar primary key(DateKey),
	constraint UQ_Calendar unique(CalendarDate)
)
GO

create index IX_Calendar_IsFirstDayOfMonth 
	on [RF].[Calendar](IsFirstDayOfMonth)
GO

create index IX_Calendar_IsLastDayOfMonth 
	on [RF].[Calendar](IsLastDayOfMonth)
GO

create index IX_Calendar_IsFirstDayOfYear
	on [RF].[Calendar](IsFirstDayOfYear)
GO

create index IX_Calendar_IsLastDayOfYear 
	on [RF].[Calendar](IsLastDayOfYear)
GO


