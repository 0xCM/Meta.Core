//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;

using static minicore;

/// <summary>
/// Generates an implementation of a specified interface type that delegates to an implementation
/// of <see cref="IDynamicContractMessenger"/>
/// </summary>
static class DynamicContractImplementor
{
    const string MessengerContractName = nameof(IDynamicContractMessenger);
    static readonly Type MessengerContractType = typeof(IDynamicContractMessenger);

    static bool IsPropertyGet(this MethodInfo operation) 
        => operation.DeclaringType.GetProperties()
                    .Exists(p => p.Name == operation.Name.Replace("get_", String.Empty));

    static bool IsPropertySet(this MethodInfo operation) 
        => operation.DeclaringType.GetProperties()
                    .Exists(p => p.Name == operation.Name.Replace("set_", String.Empty));

    static Type[] GetParameterTypes(this MethodInfo operation) 
        => operation.GetParameters().Select(x => x.ParameterType).ToArray();

    static void ImplementConstructor(this TypeBuilder typeBuilder, FieldInfo messenger)
    {
        var flags = MethodAttributes.Public | MethodAttributes.HideBySig;
        var constructor =
            typeBuilder.DefineConstructor(flags, CallingConventions.HasThis,  array(MessengerContractType));

        var cILGen = constructor.GetILGenerator();
        cILGen.Emit(OpCodes.Ldarg_0);
        cILGen.Emit(OpCodes.Call, typeof(object).GetConstructor(new Type[] { }));
        cILGen.Emit(OpCodes.Nop);
        cILGen.Emit(OpCodes.Nop);
        cILGen.Emit(OpCodes.Ldarg_0);
        cILGen.Emit(OpCodes.Ldarg_1);
        cILGen.Emit(OpCodes.Stfld, messenger);
        cILGen.Emit(OpCodes.Ret);
    }

    static void AcceptParameter(this MethodBuilder builder, ILGenerator generator,  ParameterInfo parameter)
    {
        var pos = parameter.Position;
        builder.DefineParameter(pos + 1, parameter.Attributes, parameter.Name);
        generator.Emit(OpCodes.Dup);
        generator.Emit(OpCodes.Ldc_I4_S, pos);
        generator.Emit(OpCodes.Ldarg_S, pos + 1);
        if (parameter.ParameterType.IsValueType)
            generator.Emit(OpCodes.Box, parameter.ParameterType);
        generator.Emit(OpCodes.Stelem_Ref);

    }

    static MethodBuilder BuildOperation(this TypeBuilder typeBuilder, MethodInfo operation) 
        => typeBuilder.DefineMethod(
            name: operation.Name,
            attributes: operation.Attributes ^ MethodAttributes.Abstract,
            callingConvention: operation.CallingConvention,
            returnType: operation.ReturnType,
            parameterTypes: GetParameterTypes(operation)
            );

    static void InvokeMessengerFunction(this ILGenerator generator, MethodInfo operation)
    {
        var function = operation.IsPropertyGet() 
                     ? nameof(IDynamicContractMessenger.GetPropertyValue)
                     : (    operation.GetParameters().Length == 0
                          ? nameof(IDynamicContractMessenger.InvokeFunction)
                          : nameof(IDynamicContractMessenger.InvokeFunctionWithParameters)
                       );

        var interfaceMember = MessengerContractType.GetMethod(function);
        generator.Emit(OpCodes.Callvirt, interfaceMember);

        if (operation.ReturnType.IsValueType)
            generator.Emit(OpCodes.Unbox_Any, operation.ReturnType);
        else
            generator.Emit(OpCodes.Castclass, operation.ReturnType);
        generator.Emit(OpCodes.Ret);
    }

    static void InvokeMessengerAction(this ILGenerator bodyGenerator, MethodInfo operation)
    {

        var action = operation.IsPropertySet() 
                   ? nameof(IDynamicContractMessenger.SetPropertyValue)
                   : (      operation.GetParameters().Length == 0
                          ? nameof(IDynamicContractMessenger.InvokeAction)
                          : nameof(IDynamicContractMessenger.InvokeActionWithParameters)
                     );

        var interfaceMember = MessengerContractType.GetMethod(action);

        bodyGenerator.Emit(OpCodes.Callvirt, interfaceMember);
        bodyGenerator.Emit(OpCodes.Nop);
        bodyGenerator.Emit(OpCodes.Ret);
    }

    static void InvokeMessenger(this ILGenerator generator, MethodInfo operation)
    {
        if (operation.ReturnType != typeof(void))
            generator.InvokeMessengerFunction(operation);
        else
            generator.InvokeMessengerAction(operation);
    }

    static void ImplementOperation(this TypeBuilder typeBuilder, MethodInfo operation, FieldInfo messenger)
    {
        var method = typeBuilder.BuildOperation(operation);
        var generator = method.GetILGenerator();
        generator.Emit(OpCodes.Ldarg_0);
        generator.Emit(OpCodes.Ldfld, messenger);
        generator.Emit(OpCodes.Call,
            typeof(MethodBase).GetMethod(
                nameof(MethodBase.GetCurrentMethod), BindingFlags.Public | BindingFlags.Static));

        //Load the fields that will be passed to the messenger into an array
        var parameters = operation.GetParameters();
        if (parameters.Length != 0)
        {
            generator.Emit(OpCodes.Ldc_I4_S, parameters.Length);
            generator.Emit(OpCodes.Newarr, typeof(object));

            for (int pos = 0; pos < parameters.Length; pos++)
            {
                var parameter = parameters[pos];
                method.AcceptParameter(generator, parameter);
            }
        }

        generator.InvokeMessenger(operation);

    }

    static TypeBuilder CreateTypeBuilder(this ModuleBuilder module, Type contractType, string ImplementationName) 
        => module.DefineType
            (
                name: ImplementationName,
                attr: TypeAttributes.Public | TypeAttributes.Class,
                parent: typeof(object),
                interfaces: new[] { contractType}
            );

    static Type GetContractType<T>()
    {
        var contractType = typeof(T);
        if (!typeof(T).IsInterface)
            throw new ArgumentException($"The type {typeof(T)} is not an interface");
        return contractType;
    }

    static void ImplementOperations(this TypeBuilder typeBuilder, Type contractType, FieldInfo messenger) 
        => contractType.GetMethods().Iterate(operation => 
            typeBuilder.ImplementOperation(operation, messenger));
        
    static FieldInfo DefineMessengerField(this TypeBuilder typeBuilder) 
        => typeBuilder.DefineField("messenger", MessengerContractType, FieldAttributes.Private | FieldAttributes.InitOnly);

    static Type CreateImplementationType(this TypeBuilder typeBuilder, Type contractType)
    {
        typeBuilder.AddInterfaceImplementation(contractType);
        var messengerField = typeBuilder.DefineMessengerField();
        typeBuilder.ImplementConstructor(messengerField);
        typeBuilder.ImplementOperations(contractType, messengerField);
        return typeBuilder.CreateType();
    }

    static Type CreateImplementationType(this ModuleBuilder moduleBuilder, Type contractType, string ImplementationName) 
        => moduleBuilder.CreateTypeBuilder(contractType, ImplementationName)
                        .CreateImplementationType(contractType);

    /// <summary>
    /// Generates implementation of an interface contract that delegates to <see cref="IDynamicContractMessenger"/>
    /// </summary>
    /// <typeparam name="T">The type of contract for which an implementation will be generated</typeparam>
    /// <param name="ImplementationName">The name of the implemented type</param>
    /// <returns></returns>
    public static Type ImplementContract<T>(string ImplementationName)
    {
        var contractType = GetContractType<T>();
        var asmname = new AssemblyName(ImplementationName);
        var asm = AssemblyBuilder.DefineDynamicAssembly(asmname, AssemblyBuilderAccess.Run);
        var type = asm.DefineDynamicModule(ImplementationName).CreateImplementationType(contractType, ImplementationName);
        return type;
    }

}
