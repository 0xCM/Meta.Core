// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Reflection;
    using System.Linq;

    /// <summary>
    /// Describes a field in a record
    /// </summary>
    public readonly struct RecordField
    {        
        public RecordField(ClrProperty Member, int Index)
        {
            this.Member = Member;
            this.Position = Index;
        }

        /// <summary>
        /// The member that reifies the attribute
        /// </summary>
        public ClrProperty Member { get; }

        /// <summary>
        /// The 1-based declaration order position of the attribute
        /// </summary>
        public int Position { get; }
        /// <summary>
        /// The type of the declaring record
        /// </summary>
        public ClrType RecordType
            => Member.DeclaringType;

        /// <summary>
        /// The type of an associated value
        /// </summary>
        public ClrType ValueType
            => Member.PropertyType;

        /// <summary>
        /// The name of the attribute
        /// </summary>
        public string Name
            => Member.Name;

        public override string ToString()
            => $"({Position},{Name})";

    }
}