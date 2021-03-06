﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;

    
    public interface ISqlElementTypeLookup
    {
        Option<SqlElementType> TryFind(Type ModelType);

        SqlElementType Find(string Identifier);
    }

}