//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    /// <summary>
    /// The names of the supported hash algorithms
    /// </summary>
    public static class HashAlgorithmNames
    {
        /// <summary>
        /// Identifies the MD5 algorithm
        /// </summary>
        public const string MD5 = nameof(System.Security.Cryptography.MD5);        

        /// <summary>
        /// Identifies the SHA1 algorithm
        /// </summary>
        public const string SHA1 = nameof(System.Security.Cryptography.SHA1);

        /// <summary>
        /// Identifies the SHA256 algorithm
        /// </summary>
        public const string SHA256 = nameof(System.Security.Cryptography.SHA256);

        /// <summary>
        /// Identifies the SHA384 algorithm
        /// </summary>
        public const string SHA384 = nameof(System.Security.Cryptography.SHA384);

        /// <summary>
        /// Identifies the SHA512 algorithm
        /// </summary>
        public const string SHA512 = nameof(System.Security.Cryptography.SHA512);
    }
}