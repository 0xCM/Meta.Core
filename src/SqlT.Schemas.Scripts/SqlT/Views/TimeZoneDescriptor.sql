create view [SqlT].[TimeZoneDescriptor] as
select 
	Identifier = 
		replace(replace(replace(replace(replace(replace(replace(replace(replace
			([name], ' ', '_'), '(', ''), ')', ''),'-', '_minus_'), 'W.', 'West'), 'E.', 'East'),'+', '_plus_'),'N.', 'North'),'S.', 'South'),
	Label = [name],
	UtcOffset = convert(decimal(4,2), replace(replace(current_utc_offset, '-', ''), ':', '.')),
	OffsetDirection = case when replace(current_utc_offset, '-', '') = current_utc_offset then 1 else -1 end,
	ObservervesDST= is_currently_dst
from 
	sys.time_zone_info

 