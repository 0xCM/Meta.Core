//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;

/// <summary>
/// Represents a mechanism to associate a set of system actions across both logical
/// and physical boundaries
/// </summary>
public readonly struct CorrelationToken 
{
    public static readonly CorrelationToken Empty = new CorrelationToken("0");

    public static implicit operator CorrelationToken(string value) 
        => Create(value);

    public static implicit operator string(CorrelationToken x) 
        => x.Text;

    public static CorrelationToken Create(string value = null)
        => new CorrelationToken(value ?? Guid.NewGuid().ToString("N"));

    public CorrelationToken(object value)
    {
        Text =  value?.ToString() ?? String.Empty;
    }

    /// <summary>
    /// The textual representation of the correlation token
    /// </summary>
    public string Text { get; }

    /// <summary>
    /// Determines whether the token has the default/empty value
    /// </summary>
    /// <returns></returns>
    public bool IsEmpty()
        => Object.ReferenceEquals(this, Empty);

    public override string ToString()
        => IsEmpty()
        ? String.Empty
        : Text;

}
