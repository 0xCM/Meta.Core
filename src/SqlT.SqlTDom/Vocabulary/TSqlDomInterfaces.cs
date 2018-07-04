//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dom
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;
    using static ClrInterface;
    using System.Collections;

    using SqlT.SqlTDom;


    public class TSqlDomInterfaces : IEnumerable<ClrInterface>
    {
        public static TSqlDomInterfaces Enumerate = new TSqlDomInterfaces();

        static readonly IReadOnlySet<ClrInterface> Interfaces;

        static TSqlDomInterfaces()
        {
            Interfaces = roset(
                Get<ISqlTDomElement>(),
                Get<ISqlTDomInfrastructure>(),
                Get<ISqlTDomLiteral>(),
                Get<ISqlTDomExpression>(),
                Get<ISqlTDomStatement>(),
                Get<ISqlTDomAlterStatement>(),
                Get<ISqlTDomCreateStatement>(),
                Get<ISqlTDomDropStatement>(),
                Get<ISqlTDomOption>()
                );
        }


        TSqlDomInterfaces() { }

        public IEnumerator<ClrInterface> GetEnumerator()
            => Interfaces.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()        
            => Interfaces.GetEnumerator();
        
    }




}