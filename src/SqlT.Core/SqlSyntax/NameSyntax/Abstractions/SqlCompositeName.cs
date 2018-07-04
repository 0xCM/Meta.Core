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

    using SqlT.Syntax;

    using static metacore;

    using sxc = Syntax.contracts;

    public class SqlCompositeName : IEquatable<SqlCompositeName>
    {
        static IModelType model_type;

        public static readonly SqlCompositeName Empty = new SqlCompositeName();

        static SqlCompositeName()
        {
            model_type = ModelTypeInfo.Get<SqlName>();
        }


        public static bool operator ==(SqlCompositeName lhs, SqlCompositeName rhs)
            => isNull(lhs) ? false : lhs.Equals(rhs);

        public static bool operator !=(SqlCompositeName lhs, SqlCompositeName rhs)
            => not(lhs == rhs);


        public SqlCompositeName(params SqlIdentifier[] Components)
        {
            this.Components = Components;
        }

        public IReadOnlyList<SqlIdentifier> Components { get; set; }

        public bool Equals(SqlCompositeName other)
        {
            if (other == null)
                return false;

            if (other.Components.Count != Components.Count)
                return false;


            for (int i = 0; i < Components.Count; i++)
            {
                if (Components[i] != other.Components[i])
                    return false;
            }

            return true;
        }

        public override string ToString()
            => join(".", Components);

        public override bool Equals(object obj)
            => Equals(obj as SqlCompositeName);

        public override int GetHashCode()
            => Components.GetHashCodeAggregate();


    }



}