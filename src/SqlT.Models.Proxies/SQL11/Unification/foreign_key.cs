﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem.SQL11.sys
{
    using System;

    public partial class foreign_keys : IForeignKey
    {
        bool ISystemObject.is_user_defined
            => true;

    }
}