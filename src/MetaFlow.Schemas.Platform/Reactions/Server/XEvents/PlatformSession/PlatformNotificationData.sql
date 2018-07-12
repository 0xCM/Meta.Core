create view [PF].[PlatformNotificationData] as
    select 
        event_data = CAST(event_data AS XML) 
    from 
        sys.fn_xe_file_target_read_file('PlatformNotifications*.xel', NULL, NULL, NULL) 
