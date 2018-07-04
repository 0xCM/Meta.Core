//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using SqlT.Syntax;
    using static metacore;

    public interface ISqlArguments
    {
        IEnumerable<SqlParameterValue> Values { get; }
    }

    public interface ISqlArguments<T> : ISqlArguments
    {

    }


    /// <summary>
    /// Defines a sequence of <see cref="SqlParameterValue"/> instances that
    /// are interpreted as an argument set
    /// </summary>
    public class SqlArguments : ISqlArguments
    {
        public static readonly SqlArguments Empty = new SqlArguments();

        public SqlArguments(params SqlParameterValue[] Values)
        {
            this.Values = Values;
        }

        public SqlArguments(CommandArguments Arguments)
        {
            this.Values = Arguments.Select(x => new SqlParameterValue(x.Name, CoreDataValue.Require(x.Value)));
        }

        public virtual IEnumerable<SqlParameterValue> Values { get; }
    }


    /// <summary>
    /// Base type for strongly-typed argument sets
    /// </summary>
    /// <typeparam name="T">The derived subtype</typeparam>
    public abstract class SqlArguments<T> : SqlArguments, ISqlArguments<T>
        where T : SqlArguments<T>
    {
        static ReadOnlyList<ValueMember> Members = typeof(T).GetValueMembers();

        protected SqlArguments()
        {

        }

        protected SqlArguments(IEnumerable<SqlParameterValue> Values)
        {
            iter(from v in Values
                 where Members.Any(m => m.Name == v.ParameterName)
                 let m = Members.Single(x => x.Name == v.ParameterName)
                 select (m, v), 
                    mv => mv.m.SetValue(this, mv.v.AssignedValue.ToClrValue()));
          }     

        public override IEnumerable<SqlParameterValue> Values
            => from m in Members
               let mval = m.GetValue(this)
               where mval != null
               let cval = CoreDataValue.FromObject(mval)
               where cval.IsSome()
               select new SqlParameterValue(m.Name, ~cval);
    }
}
