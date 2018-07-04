//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using Meta.Syntax;
    using SqlT.Core;
    using SqlT.Syntax;

    using static metacore;

    public interface ISqlVariableInitializer : ISyntaxExpression
    {
        typeref DataType { get; }

        ISyntaxExpression Value { get; }
    }

    public interface ISqlVariableInitializer<V> :  ISqlVariableInitializer
        where V : ISyntaxExpression
    {
        

        new V Value { get; }

    }

    public abstract class SqlVariableInitializer<E,V> : SyntaxExpression<E>, ISqlVariableInitializer<V>
        where E : SqlVariableInitializer<E, V> 
        where V: ISyntaxExpression
    {
        protected  SqlVariableInitializer(typeref DataType, V Value)
        {
            this.DataType = DataType;
            this.Value = Value;
        }


         public typeref DataType { get; }

         public V Value { get; }

        ISyntaxExpression ISqlVariableInitializer.Value
            => Value;

        public override  string ToString()
            => Value.FormatSyntax();

    }

    public class SqlVariableInitializer<V> :SqlVariableInitializer<SqlVariableInitializer<V>, V>
        where V : ISyntaxExpression
    {
        public SqlVariableInitializer(typeref DataType, V Value)
            : base(DataType, Value)
        {

        }       

    }

    public sealed class SqlVariableInitializer : SqlVariableInitializer<ISyntaxExpression>        
    {
        public SqlVariableInitializer(typeref DataType, ISyntaxExpression Value)
            : base(DataType, Value)
        {

        }

        public SqlVariableInitializer(typeref DataType, CoreDataValue Value)
            : base(DataType, Value.ToSqlLiteral())
        {

        }
    }
}