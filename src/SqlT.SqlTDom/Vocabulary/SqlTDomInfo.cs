//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dom
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;
    using System.Collections.Concurrent;
    using System.Text;

    using static ClrStructureSpec;

    using SqlT.Core;
    using SqlT.Models;

    using static metacore;

    /// <summary>
    /// Describes the Microsoft-defined TSQl DOM using the CLR model vocabulary
    /// </summary>
    /// <remarks>
    /// TODO: Define structural projections that carry this model onto a record type/DTO
    /// </remarks>
    public class SqlTDomInfo
    {

        internal static readonly IReadOnlySet<string> IgnoredModelProperties
            = roset(
                "StartOffset",
                "FragmentLength",
                "StartLine",
                "StartColumn",
                "FirstTokenIndex",
                "LastTokenIndex",
                "ScriptTokenStream"
                );

        public SqlTDomInfo
        (            
            SqlDomTypeDescriptors SourceTypes,
            ReadOnlyList<ClrClass> Classes,
            ReadOnlyList<ClrTypeLineage> StatementLineage,
            ReadOnlyList<ClrTypeLineage> LiteralLineage,
            ReadOnlyList<ClrEnum> Enums
        )
        {

            this.SourceTypes = SourceTypes;
            this.Classes = Classes;
            this.StatementLineage = StatementLineage;
            this.LiteralLineage = LiteralLineage;
            this.Enums = Enums;
            
        }


        public SqlDomTypeDescriptors SourceTypes { get; }

        public ReadOnlyList<ClrTypeLineage> StatementLineage { get; }

        public ReadOnlyList<ClrTypeLineage> LiteralLineage { get; }

        public ReadOnlyList<ClrEnum> Enums { get; }

        public ReadOnlyList<ClrClass> Classes { get; }

        public SqlDomTypeDescriptor DescribeEnclosedType(ClrType t)
            => SourceTypes.FindByDescribedType(t);

        public IEnumerable<ClrClass> ConcreteTypes
            => from c in Classes where c.IsAbstract == false select c;

        public IEnumerable<ClrClass> AbstractTypes
            => from c in Classes where c.IsAbstract == true select c;

        public IEnumerable<ClrClass> StatementLeafs
            => StatementLineage.Select(x => x.First() as ClrClass);




    }
}