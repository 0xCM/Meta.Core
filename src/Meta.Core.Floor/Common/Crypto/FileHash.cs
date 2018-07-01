//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    public readonly struct FileHash
    {
        public static implicit operator string(FileHash x)
            => x.ToString();

        public static FileHash Create(FilePath Path)
            => new FileHash(Path, IdentifyingHash.HashFileBytes(Path));

        FileHash(FilePath Path, byte[] Hash)
        {
            this.Path = Path;
            this.Hash = Hash;
        }

        /// <summary>
        /// The path to the hashed file
        /// </summary>
        public FilePath Path { get; }

        /// <summary>
        /// The hashed value
        /// </summary>
        public byte[] Hash { get; }

        public override string ToString()
            => BitConverter.ToString(Hash).Replace("-", string.Empty);
    }
}