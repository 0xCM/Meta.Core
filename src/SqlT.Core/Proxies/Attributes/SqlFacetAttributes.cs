//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Core
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Linq;
    
    public interface IFacetAttribute
    {
        string Name { get; }
        object Value { get; }
    }

    public interface IFacetAttribute<out V> : IFacetAttribute
    {
        new V Value { get; }
    }


    public abstract class SqlFacetAttribute : Attribute, IFacetAttribute
    {
        protected readonly object FacetValue;
        protected readonly string FacetName;
        protected SqlFacetAttribute()
        {
            this.FacetName = GetType().Name.Replace("Sql", String.Empty).Replace("Attribute", String.Empty);
        }

        protected SqlFacetAttribute(object Value)
            : this()
        {
            this.FacetValue = Value;
        }

        object IFacetAttribute.Value
            => FacetValue;

        string IFacetAttribute.Name
            => FacetName;
    }

    public class SqlSchemaAttribute : SqlFacetAttribute, IFacetAttribute<SqlSchemaName>
    {
        public SqlSchemaAttribute(string SchemaName)
            : base(SqlSchemaName.Parse(SchemaName))
        {
            
        }

        public SqlSchemaName Value
            => (SqlSchemaName)FacetValue;
    }


    public class SqlLengthAttribute : SqlFacetAttribute, IFacetAttribute<int>
    {
        public SqlLengthAttribute(int Length)
            : base(Length)
        {
            
        }

        public int Value
            => (int)FacetValue;
    }

    public class SqlSequentialKeyAttribute : SqlFacetAttribute, IFacetAttribute<SqlSequenceName>
    {
        public SqlSequentialKeyAttribute()
            : base(SqlSequenceName.Empty)
        {
            
        }

        public SqlSequentialKeyAttribute(string SequenceName)
            : base(SqlSequenceName.Parse(SequenceName))
        {
            
        }

        public SqlSequenceName Value
            => (SqlSequenceName)FacetValue;
    }

    /// <summary>
    /// Indicates that the representing member cannot be null
    /// </summary>
    public class SqlNotNullAttribute : SqlFacetAttribute
    {
        

    }

    /// <summary>
    /// Indicates that the representing member may be null
    /// </summary>
    public class SqlNullAttribute : SqlFacetAttribute
    {
    }

    public class SqlUniqueKeyAttribute : SqlFacetAttribute, IFacetAttribute<string>
    {
        public SqlUniqueKeyAttribute(string KeyName)
            : base(KeyName)
        {


        }

        public string Value
            => (string)FacetValue;
    }

    public class SqlColumnRoleAttribute : SqlFacetAttribute, IFacetAttribute<string>
    {
        public SqlColumnRoleAttribute(string RoleName)
            : base(RoleName)
        {
            
        }

        public SqlColumnRoleAttribute(SqlColumnRoleKind RoleKind)
            : base(RoleKind.ToString())
        {
            
        }

        public string Value
            => (string)FacetValue;
    }


    public class SqlScaleAttribute : SqlFacetAttribute, IFacetAttribute<byte>
    {
        public SqlScaleAttribute(byte Scale)
            : base(Scale)
        {
            
        }


        public byte Value
            => (byte)FacetValue;
    }


    public class SqlPrecisionScaleAttribute : SqlFacetAttribute
    {
        public SqlPrecisionScaleAttribute(byte Precision, byte Scale)
        {
            this.Precision = Precision;
            this.Scale = Scale;
        }


        public byte Scale { get; }
        public byte Precision { get; }
    }





}
