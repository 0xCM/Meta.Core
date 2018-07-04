//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using sxc = SqlT.Syntax.contracts;

    using SqlT.Syntax;

    
    public sealed class SqlPackageName : SqlName<SqlPackageName>
    {

        public static readonly FileExtension DefaultExtension = FileExtension.Parse("dacpac");

        public static implicit operator FileName(SqlPackageName x)
            => FileName.Parse(x.UnqualifiedName);

        public static readonly string UriPartIdentifier = "package";

        public new static SqlPackageName Parse(string s)
            => new SqlPackageName(Componetize(s));

        public static implicit operator SqlPackageName(string LocalName)
            => new SqlPackageName(LocalName);

        protected override string UriComponentName
            => UriPartIdentifier;

        public SqlPackageName(params string[] components)
            : base(components)
        {

        }

        public SqlPackageName()
            : this(string.Empty)
        { }


        public override string FullName
            => CreateFullName(false);

    }


}