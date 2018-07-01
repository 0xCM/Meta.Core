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
    using System.IO;

    /// <summary>
    /// Provides utilities for encrypting/decrypting text
    /// </summary>
    /// <remarks>
    /// See http://stackoverflow.com/questions/10168240/encrypting-decrypting-a-string-in-c-sharp
    /// </remarks>
    public static class StringCipher
    {
        // This constant string is used as a "salt" value for the PasswordDeriveBytes function calls.
        // This size of the IV (in bytes) must = (keysize / 8).  Default keysize is 256, so the IV must be
        // 32 bytes long.  Using a 16 character string here gives us 32 bytes when converted to a byte array.
        static readonly byte[] initVectorBytes = Encoding.ASCII.GetBytes("4wqr1ujkppeds7vs");

        // This constant is used to determine the keysize of the encryption algorithm.
        const int keysize = 256;

        /// <summary>
        /// Encrypts the supplied text
        /// </summary>
        /// <param name="plainText">The text to encrypt</param>
        /// <param name="passPhrase">The password</param>
        /// <returns></returns>
        public static string Encrypt(string plainText, string passPhrase)
        {
            using (var password = new PasswordDeriveBytes(passPhrase, null))
            {
                var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                var keyBytes = password.GetBytes(keysize / 8);
                using (var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC })
                    using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes))
                        using (var memoryStream = new MemoryStream())
                            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                byte[] cipherTextBytes = memoryStream.ToArray();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
            }
        }

        /// <summary>
        /// Decrypts the supplied text
        /// </summary>
        /// <param name="cipherText">The encrypted text</param>
        /// <param name="passPhrase">The password</param>
        /// <returns></returns>
        public static string Decrypt(string cipherText, string passPhrase)
        {
            using (var password = new PasswordDeriveBytes(passPhrase, null))
            {
                var cipherTextBytes = Convert.FromBase64String(cipherText);
                var plainTextBytes = new byte[cipherTextBytes.Length];
                var keyBytes = password.GetBytes(keysize / 8);
                using (var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC })
                    using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes))
                        using (var memoryStream = new MemoryStream(cipherTextBytes))
                            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                            }
            }
        }
    }
}
