//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Code
{
    using System;
    using System.Linq;
    using System.IO;
    using System.Reflection;
    using System.Collections.Generic;


    static class Templates
    {
        
        static Templates()
        {
            var a = Assembly.GetExecutingAssembly();
            _All = a.GetManifestResourceNames().Select(resname =>
            {
                using (var s = a.GetManifestResourceStream(resname))
                using (var reader = new StreamReader(s))
                    return (resname, content: reader.ReadToEnd());

            }).ToDictionary(x => Path.GetFileName(x.resname), x => new Template(Path.GetFileName(x.resname), x.content));
        }

        static IReadOnlyDictionary<string,Template> _All { get; }

        public static Template Find(string name)
            => _All[name];

        public static IEnumerable<Template> All
            => _All.Values;

    }

 
}