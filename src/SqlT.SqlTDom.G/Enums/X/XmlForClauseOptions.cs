////This file was generated 6/24/2017 12:42:26 AM
using System;
using System.Collections.Generic;

namespace SqlT.SqlTDom
{
    public enum XmlForClauseOptions : int
    {
        None = 0,
        Raw = 1,
        Auto = 2,
        Explicit = 4,
        Path = 8,
        XmlData = 16,
        XmlSchema = 32,
        Elements = 64,
        ElementsXsiNil = 128,
        ElementsAbsent = 256,
        BinaryBase64 = 512,
        Type = 1024,
        Root = 2048,
        ElementsAll = 448
    }
}