//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Code
{
    using System;
    using System.Linq;
    using System.Collections.Generic;


    class TemplateParameter
    {
        public const string LeftDelimiter = "ᐸ";
        public const string RightDelimiter = "ᐳ";

        public TemplateParameter(string Name, string Value)
        {
            this.ParamName = Name;
            this.ParamValue = Value;
        }

        /// <summary>
        /// Specifies the unadorned name of the paramter
        /// </summary>
        public string ParamName { get; }

        /// <summary>
        /// Specifies the parameter replacement value
        /// </summary>
        public string ParamValue { get; }

        public string Marker
            => $"{LeftDelimiter}{ParamName}{RightDelimiter}";

        public override string ToString()
            => $"{Marker} = {ParamValue}";
    }


}