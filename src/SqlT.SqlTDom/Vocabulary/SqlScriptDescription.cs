//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dom
{
    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    using SqlT.Models;
    using SqlT.Core;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;


    public class SqlScriptDescription
    {
        object CorrelatedInstance { get; }


        public SqlScriptDescription(TSql.TSqlFragment ScriptNode, SqlDomTypeCorrelation TypeCorrelation)
        {
            this.ScriptNode = ScriptNode;
            this.TypeCorrelation = TypeCorrelation;

            if (TypeCorrelation.SqlTType.IsClassType)
            {

                void TransferList(object src, object dst)
                {
                    var srcList = src as IList;
                    var dstList = dst as IList;
                    foreach (var srcItem in srcList)
                    {

                        dstList.Add(srcItem);
                        srcItem.GetType().ClrType().OnSome(t =>
                        {
                            if (t != typeof(object))
                            {
                                if (t.IsGenericListType)
                                {

                                }
                                else
                                {

                                }
                            }

                        });
                    }
                }

                void TransferProperties(object src, object dst)
                {
                    var srcType = src.GetType();
                    var dstProperties = dst.GetType().GetPublicProperties(true, true).ToDictionary(x => x.Name);
                    foreach (var srcProp in srcType.GetPublicProperties(true, true))
                    {
                        if (dstProperties.Keys.Contains(srcProp.Name))
                        {
                            var dstProp = dstProperties[srcProp.Name];
                            dstProp.PropertyType.ClrType().OnSome(t =>
                            {
                                try
                                {
                                    if (t.IsGenericListType)
                                    {
                                        var elementType = t.GenericTypeArguments.Single();
                                        var elementListType = typeof(List<>).GetGenericTypeDefinition().MakeGenericType(elementType);
                                        var elementList = Activator.CreateInstance(elementListType);
                                        dstProp.SetValue(dst, elementList);
                                        TransferList(srcProp.GetValue(src), elementList);
                                    }
                                    else
                                    {
                                        dstProp.SetValue(dst, srcProp.GetValue(src));
                                    }
                                }
                                catch { }

                            });

                        }
                    }
                }

                var m = 0;
                if (m == -1)
                {
                    CorrelatedInstance = Activator.CreateInstance(TypeCorrelation.SqlTType.ReflectedElement);
                    foreach (var p in TypeCorrelation.SqlTType.PublicInstanceProperties)
                    {
                        TypeCorrelation.SqlTType.PublicInstanceProperties.TryGetFirst(y => y.Name == p.Name).OnSome(value =>
                        {
                            if (p.PropertyType.IsListType)
                                TransferList(ScriptNode, CorrelatedInstance);
                            else
                                TransferProperties(ScriptNode, CorrelatedInstance);

                        });
                    }
                }

            }


        }

        public TSql.TSqlFragment ScriptNode { get; }

        public Option<SqlDomTypeCorrelation> TypeCorrelation { get; }

        public override string ToString()
            => TypeCorrelation.ToString();
    }


}