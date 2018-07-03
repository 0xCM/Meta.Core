//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Diagnostics;


public sealed class DynamicContractHost<T> : IDynamicContract
{
    readonly IDynamicContractMessenger messenger;
    readonly IDynamicContract Contract;

    internal DynamicContractHost(IDynamicContract contract)
    {
        this.Contract = contract;
        this.messenger = new MessengerImplementation(this);
    }

    internal IDynamicContractMessenger Messenger => messenger;

    class MessengerImplementation : IDynamicContractMessenger
    {
        static readonly object[] EmptyParameters = new object[] { };

        readonly IDynamicContract Contract;

        static MethodInfo GetContractMethod(MethodBase implementation) 
            => typeof(T).GetMethod(implementation.Name, implementation.GetParameters().Select(x => x.ParameterType).ToArray());

        static string AccessorName(MethodBase m) 
            => m.Name.Replace("get_", string.Empty).Replace("set_", string.Empty);

        public MessengerImplementation(IDynamicContract contract)
        {
            this.Contract = contract;
        }

        public string ImplementationName 
            => Contract.ImplementationName;

        [DebuggerStepThrough]
        public object GetPropertyValue(MethodBase getter) =>
            Contract.GetPropertyValue(typeof(T).GetProperty(AccessorName(getter)));

        [DebuggerStepThrough]
        public void SetPropertyValue(MethodBase setter, object[] value) 
            => Contract.SetPropertyValue(typeof(T).GetProperty(AccessorName(setter)), value[0]);

        [DebuggerStepThrough]
        public void InvokeAction(MethodBase method) 
            =>  Contract.InvokeAction(GetContractMethod(method), EmptyParameters);

        [DebuggerStepThrough]
        public void InvokeActionWithParameters(MethodBase method, object[] parameters) 
            => Contract.InvokeAction(GetContractMethod(method), parameters);

        [DebuggerStepThrough]
        public object InvokeFunction(MethodBase method)  
            => Contract.InvokeFunction(GetContractMethod(method), EmptyParameters);

        [DebuggerStepThrough]
        public object InvokeFunctionWithParameters(MethodBase method, object[] parameters) 
            => Contract.InvokeFunction(GetContractMethod(method), parameters);

    }

    string IDynamicContract.ImplementationName 
        =>  Contract.ImplementationName;

    object IDynamicContract.GetPropertyValue(PropertyInfo property) 
        =>  Contract.GetPropertyValue(property);

    void IDynamicContract.InvokeAction(MethodInfo method, object[] parameters) 
        => Contract.InvokeAction(method, parameters);

    object IDynamicContract.InvokeFunction(MethodInfo method, object[] parameters) 
        => Contract.InvokeFunction(method, parameters);

    void IDynamicContract.SetPropertyValue(PropertyInfo property, object value) 
        => Contract.SetPropertyValue(property, value);
}
