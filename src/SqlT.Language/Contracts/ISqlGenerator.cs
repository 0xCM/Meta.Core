﻿//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;

    using Meta.Models;

    using SqlT.Core;
    using SqlT.Models;

    /// <summary>
    /// Defines contract for SQL generator
    /// </summary>
    public interface ISqlGenerator
    {
        SqlModelScript GenerateScript(IModel syntax);

    }
}