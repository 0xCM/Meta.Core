//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;
    using System.Reflection;
    using System.Linq;
    using System.Text;
    using System.IO;

    using Meta.Models;
    using Meta.Syntax;
    using SqlT.Syntax;

    using static metacore;
   
    using sxc = Syntax.contracts;
    

    public class SqlName : ICompositeSqlName
    {

        static IModelType model_type;

        public static readonly SqlName Empty = new SqlName();

        static SqlName()
        {
            model_type = ModelTypeInfo.Get<SqlName>();
        }            

        public static SqlName operator + (SqlName n1, SqlName n2)
            => new SqlName((n1 ?? Empty).NameComponents.Union((n2 ?? Empty).NameComponents).ToArray());

        public static implicit operator SqlName(string x)
            => new SqlName(x);

        public static implicit operator string(SqlName x)
            => x?.ToString();

        protected static string[] Componetize(string s)
            => s == null
               ? new string[] { }
               : s.Split('.').Select(x => x.Replace("[", String.Empty).Replace("]", String.Empty)).ToArray();

        protected static bool ContainsQuotedComponents(string s)
            => s.Split('.')
                .Where(c => !string.IsNullOrWhiteSpace(c))
                .Any(c => c.First() == '[' && c.Last() == ']');

        /// <summary>
        /// The object equality operator
        /// </summary>
        /// <param name="lhs">The first object</param>
        /// <param name="rhs">The second object</param>
        /// <returns></returns>
        public static bool operator ==(SqlName lhs, SqlName rhs)
        {
            if (object.ReferenceEquals(lhs, rhs))
                return true;

            if (((object)lhs == null) || ((object)rhs == null))
                return false;

            var eq = lhs.Equals(rhs);
            return eq;
        }

        /// <summary>
        /// The object not equal operator
        /// </summary>
        /// <param name="lhs">The first object</param>
        /// <param name="rhs">The second object</param>
        /// <returns></returns>
        public static bool operator !=(SqlName lhs, SqlName rhs)
            => !(lhs == rhs);

        static int calcHash(IEnumerable<string> components)
            => string.Join(".", components).GetHashCode();

        protected void ReplaceState(IEnumerable<string> components, bool quoted)
        {
            NameComponents = components.ToList();
            Quoted = quoted;
            hash = calcHash(components);
        }

        public SqlName()
        {
            NameComponents = new string[] { };
        }

        public SqlName(bool quoted, params string[] components)
            : this(components)
        {
            this.Quoted = quoted;
        }

        int? hash;

        public IReadOnlyList<string> NameComponents { get; set; }

        protected bool Quoted { get; private set; }

        public SqlName(SqlIdentifier LocalName)
        {
            this.NameComponents = rolist(LocalName.IdentifierText);
            this.Quoted = LocalName.Quoted;
            this.hash = calcHash(NameComponents);
        }
        public SqlName(SqlIdentifier SchemaName, SqlIdentifier LocalName)
        {
            this.NameComponents = rolist(SchemaName.IdentifierText, LocalName.IdentifierText);
            this.Quoted = LocalName.Quoted;
            this.hash = calcHash(NameComponents);
        }


        public SqlName(params string[] components)
        {
            if (components != null)
            {
                foreach (var component in components)
                {
                    if (String.IsNullOrEmpty(component))
                        continue;

                    if (IsQuoted(component))
                        throw new ArgumentException($"The name {component} should not be quoted");
                }
                this.NameComponents = components.ToList();
            }
            else
                this.NameComponents = new List<string>();

            hash = calcHash(components);
        }

        public SqlName(IEnumerable<string> components)
            : this(components.ToArray())
        { }

      
        public SqlName(IName name, bool quoted = false)
        {
            if (!name.IsEmpty)
            {

                if (name is ICompositeSqlName)
                    this.NameComponents = (name as ICompositeSqlName).NameComponents;
                else
                    this.NameComponents = new string[] { (name as ISimpleSqlName).Identifier.IdentifierText };
                this.Quoted = quoted;
            }
            else
                this.NameComponents = new string[] { };
        }


        public virtual string FullName
            => CreateFullName();

        string SmashComponents()
            => string.Join("-", NameComponents);

        protected bool IsComparable(object other)
        {
            if (other == null)
                return false;

            var right = other as SqlName;
            if (((object)right) == null)
                return false;

            return true;
        }

        public override bool Equals(object other)
        {
            if (!IsComparable(other))
                return false;

            var right = other as SqlName;
            var left = this;

            var l = left.NameComponents;
            var r = right.NameComponents;
            if (l.Count != r.Count)
                return false;

            var len = l.Count;
            for (int i = 0; i < len; i++)
            {
                if (string.Compare(l[i], r[i], true) != 0)
                    return false;
            }
            return true;
        }

        public override int GetHashCode()
            => hash.GetValueOrDefault(string.Join(",", NameComponents).GetHashCode());

        static bool IsQuoted(string component)
            => component.StartsWith("[") && component.EndsWith("]");
        
        protected virtual string CreateFullName(bool quote = true)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < NameComponents.Count; i++)
                if (!string.IsNullOrEmpty(NameComponents[i]))
                {
                    var component = NameComponents[i];
                    if (quote)
                    {
                        if (IsQuoted(component))
                            sb.Append(component);
                        else
                            sb.AppendFormat("[{0}]", component);
                    }
                    else
                        sb.Append(component);

                    if (i != NameComponents.Count - 1)
                        sb.Append(".");
                }

            return sb.ToString();
        }

        protected string GetComponent(int idx)
            => NameComponents[idx];

        public override string ToString()
            => FullName;

        public string UnqualifiedName
            => NameComponents.Count != 0 
            ? NameComponents.Last() 
            : String.Empty;

        public simple_element_name UnquotedLocalName
            => NameComponents.Count != 0 
            ? simple_element_name.specify(NameComponents.Last(), false) 
            : simple_element_name.Empty;


        public string text
            => (this as ICompositeSqlName).Format(Quoted);

        public SqlIdentifier AsIdentifier()
            => NameComponents.Count == 0
                ? SqlIdentifier.empty
                : new SqlIdentifier(NameComponents.First(), Quoted);

        public bool quoted
            => Quoted;

        public bool IsEmpty
            => this == Empty;

        public IModelType ModelType
            => model_type;


        public SqlIdentifier Identifier
            => UnquotedLocalName.Identifier;

        static ConcurrentDictionary<Type, Func<string, SqlName>> NameParsers
            = new ConcurrentDictionary<Type, Func<string, SqlName>>();

        static Func<string, SqlName> GetParser(Type NameType)
        {
            return NameParsers.GetOrAdd(NameType, t =>
            {
                var parser = t.GetMethod("Parse",
                    BindingFlags.Static | BindingFlags.Public | BindingFlags.DeclaredOnly);

                if (parser == null)
                    throw new Exception($"Could not find Parse method for the {t} type");

                return s => (SqlName)parser.Invoke(null, new object[] { s });
            });

        }

    }

    static class GetNameElementType<N>
        where N : SqlName<N>, new()
    {
        public static string Invoke()
        {
            var attrib = typeof(N).GetCustomAttribute<SqlElementTypeAttribute>();
            if (attrib != null)
            {
                return attrib.ModelTypeId;
            }
            else
                return string.Empty;
        }
    }

    public abstract class SqlName<N> : SqlName
        where N : SqlName<N>, new()
    {
        static readonly string IdentifiedElementType;

        static SqlName()
        {
            IdentifiedElementType = GetNameElementType<N>.Invoke();
        }

        public static new N Empty = new N();

        public static N Construct(bool quote, params string[] components)
        {
            var name = new N();
            name.ReplaceState(components, quote);
            return name;

        }

        public static N Construct(params string[] components)
        {
            var name = new N();
            name.ReplaceState(components, false);
            return name;

        }

        public static N Parse(string s)
            => Construct(ContainsQuotedComponents(s), Componetize(s));            

        protected SqlName(bool quoted, params string[] components)
            : base(quoted, components)
        {

        }

        protected SqlName(SqlIdentifier LocalName)
            : base(LocalName)
        { }

        protected SqlName(params string[] components)
            : base(components)
        {

        }

        public SqlName(SqlIdentifier SchemaName, SqlIdentifier LocalName)
            : base(SchemaName, LocalName)
        { }


        protected SqlName(IName SqlName, bool quoted = false)
            : base(SqlName, quoted)
        { }

        protected SqlName(ICompositeSqlName SqlName, bool quoted = false)
            : base(SqlName,quoted)
        { }


        protected virtual string UriComponentName { get; } 
            = string.Empty;
    }
}