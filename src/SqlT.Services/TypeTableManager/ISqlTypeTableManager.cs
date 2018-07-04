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


    public interface ISqlTypeTableManager : IApplicationService
    {

        Option<int> UpdateTypeTable(ISqlProxyBroker Broker, ISqlProxyTypeBinding Binding);

        Option<int> UpdateTypeTable(ISqlProxyBroker Broker, SqlTableName TypeTableName, Type enumType);

        Option<int> UpdateTypeTable<T,E>(ISqlProxyBroker Broker)
            where T : class, ISqlTableProxy, new();

        SqlTable DefineTypeTable(Type EnumType, SqlSchemaName Schema, SqlTableName TableName = null);

        SqlTable DefineTypeTable<E>(SqlSchemaName Schema, SqlTableName TableName = null);


    }





}