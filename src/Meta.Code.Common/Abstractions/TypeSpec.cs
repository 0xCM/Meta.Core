//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Code
{

    /// <summary>
    /// Concrete subtypes characterize type generation processes
    /// </summary>
    /// <typeparam name="T">The derived subtype</typeparam>
    public abstract class TypeSpec<T> : GenSpec<T>
        where T : TypeSpec<T>, new()
    {
        protected TypeSpec(string TypeName)
            : base(TypeName)
        {

        }

        protected TypeSpec()
        {

        }


    }

}