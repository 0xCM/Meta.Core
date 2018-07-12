CREATE TABLE [RF].[TimeOfDayLookup]
(
	TimeKey INT NOT NULL, 
    [ClockTime] time(0) not null, 
    [Hour] tinyint not null, 
    [Minute] tinyint not null, 
    [Second] tinyint not null

	constraint PK_TimeOfDay primary key(TimeKey),
	constraint UQ_TimeOfDay_ClockTime unique(ClockTime),
	constraint QU_TimeOfDay_HourMinutSecond unique(Hour,Minute,Second)
)
