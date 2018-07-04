//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{

    /// <summary>
    /// Defines a context link from one <see cref="ISqlContext"/> to another
    /// </summary>
    public interface ILinkedSqlContext 
    {
        /// <summary>
        /// The context from which data is acquired
        /// </summary>
        ISqlContext SourceContext { get; }

        /// <summary>
        /// The context to which data is (potentially) written
        /// </summary>
        ISqlContext TargetContext { get; }
    }

}