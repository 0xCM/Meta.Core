//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;

    public struct SqlVersion 
    {

        public static implicit operator SqlVersion(string x) 
            => new SqlVersion(x);

        public SqlVersion(Version v)
        {
            Name = $"{v.Major}.{v.Minor.ToString().PadRight(2, '0')}";
        }

        public SqlVersion(string Name)
        {
            if (!SqlVersionNames.Contains(Name))
                throw new ArgumentException($"The version {Name} is not recognized");

            this.Name = Name;
        }

        public string Name { get; }

        public override string ToString() 
            => Name;
    }

}
