//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using Meta.Models;
    using Meta.Syntax;

    using sxc = contracts;
    using kwt = SqlKeywordTypes;
    using sx = SqlSyntax;

    partial class SqlSyntax
    {
        /// <summary>
        /// Identifies a SQL Server recovery model
        /// </summary>
        public sealed class recovery_model : cdu<IKeyword, kwt.SIMPLE, kwt.FULL, kwt.BULK_LOGGED>, sxc.dboption
        {
            public static implicit operator recovery_model(kwt.SIMPLE SIMPLE)
                => new recovery_model(SIMPLE);

            public static implicit operator recovery_model(kwt.FULL FULL)
                => new recovery_model(FULL);

            public static implicit operator recovery_model(kwt.BULK_LOGGED BULK_LOGGED)
                => new recovery_model(BULK_LOGGED);

            public recovery_model(kwt.SIMPLE SIMPLE)
                : base(SIMPLE)
            { }

            public recovery_model(kwt.FULL FULL)
                : base(FULL)
            { }

            public recovery_model(kwt.BULK_LOGGED BULK_LOGGED)
                : base(BULK_LOGGED)
            { }
        }

        public sealed class recovery_models : SyntaxList<recovery_models, recovery_model>
        {
            public static readonly recovery_model SIMPLE = sx.SIMPLE;
            public static readonly recovery_model FULL = sx.FULL;
            public static readonly recovery_model BULK_LOGGED = sx.BULK_LOGGED;
        }
    }
}