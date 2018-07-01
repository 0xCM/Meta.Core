//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Defines the concept of frequency in terms of magnitude and unit
/// </summary>
public struct Frequency 
{
        
    static IReadOnlyDictionary<FrequencyUnit, decimal> Factors 
        = new Dictionary<FrequencyUnit,decimal>
    {
        [FrequencyUnit.Second] = 1m,
        [FrequencyUnit.Minute] = 60m,
        [FrequencyUnit.Hour] = 3600m,
        [FrequencyUnit.Day] = 86400m

    };

    static decimal ConvertToBase(Frequency src) 
        => Factors[src.Unit] * src.Magnitude;

    static Frequency ConvertFromBase(decimal baseMagnitude, FrequencyUnit dstUnit) 
        => new Frequency(baseMagnitude / Factors[dstUnit], dstUnit);

    public Frequency(decimal Magnitude, FrequencyUnit unit)
    {
        this.Magnitude = Magnitude;
        this.Unit = unit;
    }

    /// <summary>
    /// The frequency magnitude
    /// </summary>
    public decimal Magnitude { get; }

    /// <summary>
    /// The frequency UOM
    /// </summary>
    public FrequencyUnit Unit { get; }



    public Frequency Convert(FrequencyUnit dstUnit) 
        =>  ConvertFromBase(ConvertToBase(this), dstUnit);

    public override string ToString() 
        => $"{Magnitude}/{Unit}";

}

