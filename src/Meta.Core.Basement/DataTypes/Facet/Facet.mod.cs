//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    /// <summary>
    /// Facet manipulation module
    /// </summary>
    public class Facet 
    {
        public Facet()
        {

        }
        public static Facet<T> MinLength<T>(T value)
            => FacetInfo.Create(CommonFacetNames.MinLength, value);

        public static Facet<T> MaxLength<T>(T value)
            => FacetInfo.Create(CommonFacetNames.MaxLength, value);

        public static Facet<T> Min<T>(T value)
            => FacetInfo.Create(CommonFacetNames.Min, value);

        public static Facet<T> Max<T>(T value)
            => FacetInfo.Create(CommonFacetNames.Max, value);

        public static Facet<bool> Required(bool value)
            => FacetInfo.Create(CommonFacetNames.Required, value);

        public static Facet<T> Precision<T>(T value)
            => FacetInfo.Create(CommonFacetNames.Precision, value);

        public static Facet<T> Scale<T>(T value)
            => FacetInfo.Create(CommonFacetNames.Scale, value);

        public static Facet<string> Pattern(string value)
            => FacetInfo.Create(CommonFacetNames.Pattern, value);
    }

}