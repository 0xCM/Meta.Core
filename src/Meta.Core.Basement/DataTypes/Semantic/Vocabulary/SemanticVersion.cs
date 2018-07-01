//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Represents a semantic version as described by http://semver.org/
/// </summary>
public readonly struct SemanticVersion 
{
    /// <summary>
    /// Transforms a <see cref="SemanticVersion"/> reference to text
    /// </summary>
    /// <param name="v">The version to convert to represent as a string</param>
    public static implicit operator string(SemanticVersion v) 
        => v.Text;

    /// <summary>
    /// Transforms a <see cref="Version"/> reference into a <see cref="SemanticVersion"/> reference
    /// </summary>
    /// <param name="v"></param>
    public static implicit operator SemanticVersion(Version v) 
        => new SemanticVersion(v);
        
    /// <summary>
    /// Transforms text representing a semantic version into a <see cref="SemanticVersion"/> reference
    /// </summary>
    /// <param name="text">The text from which an instance will be created</param>
    public static implicit operator SemanticVersion(string text) 
        => new SemanticVersion(text);

    /// <summary>
    /// The default version (1.0.0)
    /// </summary>
    public static SemanticVersion Default = new SemanticVersion(1);

    /// <summary>
    /// Initializes a new <see cref="SemanticVersion"/> instance
    /// </summary>
    /// <param name="major">The major version</param>
    /// <param name="minor">The minor version</param>
    /// <param name="patch">The patch version</param>
    public SemanticVersion(ushort major = 1, ushort minor = 0, ushort patch = 0)
    {
        this.Major = major;
        this.Minor = minor;
        this.Patch = patch;
    }

    /// <summary>
    /// Initializes a new <see cref="SemanticVersion"/> instance
    /// </summary>
    /// <param name="version">The system version</param>
    public SemanticVersion(Version version)
    {
        this.Major = (ushort)version.Major;
        this.Minor = (ushort)version.Minor;
        this.Patch = (ushort)version.Build;
    }

    /// <summary>
    /// Initializes  a new <see cref="SemanticVersion"/> from representative text
    /// </summary>
    /// <param name="text"></param>
    public SemanticVersion(string text)
    {
        var components = text.Split('.');
        if (components.Length != 3)
            throw new ArgumentException($"Version text not properly formatted");
        Major = ushort.Parse(components[0]);
        Minor = ushort.Parse(components[1]);
        Patch = ushort.Parse(components[2]);
    }

    /// <summary>
    /// The major version
    /// </summary>
    public ushort Major { get; }

    /// <summary>
    /// The minor version
    /// </summary>
    public ushort Minor { get; }

    /// <summary>
    /// The patch version
    /// </summary>
    public ushort Patch { get; }

    /// <summary>
    /// Semantic version string
    /// </summary>
    public string Text 
        => $"{Major}.{Minor}.{Patch}";

    /// <summary>
    /// Renders an instance in a form suitable for diagnostic purposes
    /// </summary>
    /// <returns></returns>
    public override string ToString() 
        => Text;
}

