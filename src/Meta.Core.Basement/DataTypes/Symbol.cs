//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

/// <summary>
/// Defines a primtive 'symbol' type and collects a number of common instances
/// </summary>
public readonly struct Symbol
{   
    public static implicit operator Symbol((string name, char representation) s)
        => new Symbol(s.name, s.representation);

    public static implicit operator Symbol((string name, string representation) s)
        => new Symbol(s.name, s.representation);

    public static implicit operator char(Symbol s)
        => s.Represenation.FirstOrDefault();

    public static implicit operator string(Symbol s)
        => s.Represenation;

    public static readonly Symbol dagger = (nameof(dagger), 'ተ');
    public static readonly Symbol ተ = dagger;

    public static readonly Symbol plus = (nameof(plus), 'ᕀ');
    public static readonly Symbol ᕀ = plus;

    public static readonly Symbol star = (nameof(star), 'ᛡ');
    public static readonly Symbol ᛡ = star;
    
    public static readonly Symbol up = (nameof(up), 'ᛏ');
    public static readonly Symbol ᛏ = up;

    public static readonly Symbol down = (nameof(down), 'ᛎ');
    public static readonly Symbol ᛎ = down;

    public static readonly Symbol pipe = (nameof(pipe), 'ǀ');
    public static readonly Symbol ǀ = pipe;

    public static readonly Symbol gt = (nameof(gt), 'ᐳ');
    public static readonly Symbol ᐳ = gt;

    public static readonly Symbol lt = (nameof(lt), 'ᐸ');
    public static readonly Symbol ᐸ = lt;

    public static readonly Symbol fslash = (nameof(fslash), 'ノ');
    public static readonly Symbol ノ = fslash;

    public static readonly Symbol slashraised = (nameof(slashraised), 'ᐟ');
    public static readonly Symbol ᐟ = slashraised;

    public static readonly Symbol question = (nameof(question), 'ॽ');
    public static readonly Symbol ॽ = question;

    public static readonly Symbol compose = (nameof(compose), 'ᐤ');
    public static readonly Symbol ᐤ = compose;

    public static readonly Symbol dot = (nameof(dot), 'ㆍ');
    public static readonly Symbol ㆍ = dot;        

    public static readonly Symbol dash = (nameof(dash), 'ᐨ'); 
    public static readonly Symbol ᐨ = dash;

    public static readonly Symbol eqraised = (nameof(eqraised), 'ᙿ');
    public static readonly Symbol ᙿ = eqraised;

    public static readonly Symbol neqraised = (nameof(neqraised), 'ᙾ');
    public static readonly Symbol ᙾ = neqraised;

    public static readonly Symbol squote = (nameof(squote), 'ᑊ');
    public static readonly Symbol ᑊ = squote;

    public static readonly Symbol dquote = (nameof(dquote), 'ʺ');
    public static readonly Symbol ʺ = dquote;

    public static readonly Symbol alpha = (nameof(alpha), 'α');
    public static readonly Symbol α = alpha;

    public static readonly Symbol beta = (nameof(beta), 'β');
    public static readonly Symbol β = beta;

    public static readonly Symbol gamma = (nameof(gamma), 'γ');
    public static readonly Symbol γ = gamma;

    public static readonly Symbol Gamma = (nameof(Gamma), 'γ');
    public static readonly Symbol Γ = Gamma;

    public static readonly Symbol delta = (nameof(delta), 'δ');
    public static readonly Symbol δ = delta;

    public static readonly Symbol Delta = (nameof(Delta), 'Δ');
    public static readonly Symbol Δ = Delta;

    public static readonly Symbol eta = (nameof(eta), 'η');
    public static readonly Symbol η = eta;

    public static readonly Symbol kappa = (nameof(kappa), 'κ');
    public static readonly Symbol κ = kappa;

    public static readonly Symbol pi = (nameof(pi), 'π');
    public static readonly Symbol π = pi;

    public static readonly Symbol Pi = (nameof(Pi), 'Π');
    public static readonly Symbol Π = Pi;

    public static readonly Symbol rho = (nameof(rho), 'ρ');
    public static readonly Symbol ρ = rho;

    public static readonly Symbol Sigma = (nameof(Sigma), 'Σ');
    public static readonly Symbol Σ = Sigma;

    public static readonly Symbol tau = (nameof(tau), 'τ');
    public static readonly Symbol τ = tau;

    public static readonly Symbol Tau = (nameof(Tau), 'Τ');
    public static readonly Symbol Τ = Tau;

    public static readonly Symbol Omega = (nameof(Omega), 'Ω');
    public static readonly Symbol Ω = Omega;

    public static readonly Symbol lambda = (nameof(lambda), 'λ');
    public static readonly Symbol λ = lambda;

    public static readonly Symbol З = (nameof(З), 'З');

    public static readonly Symbol isect = (nameof(isect), '∩');
    public static readonly Symbol entails = (nameof(entails), "=>");
    public static readonly Symbol flowsto = (nameof(flowsto), "=>");
    public static readonly Symbol and = (nameof(and), "&");
    public static readonly Symbol or = (nameof(or), "|");
    public static readonly Symbol outflow = (nameof(outflow), 'ᐳ');
    public static readonly Symbol mapsto = new Symbol(nameof(mapsto), '⟼');
    public static readonly Symbol cross = (nameof(cross), '⤫');
    public static readonly Symbol minus = (nameof(minus), '-');
    public static readonly Symbol arrowR = (nameof(arrowR), '→');
    public static readonly Symbol arrowL = (nameof(arrowL), '←');

    public static readonly Symbol notIn = (nameof(notIn), '∉');

    public static readonly Symbol empty = (nameof(empty), '∅');

    /// <summary>
    /// Standard file system path separator
    /// </summary>
    public static readonly Symbol fsep = (nameof(fsep), '\\');

    /// <summary>
    /// Standard percentage symbol
    /// </summary>
    public static readonly Symbol pct = (nameof(pct), '%');

   
    public Symbol(string Name, char Representation)
    {
        this.Name = Name;
        this.Represenation = Representation.ToString();
    }

    public Symbol(string Name, string Representation)
    {
        this.Name = Name;
        this.Represenation = Representation;
    }

    /// <summary>
    /// The name of the symbol
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// The symbolic depiction
    /// </summary>
    public string Represenation { get; }

    public override string ToString()
        => Represenation.ToString();

    /// <summary>
    /// Pads the representation on the left and right with a single space
    /// </summary>
    /// <returns></returns>
    public string Spaced()
        => $" {this} ";
}

