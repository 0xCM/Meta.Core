//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;    
    using System.Linq;

    using static metacore;

    /// <summary>
    /// Describes an enumeration
    /// </summary>
    public class ClrEnumInfo
    {
        public static ClrEnumInfo FromType<T>()
            => FromType(typeof(T));

        public static ClrEnumInfo FromType(ClrEnum e)
            => new ClrEnumInfo(e.Name, e.GetLiteralType().Name, 
                    from l in e.Literals
                    select new ClrEnumLiteralInfo(l.LiteralName, l.LiteralValue)
                    );
                    

        public ClrEnumInfo()
        {

        }

        public ClrEnumInfo(ClrEnumName Name, ClrStructName BaseType, params ClrEnumLiteralInfo[] Literals)
        {
            this.Name = Name;
            this.BaseType = BaseType;
            this.Literals = Literals.ToReadOnlyList();
        }
        
        /// <summary>
        /// The name of the enum
        /// </summary>
        public ClrEnumName Name { get; set; }

        /// <summary>
        /// The underlying system type
        /// </summary>
        public ClrStructName BaseType { get; set; }

        /// <summary>
        /// The literals defined by the enum
        /// </summary>
        public ReadOnlyList<ClrEnumLiteralInfo> Literals { get; set; }

        public override string ToString()
            => $"enum {Name} : {BaseType} " 
                +  embrace(string.Join(",", Literals));
    }
}