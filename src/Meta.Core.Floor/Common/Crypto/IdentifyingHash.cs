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
    using System.IO;
    using System.Security.Cryptography;
    using System.Threading;

    /// <summary>
    /// Defines operations for creating hash values for the purpose of identification/duplicate detection
    /// but not for security purposes
    /// </summary>
    public static class IdentifyingHash
    {
        static ThreadLocal<MD5CryptoServiceProvider> _MD5 =
            new ThreadLocal<MD5CryptoServiceProvider>(() => new MD5CryptoServiceProvider());
        static MD5CryptoServiceProvider MD5 => _MD5.Value;


        /// <summary>
        /// Computes a hash code of the file's content with the intent of uniquely identifying it
        /// </summary>
        /// <param name="SrcFile">The file</param>
        /// <returns></returns>
        /// <remarks>
        /// This is not for security purposes (which, since MD5 is broken in that context, is a good thing)
        /// </remarks>
        public static byte[] HashFileBytes(FilePath SrcFile)
        {
            using (var s = File.OpenRead(SrcFile))
                return MD5.ComputeHash(s);
        }


        /// <summary>
        /// Computes a hash code of the file's content with the intent of uniquely identifying it
        /// </summary>
        /// <param name="path">The file</param>
        /// <returns></returns>
        /// <remarks>
        /// This is not for security purposes (which, since MD5 is broken in that context, is a good thing)
        /// </remarks>
        public static string HashFileContent(string path)
        {
            using (var s = File.OpenRead(path))
                return BitConverter.ToString(MD5.ComputeHash(s));
        }

        static char GetHexValue(int i)
        {
            if (i < 10)
                return (char)(i + 0x30);
            return (char)((i - 10) + 0x41);
        }

        /// <summary>
        /// Converts an array of bytes to a string with or without dashes
        /// </summary>
        /// <param name="data">The data to convert</param>
        /// <param name="dashes">Whether to include dashes</param>
        /// <returns></returns>
        /// <remarks>
        /// See https://social.msdn.microsoft.com/Forums/vstudio/en-US/b08386b1-f9ac-46ca-b9d3-562d61e95170/challenge-more-efficient-bitconverttostring-with-no-dashes?forum=csharpgeneral
        /// </remarks>
        public static string ToDataString(this byte[] data, bool dashes = false)
        {
            if(dashes)
            {
                return BitConverter.ToString(data);

            }
            else
            {
                int length = data.Length;
                char[] hex = new char[length * 2];
                int num1 = 0;
                for (int index = 0; index < length * 2; index += 2)
                {
                    byte num2 = data[num1++];
                    hex[index] = GetHexValue(num2 / 0x10);
                    hex[index + 1] = GetHexValue(num2 % 0x10);
                }
                return new string(hex);

            }
        }

        /// <summary>
        /// Hashes the contents of a supplied array
        /// </summary>
        /// <param name="items">The array to has</param>
        /// <returns></returns>
        public static string HashItems(this object[] items)
        {

            var sb = new StringBuilder();
            foreach (var item in items)
                sb.Append(item != null ? item.ToString() : String.Empty);

            return MD5.ComputeHash(Encoding.UTF8.GetBytes(sb.ToString())).ToDataString();

        }

    }
}
