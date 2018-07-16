//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Code
{
    public abstract class GenSpec
    {
        protected GenSpec()
        {

        }

        protected GenSpec(string TargetName)
        {
            this.TargetName = TargetName;
        }

        /// <summary>
        /// The unqualified name of the element being generated
        /// </summary>
        public string TargetName { get; set; }


    }

    public abstract class GenSpec<P> : GenSpec
        where P : GenSpec<P>, new()
    {

        protected GenSpec()
        {
            this.TargetName = string.Empty;
        }

        protected GenSpec(string TargetName)
            : base(TargetName)
        { }
        

    }


}