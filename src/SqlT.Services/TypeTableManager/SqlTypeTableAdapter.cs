//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SqlT.Core;
    using SqlT.Services;
    using SqlT.Models;
    using SqlT.Types;

    using static metacore;


    public abstract class SqlTypeTableAdapter : ISqlTableProxy
    {
        public static SqlTypeTableAdapter Adapt(ISqlTableProxy Subject)
        {
            switch (Subject)
            {
                case ITinyTypeTable x:
                    return new SqlTinyTypeTableAdapter(Subject);
                case ISmallTypeTable x:
                    return new SqlSmallTypeTableAdapter(Subject);
                case ILargeTypeTable x:
                    return new SqlLargeTypeTableAdapter(Subject);
                default:
                    throw new NotImplementedException();

            }

        }
        ISqlTableProxy Subject { get; }

        public ISqlTableProxy Specify(ClrEnumLiteral literal)
        {
            SetTypeCode(literal.LiteralValue.ToClrValue());
            Description = literal.Description;
            Identifier = literal.LiteralName;
            Label = literal.Label;
            Subject.SetItemArray(GetItemArray());
            return Subject;

        }


        protected SqlTypeTableAdapter(ISqlTableProxy Subject)
        {
            this.Subject = Subject;
            SetItemArray(Subject.GetItemArray());
        }

        public string Identifier { get; private set; }

        public string Label { get; private set; }

        public string Description { get; private set; }

        protected abstract object GetTypeCode();

        protected abstract void SetTypeCode(object value);

        public object[] GetItemArray()
            => new object[] { GetTypeCode(), Identifier, Label, Description };

        public void SetItemArray(object[] items)
        {
            SetTypeCode(items[0]);
            Identifier = (string)items[1];
            Label = (string)items[2];
            Description = (string)items[3];
        }
    }

    public class SqlTypeTableAdapter<T> : SqlTypeTableAdapter
    {
        protected SqlTypeTableAdapter(ISqlTableProxy Subject)
            : base(Subject)
        {

        }

        protected override object GetTypeCode()
            => TypeCode;


        protected override void SetTypeCode(object value)
            => TypeCode = (T)value;


        public T TypeCode { get; set; }
    }

}
