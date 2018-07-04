//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using SqlT.Core;
    
    public sealed class index_property_name : simple_name<index_property_name>
    {
        public static readonly index_property_name IndexDepth = "IndexDepth";
        public static readonly index_property_name IndexFillFactor = "IndexFillFactor";
        public static readonly index_property_name IndexID = "IndexID";
        public static readonly index_property_name IsAutoStatistics = "IsAutoStatistics";
        public static readonly index_property_name IsClustered = "IsClustered";
        public static readonly index_property_name IsDisabled = "IsDisabled";
        public static readonly index_property_name IsFullTextKey = "IsFullTextKey";
        public static readonly index_property_name IsHypothetical = "IsHypothetical";
        public static readonly index_property_name IsPadIndex = "IsPadIndex";
        public static readonly index_property_name IsPageLockDisallowed = "IsPageLockDisallowed";
        public static readonly index_property_name IsRowLockDisallowed = "IsRowLockDisallowed";
        public static readonly index_property_name IsStatistics = "IsStatistics";
        public static readonly index_property_name IsUnique = "IsUnique";
        public static readonly index_property_name IsColumnStore = "IsColumnStore";

        public static implicit operator index_property_name(string value)
            => new index_property_name(value);

        internal index_property_name(string value)
            : base(new SqlIdentifier(value, false))
        { }
    }
    
}
