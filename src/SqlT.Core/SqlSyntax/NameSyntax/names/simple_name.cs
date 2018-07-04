//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Meta.Models;
    using SqlT.Core;

    using static metacore;
    using sxc = contracts;

    public struct SimpleSqlName : ISimpleSqlName
    {

        static IModelType model_type = ModelTypeInfo.Get<SqlIdentifier>();

        public static readonly SimpleSqlName Empty = new SimpleSqlName(String.Empty);

        public static implicit operator SimpleSqlName(string text)
            => new SimpleSqlName(text);

        public static implicit operator string(SimpleSqlName x)
            => x.text;

        public SimpleSqlName(string text)
        {
            this.text = text;
        }

        public string text { get; }

        public bool quoted
            => false;

        public SqlIdentifier Identifier
            => new SqlIdentifier(text, quoted);

        public bool IsEmpty
            => string.IsNullOrWhiteSpace(text);

        IModelType IModel.ModelType
            => model_type;

        public override string ToString()
            => text;
    }

    public abstract class simple_name<n> : Model<n>, ISimpleSqlName 
        where n : simple_name<n>
    {

        public static implicit operator string(simple_name<n> x)
            => x.ToString();

        public simple_name(SqlIdentifier identifier)
        {
            this.Identifier = identifier;
        }

        public simple_name(string text, bool quoted)
        {
            this.Identifier = new SqlIdentifier(text,quoted);
        }

        public SqlIdentifier Identifier { get; }

        public string text
            => Identifier.IdentifierText;

        public bool quoted
            => Identifier.Quoted;

        public override bool IsEmpty
            => isBlank(text);

        public override string ToString()
            => Identifier.ToString();

        public override bool Equals(object obj)
            => Identifier.Equals(obj);

        public override int GetHashCode()
            => Identifier.GetHashCode();
    }
}
