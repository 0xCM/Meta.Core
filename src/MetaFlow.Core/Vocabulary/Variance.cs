//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// 
// License:MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{
    public enum Variance : byte
    {
        /// <summary>
        /// Indicates that no variance has been specified
        /// </summary>
        None = 0,

        /// <summary>
        /// Indicates that the subject is an emitter, i.e., a source
        /// </summary>
        Covariant = 1,

        /// <summary>
        /// Indicates that the subject is a receiver, i.e., a sink
        /// </summary>
        Contravariant = 2,

        /// <summary>
        /// Indicates that the  subject is both a receiver and an emitter, 
        /// e.g., transformer, relay, etc.
        /// </summary>
        Bivariant = 3

    }

    public static class NodeVarianceX
    {
        public static bool IsSource(this Variance v)
            => v == Variance.Covariant;

        public static bool IsTarget(this Variance v)
            => v == Variance.Contravariant;


    }
}