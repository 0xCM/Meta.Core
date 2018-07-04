//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.SqlSystem
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using SqlT.Core;

    using sxc = SqlT.Syntax.contracts;

    public class vSequence : vObject
    {

        public vSequence(ISchema schema, ISequence sequence, vType dataType, IEnumerable<IExtendedProperty> properties)
            : base(schema, sequence, properties)
        {
            this._sequence = sequence;
            this._dataType = dataType;
        }

        ISequence _sequence { get; }

        vType _dataType { get; }

        public object StartValue 
            => _sequence.start_value;

        object Increment 
            => _sequence.increment;

        object MinValue 
            => _sequence.minimum_value;

        object MaxValue 
            => _sequence.maximum_value;

        bool IsCycling 
            => _sequence.is_cycling ?? false;

        bool IsCached 
            => _sequence.is_cached ?? false;

        int? CacheSize 
            => _sequence.cache_size;

        public sxc.type_name DataTypeName 
            => _dataType.TypeName;

        public byte Precision 
            => _sequence.precision;

        public byte? Scale 
            => _sequence.scale ?? 0;

        public object CurrentValue 
            => _sequence.current_value;

        public SqlSequenceName SequenceName
            => new SqlSequenceName(SchemaName, Name);

        public override sxc.ISqlObjectName ObjectName
            => SequenceName;

    }

}