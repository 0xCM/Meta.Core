//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Linq;
    using SqlT.Core;
    using Meta.Core;
    using SqlT.Models;

    public interface ISqlDacRepository
    {
        NodeFolderPath Location { get; }

        Seq<SqlPackageDescription> Packages { get; }
    }



}