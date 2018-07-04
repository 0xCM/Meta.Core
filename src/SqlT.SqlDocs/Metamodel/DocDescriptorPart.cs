//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlDocs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using static metacore;

    public sealed class DocDescriptorPart : SqlDocPart<DocDescriptorPart>
    {
        public class AttributeNames : TypedItemList<AttributeNames, string>
        {
            public const string title = "title";
            public const string custom = "ms.custom";
            public const string date = "ms.date";
            public const string product = "ms.product";
            public const string technology = "ms.technology";
            public const string topic = "ms.topic";
            public const string keywords = "f1_keywords";
            public const string langs = "dev_langs";
            public const string id = "ms.assetid";
            public const string service = "ms.service";
            public const string component = "ms.component";
            public const string suite = "ms.suite";
            public const string version = "caps.latest.revision";



        }


    }



}