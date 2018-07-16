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
    using System.Text;

    using System.Reflection;

    public static class Emission
    {

        static IReadOnlyList<IGenEmitter> Emitters 
            = (from t in Assembly.GetExecutingAssembly().GetTypes()
                where !t.IsAbstract && t.GetInterfaces().Contains(typeof(IGenEmitter))                
               select Activator.CreateInstance(t) as IGenEmitter).ToList();

        public static string Emit(GenContext context, GenSpec spec)
        {
            var sb = new StringBuilder();
            var emitter = Emitters.First(e => e.CanEmit(spec.GetType()));
            foreach (var block in emitter.Emit(context, spec))
                sb.AppendLine(block);
            return sb.ToString();

        }
    }

}