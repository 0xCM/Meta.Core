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
    using System.Collections.Concurrent;
    using System.Text;

    using static ClrStructureSpec;

    using SqlT.Core;
    using SqlT.Models;
    using SqlT.SqlTDom;

    

    using static metacore;

    public class SqlTDomFunc : ApplicationComponent
    {
        public SqlTDomFunc(IApplicationContext C)
            : base(C)
        { }

        //public static RaiseErrorStatement RaiseError
        //    (
        //        ScalarExpression FirstParameter = null,
        //        ScalarExpression SecondParameter = null,
        //        ScalarExpression ThirdParameter = null,
        //        IList<ScalarExpression> OptionalParameters = null,
        //        RaiseErrorOptions RaiseErrorOptions = default(RaiseErrorOptions)
        //    ) => new RaiseErrorStatement
        //    {
        //        FirstParameter = FirstParameter,
        //        SecondParameter = SecondParameter,
        //        ThirdParameter = ThirdParameter,
        //        OptionalParameters = OptionalParameters,
        //        RaiseErrorOptions = RaiseErrorOptions
        //    };



        static MethodSpec SpecifyOperation(ClrInterfaceName contractName, MethodSignature sig)
            => new MethodSpec
            (
                contractName,
                Name: sig.MethodName,
                Documentation: sig.Documentation.ValueOrDefault(),
                MethodParameters: sig.MethodParameters,
                ReturnType: sig.ReturnType
            );

        public static InterfaceSpec SpecifyContract(ClrInterfaceName contractName, IEnumerable<MethodSignature> signatures)
        {
                      
            var methods = new List<MethodSpec>();

            foreach (var sig in signatures)
                methods.Add(SpecifyOperation(contractName, sig));

            return new InterfaceSpec
            (
                Name: contractName,
                AccessLevel:  ClrAccessKind.Public,
                Members: methods,
                Documentation: new ElementDescription($"Functions that produce SqlTDom model elements"),
                Attributions: array(new AttributionSpec(nameof(SqlOperationContractAttribute)))
            );
        }

        static MethodSignature SpecifyFactorySignature(ClrClass target)
        {

            var methodName = new ClrMethodName(target.Name.Replace("Statement", string.Empty));
            var returnType = target.GetReference();
            var parameters = rolist
                (
                    from prop in target.SpecifyProperties(false)
                    where not(SqlTDomInfo.IgnoredModelProperties.Contains(prop.PropertyName))
                    select new MethodParameterSpec
                    (
                        Name: new ClrMethodParameterName(prop.Name.Components.Last()),
                        ParameterType: prop.PropertyType
                    ));

            return new MethodSignature
            (
                Name: methodName,
                ReturnType: returnType,
                MethodParameters: parameters
            );
        }

        public InterfaceSpec SpecifyMasterContract()
            => SpecifyContract("ISqlTDomFactories", SpecifySignatures());
            
        public IEnumerable<MethodSignature> SpecifySignatures()
        {
            var bridge = C.Service<ISqlMetamodelServices>();

            var types = bridge.GetSqlTModelTypes().Where(t => t.IsClassType).Cast<ClrClass>();
            foreach (var type in types)
                yield return SpecifyFactorySignature(type);
        }

        public static MethodSignature SpecifySignature(Type type)
        {

            var target = ClrClass.Get(type);
            var methodName = new ClrMethodName(type.Name.Replace("Statement", string.Empty));
            var returnType = target.GetReference();
            var parameters = rolist
                (
                    from prop in target.PublicInstanceProperties
                    where not(SqlTDomInfo.IgnoredModelProperties.Contains(prop.Name))
                    select new MethodParameterSpec
                    (
                        Name: prop.Name,
                        ParameterType: prop.PropertyType.GetReference()
                    ));                                         

            return new MethodSignature
            (
                Name: methodName,
                ReturnType: returnType,
                MethodParameters: parameters
            );

        }
    }
}
