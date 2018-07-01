//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;

public class NotificationBrokerSettings : ProvidedConfiguration<NotificationBrokerSettings>
{
    public NotificationBrokerSettings(IConfigurationProvider configuration)
        : base(configuration)
    { }

    public string ConnectionString 
        => GetThisSetting(String.Empty);
}

