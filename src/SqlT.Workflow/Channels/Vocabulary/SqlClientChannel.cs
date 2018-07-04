﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    

    using N = SystemNode;
    using static metacore;
    using static SqlT.Core.SqlChannelMessages;

    public class SqlClientClannel : SqlChannel<ISqlClientBroker>, ISqlClientChannel
    {
        public SqlClientClannel(ILinkedContext C, ISqlClientBroker SourceBroker, ISqlClientBroker TargetBroker)
            : base(C, SourceBroker,TargetBroker)
        {
        
        }

    }


}