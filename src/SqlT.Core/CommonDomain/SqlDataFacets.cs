//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using static metacore;

    public class SqlDataFacets : ValueObject<SqlDataFacets>
    {
        private const string RequiredLabel = "not null";
        private const string OptionalLabel = "null";

        public static SqlDataFacets FromCoreFacets(CoreDataFacets src) 
            => new SqlDataFacets(src.IsValueRequired, src.MaxLength, src.NumericPrecision, src.NumericScale);

        public static implicit operator CoreDataFacets(SqlDataFacets src) 
            => new CoreDataFacets(src.MaxLength, src.NumericPrecision, src.NumericScale, src.IsValueRequired);

        public readonly bool IsValueRequired;
        public readonly int? MaxLength;
        public readonly byte? NumericPrecision;
        public readonly byte? NumericScale;

        public SqlDataFacets
        (
            bool IsValueRequired,
            int? MaxLength = null,
            byte? NumericPrecision = null,
            byte? NumericScale = null
        )
        {
            this.IsValueRequired = IsValueRequired;
            this.MaxLength = MaxLength;
            this.NumericPrecision = NumericPrecision;
            this.NumericScale = NumericScale;
        }

        public bool IsValueOptional 
            => !IsValueRequired;

        private string RequiredDescription 
            => IsValueRequired ? RequiredLabel : OptionalLabel;

        public override string ToString() 
            => $"({ MaxLength ?? -1 }, {NumericPrecision ?? -1}, {NumericScale ?? -1}, {RequiredDescription})";

        public bool AnySpecified 
            => MaxLength != null || NumericScale != null || NumericPrecision != null;

    }
}
