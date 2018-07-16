//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Code
{
    public abstract class PropertySpec<T> : GenSpec<T>
       where T : PropertySpec<T>, new()
    {
        protected PropertySpec(string PropertyName, string PropertyType)
            : base(PropertyName)
        {
            this.PropertyType = PropertyType;
        }

        protected PropertySpec()
        { }

        /// <summary>
        /// The name of the property's type
        /// </summary>
        public string PropertyType { get; set; }

    }

}