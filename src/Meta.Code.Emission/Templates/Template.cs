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


    class Template
    {
        public Template(string Name, string Content)
        {
            this.Name = Name;
            this.Content = Content;
        }

        public string Name { get; }

        public string Content { get; }

        public string Expand(params TemplateParameter[] parameters)
        {
            var expansion = Content;
            foreach(var param in parameters)
                expansion = expansion.Replace(param.Marker, param.ParamValue);
            return expansion;
        }                
    }
}