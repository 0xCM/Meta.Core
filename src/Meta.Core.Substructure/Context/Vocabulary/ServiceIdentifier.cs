//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using static minicore;

/// <summary>
/// Connfers identity on service realizations
/// </summary>
public struct ServiceIdentifier : IEquatable<ServiceIdentifier>
{
    public static ServiceIdentifier Define(Type Contract, Type Implementor)
        => new ServiceIdentifier(Contract.FullName, Implementor.FullName);


    public static ServiceIdentifier Define<C, I>()
        => Define(typeof(C), typeof(I));

    public static Option<ServiceIdentifier> Parse(string text)
    {
        if (!text.Contains("/"))
            return new ServiceIdentifier(text, "Default");
        var components = text.Split('/');

        if (components.Length != 1)
            return none<ServiceIdentifier>(AppMessage.Error($"A maximum of 2 segments is supported: {text}"));

        return new ServiceIdentifier(components[0], components[1]);        
    }

    public static implicit operator (string ContractType, string Implementor) (ServiceIdentifier x)
        => (x.ContractType,x.Implementor);

    public static implicit operator ServiceIdentifier((string ContractType, string Implementor) x2)
        => new ServiceIdentifier(x2.ContractType, x2.Implementor);

    public ServiceIdentifier(string ContractType, string Implementor)
    {
        this.ContractType = ContractType;
        this.Implementor = Implementor;
    }

    public string ContractType { get; }

    public string Implementor { get; }

    public override string ToString()
        => string.Join("/", ContractType, Implementor);

    public override int GetHashCode()
        => ToString().ToLower().GetHashCode();

    public override bool Equals(object obj)
        => obj is ServiceIdentifier 
        ? Equals((ServiceIdentifier)obj)
        : false;

    public bool Equals(ServiceIdentifier other)
        => ToString() == other.ToString();
}
