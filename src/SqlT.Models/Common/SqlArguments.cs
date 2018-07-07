//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Linq;

    using Meta.Core;
    using SqlT.Core;
    using SqlT.Syntax;
    using static metacore;

    public interface ISqlArguments
    {
        Seq<SqlParameterValue> Values { get; }
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
            this.Values =  Seq.make(Arguments.Select
                (x => new SqlParameterValue(x.Name, CoreDataValue.Require(x.Value))));
        }

        public virtual Seq<SqlParameterValue> Values { get; }
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

        protected SqlArguments(Seq<SqlParameterValue> Values)
        {
            iter(from v in Values
                 where Members.Any(m => m.Name == v.ParameterName)
                 let m = Members.Single(x => x.Name == v.ParameterName)
                 select (m, v), 
                    mv => mv.m.SetValue(this, mv.v.AssignedValue.ToClrValue()));
          }     

        public override Seq<SqlParameterValue> Values
            => from m in Seq.make(Members)
               let mval = m.GetValue(this)
               where mval != null
               let cval = CoreDataValue.FromObject(mval)
               where cval.IsSome()
               select cval.MapRequired(_cval => new SqlParameterValue(m.Name, _cval));
    }
}
