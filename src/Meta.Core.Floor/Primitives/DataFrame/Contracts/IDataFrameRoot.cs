﻿//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using Meta.Core;

using static metacore;

public interface IDataFrameRoot : IDataFrame
{
    IDataFrame Construct(Seq<object[]> data, DataFrameSchema? schema);
}
