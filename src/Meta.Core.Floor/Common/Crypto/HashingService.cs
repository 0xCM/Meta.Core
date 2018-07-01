//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Security.Cryptography;
    using System.Collections.Concurrent;

    /// <summary>
    /// Provides a realization of <see cref="IEncrypter"/> that implements a one-way cryptographic hash
    /// </summary>
    [Service(typeof(IEncrypter), "AccountHash")]
    class HashingService : Service<IEncrypter>, IEncrypter
    {
        static readonly ConcurrentDictionary<string, HashAlgorithm> algorithms 
            = new ConcurrentDictionary<string, HashAlgorithm>();

        static HashAlgorithm CreateAlgorithm(string name)
        {
            var algorithm = default(HashAlgorithm);
            switch (name)
            {
                case HashAlgorithmNames.MD5: algorithm = MD5.Create(); break;
                //case HashAlgorithmNames.RIPEMD160: algorithm = new RIPEMD160Managed(); break;
                case HashAlgorithmNames.SHA1: algorithm = new SHA1Managed(); break;
                case HashAlgorithmNames.SHA256: algorithm = new SHA256Managed(); break;
                case HashAlgorithmNames.SHA384: algorithm = new SHA384Managed(); break;
                case HashAlgorithmNames.SHA512: algorithm = new SHA512Managed(); break;
                default:
                    throw new NotImplementedException();
            }
            return algorithm;
        }

        static HashAlgorithm GetAlgorithm(string algorithmName) 
            => algorithms.GetOrAdd(algorithmName, CreateAlgorithm);

        public HashingService(IApplicationContext context)
            : base(context)
        {

        }

        static string Hash(string alorithmName, string text)
        {
            var algorithm = GetAlgorithm(alorithmName);
            var input = text.Trim();
            if (input == String.Empty)
                return String.Empty;
            var data = algorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
            var hashText = BitConverter.ToString(data).Replace("-", String.Empty);
            var pos = input.Length - 4;
            var discriminator = pos >= 0 ? input.Substring(pos) : input;
            return $"{hashText}:{discriminator}";
        }

        public string ComputeHash(string algorithm, string text) 
            => Hash(algorithm, text);

        public static string ComputeSHA256Hash(string text) 
            => Hash(HashAlgorithmNames.SHA256, text);

        object IEncrypter.Apply(string transformationName, object value) 
            => ComputeHash(transformationName, (string)value);

        bool IEncrypter.IsInvertible(string transformationName) 
            => false;
    }
}
