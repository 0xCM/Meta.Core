//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using static metacore;

    /// <summary>
    /// Defines SQL-specific data type facets
    /// </summary>
    public readonly struct SqlDataFacets 
    {
        const string RequiredLabel = "not null";
        const string OptionalLabel = "null";

        /// <summary>
        /// Transforms core => sql facets
        /// </summary>
        /// <param name="src">The source facets</param>
        /// <returns></returns>
        public static SqlDataFacets FromCoreFacets(CoreDataFacets src) 
            => new SqlDataFacets(src.IsValueRequired, src.MaxLength, src.NumericPrecision, src.NumericScale);

        /// <summary>
        /// Transforms sql => core facets
        /// </summary>
        /// <param name="src">The source facets</param>
        /// <returns></returns>
        public static implicit operator CoreDataFacets(SqlDataFacets src) 
            => new CoreDataFacets(src.MaxLength, src.NumericPrecision, src.NumericScale, src.IsValueRequired);

        public SqlDataFacets(bool IsValueRequired, int? MaxLength = null,
            byte? NumericPrecision = null, byte? NumericScale = null)
        {
            this.IsValueRequired = IsValueRequired;
            this.MaxLength = MaxLength;
            this.NumericPrecision = NumericPrecision;
            this.NumericScale = NumericScale;
        }

        /// <summary>
        /// Specifies whether a value is required (i.e., declaration must specify not null)
        /// </summary>
        public bool IsValueRequired { get; }

        /// <summary>
        /// Indicates the maximum length of a value, if specified/applicable
        /// </summary>
        public int? MaxLength { get; }

        /// <summary>
        /// Indicates the numeric precision of a value, if specified/applicable
        /// </summary>
        public byte? NumericPrecision { get; }

        /// <summary>
        /// Indicates the numeric scale of a value, if specified/applicable
        /// </summary>
        public byte? NumericScale { get; }

        /// <summary>
        /// Specifies whether a value is optionail (i.e., NULL 'values' are allowed)
        /// </summary>
        public bool IsValueOptional 
            => !IsValueRequired;

        /// <summary>
        /// Renders either 'null' or 'not null' as appropriate
        /// </summary>
        private string RequiredDescription 
            => IsValueRequired ? RequiredLabel : OptionalLabel;

        public override string ToString() 
            => $"({ MaxLength ?? -1 }, {NumericPrecision ?? -1}, {NumericScale ?? -1}, {RequiredDescription})";

    }
}
