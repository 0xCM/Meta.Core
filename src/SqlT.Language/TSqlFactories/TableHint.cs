//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Language
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Language;
    using static metacore;
    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;

    public static partial class TSqlFactory
    {
        public static TSql.TableHint TableHint(this TSql.TableHintKind kind)
             => new TSql.TableHint { HintKind = kind };

        public static TSql.NamedTableReference WithTableHint(this TSql.NamedTableReference src, TSql.TableHintKind kind)
        {
            src.TableHints.Add(kind.TableHint());
            return src;
        }

        public static TSql.NamedTableReference WithHoldLock(this TSql.NamedTableReference src)
            => src.WithTableHint(TSql.TableHintKind.HoldLock);

        public static TSql.NamedTableReference WithTabLock(this TSql.NamedTableReference src)
            => src.WithTableHint(TSql.TableHintKind.TabLock);

        public static TSql.NamedTableReference WithTabLockX(this TSql.NamedTableReference src)
            => src.WithTableHint(TSql.TableHintKind.TabLockX);

        public static TSql.NamedTableReference WithNoLock(this TSql.NamedTableReference src)
            => src.WithTableHint(TSql.TableHintKind.NoLock);

        public static TSql.NamedTableReference WithNoWait(this TSql.NamedTableReference src)
            => src.WithTableHint(TSql.TableHintKind.NoWait);

    }
}