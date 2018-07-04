//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System.Collections.Generic;

    using Meta.Models;
    using Meta.Syntax;
    using SqlT.Syntax;
    using SqlT.Core;

    using sxc = SqlT.Syntax.contracts;

    /// <summary>
    /// Topmost interface for SQL Element moodel items which are, roughly, those things that
    /// can be given a name
    /// </summary>
    public interface ISqlElement : sxc.element
    {

        /// <summary>
        /// Element summary documntation
        /// </summary>
        Option<SqlElementDescription> Documentation { get; }

        /// <summary>
        /// Extended properties defined for the element
        /// </summary>
        IReadOnlyList<SqlPropertyAttachment> Properties { get; }

        /// <summary>
        /// Specifies whether the element is a schema-scoped object and, consequently, is recorded in sys.objects
        /// </summary>
        bool IsSchemaObject { get; }
    }

    public interface ISqlElement<N> : ISqlElement, sxc.element<N>
        where N : IName, new()
    {
        /// <summary>
        /// Specifies the name of the element
        /// </summary>
        new N Name { get; }
    }





}
