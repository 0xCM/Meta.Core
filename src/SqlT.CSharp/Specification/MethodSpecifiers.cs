//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using SqlT.Models;
    using SqlT.Syntax;
    using SqlT.SqlSystem;

    using static metacore;
    using static ClrStructureSpec;
    using static ClrBehaviorSpec;
    using ClrModel;

    static class MethodSpecifiers
    {
        public static IEnumerable<IClrMemberSpec> SpecifyCustomMethods(this vIndex subject, CodeGenerationProfile gp)
        {
            yield return new MethodSpec
            (
                subject.SpecifyClassName(),
                CustomMethods.GetItemArray.IdentifierText,
                ReturnType: null,
                CustomMemberKind: CustomMethods.GetItemArray
            );

            yield return new MethodSpec
            (
                subject.SpecifyClassName(),
                CustomMethods.SetItemArray.IdentifierText,
                ReturnType: null,
                CustomMemberKind: CustomMethods.SetItemArray
            );
        }

        public static IEnumerable<IClrMemberSpec> SpecifyCustomMethods(this vObject subject, CodeGenerationProfile gp)
        {
            yield return new MethodSpec
            (
                subject.SpecifyClassName(),
                CustomMethods.GetItemArray.IdentifierText,
                ReturnType: null,
                CustomMemberKind: CustomMethods.GetItemArray
            );

            yield return new MethodSpec
            (
                subject.SpecifyClassName(),
                CustomMethods.SetItemArray.IdentifierText,
                ReturnType: null,
                CustomMemberKind: CustomMethods.SetItemArray
            );
        }

        public static IEnumerable<IClrMemberSpec> SpecifyCustomMethods(this vTableType subject, CodeGenerationProfile gp)
        {
            if (subject.Columns.Count != 0)
            {
                yield return new MethodSpec
                (
                    subject.SpecifyClassName(),
                    CustomMethods.GetItemArray.IdentifierText,
                    ReturnType: null,
                    CustomMemberKind: CustomMethods.GetItemArray
                );

                yield return new MethodSpec
                (
                    subject.SpecifyClassName(),
                    CustomMethods.SetItemArray.IdentifierText,
                    ReturnType: null,
                    CustomMemberKind: CustomMethods.SetItemArray
                );
            }
        }

        public static MethodParameterSpec SpecifyMethodParameter(this vParameter subject, CodeGenerationProfile gp)
            => new MethodParameterSpec
                (
                    Name: subject.SpecifyMethodParameterName(),
                    ParameterType: subject.SpecifyTypeReference(gp),
                    Position: subject.Position,
                    Attributions: subject.SpecifyAttributions()
                );
     
        public static MethodSpec SpecifyWorkflowOperation(this MethodSpec operation, CodeGenerationProfile gp)
        {
            var opArgs = mapi(operation.MethodParameters, 
                (i,p) => new MethodArgumentValueSpec(ArgumentPosition: i, ValueExpression: p.Name.SpecifyLiteralValue()));
            var preInvoke = operation.SpecifyInvocation(opArgs, gp);
            var token = new VariableDeclarationSpec("token", preInvoke);

            //TODO:LOTS
            return new MethodSpec(
                DeclaringTypeName: new ClrClassName("SqlWorkflow"), 
                Name: (ClrMethodName)operation.Name, 
                ReturnType: operation.ReturnType.ValueOrDefault());
            
        }
        
    }
}
