//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;
    using SqlT.Core;
    using System.Runtime.CompilerServices;

    using static metacore;

    public static class SqlChannelMessages
    {

        public static IAppMessage Truncated<T>()
            where T : class, ISqlTableProxy, new()
                => inform($"Truncated {PXM.Table<T>()}");

        public static IAppMessage Deleted<T>(long count)
            where T : class, ISqlTableProxy, new()
            => inform($"Deleted {count} records from {PXM.Table<T>()}");

        public static IAppMessage Saved<T>(long count)
            where T : class, ISqlTabularProxy, new()
            => inform($"Saved {count} records to {PXM.TabularName<T>()}");

        public static IAppMessage Loaded<T>(long count)
            where T : class, ISqlTabularProxy, new()
            => inform($"Loaded {count} records from {PXM.TabularName<T>()}");

        public static IAppMessage FunctionLoaded<F, R>(long count)
              where F : class, ISqlTableFunctionProxy<F, R>, new()
                    where R : class, ISqlTabularProxy, new()
                => inform($"Loaded {count} records from the {PXM.TableFunctionName<F, R>()} function result");

        public static IAppMessage CountedDistinct<T>(long count, SqlColumnName col)
            where T : class, ISqlTabularProxy, new()
            => inform($"Counted {count} distinct values of {col} from {PXM.TabularName<T>()}");

        public static IAppMessage Counted<T>(long count)
            where T : class, ISqlTabularProxy, new()
            => inform($"Counted {count} records in {PXM.TabularName<T>()}");
    }

}