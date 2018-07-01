//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, donascii.t clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace Meta.Syntax
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using static metacore;

    /// <summary>
    /// Defines the set of recognized ASCII letters
    /// </summary>
    public class AsciiLetter : SyntaxRule<AsciiLetter>
    {
        public static readonly AsciiLetter a = ascii.a;
        public static readonly AsciiLetter b = ascii.b;
        public static readonly AsciiLetter c = ascii.c;
        public static readonly AsciiLetter d = ascii.d;
        public static readonly AsciiLetter e = ascii.e;
        public static readonly AsciiLetter f = ascii.f;
        public static readonly AsciiLetter g = ascii.g;
        public static readonly AsciiLetter h = ascii.h;
        public static readonly AsciiLetter i = ascii.i;
        public static readonly AsciiLetter j = ascii.j;
        public static readonly AsciiLetter k = ascii.k;
        public static readonly AsciiLetter l = ascii.l;
        public static readonly AsciiLetter m = ascii.m;
        public static readonly AsciiLetter n = ascii.n;
        public static readonly AsciiLetter o = ascii.o;
        public static readonly AsciiLetter p = ascii.p;
        public static readonly AsciiLetter q = ascii.q;
        public static readonly AsciiLetter r = ascii.r;
        public static readonly AsciiLetter s = ascii.s;
        public static readonly AsciiLetter t = ascii.t;
        public static readonly AsciiLetter u = ascii.u;
        public static readonly AsciiLetter v = ascii.v;
        public static readonly AsciiLetter w = ascii.w;
        public static readonly AsciiLetter x = ascii.x;
        public static readonly AsciiLetter y = ascii.y;
        public static readonly AsciiLetter z = ascii.z;

        public static readonly AsciiLetter A = ascii.A;
        public static readonly AsciiLetter B = ascii.B;
        public static readonly AsciiLetter C = ascii.C;
        public static readonly AsciiLetter D = ascii.D;
        public static readonly AsciiLetter E = ascii.E;
        public static readonly AsciiLetter F = ascii.F;
        public static readonly AsciiLetter G = ascii.G;
        public static readonly AsciiLetter H = ascii.H;
        public static readonly AsciiLetter I = ascii.I;
        public static readonly AsciiLetter J = ascii.J;
        public static readonly AsciiLetter K = ascii.K;
        public static readonly AsciiLetter L = ascii.L;
        public static readonly AsciiLetter M = ascii.M;
        public static readonly AsciiLetter N = ascii.N;
        public static readonly AsciiLetter O = ascii.O;
        public static readonly AsciiLetter P = ascii.P;
        public static readonly AsciiLetter Q = ascii.Q;
        public static readonly AsciiLetter R = ascii.R;
        public static readonly AsciiLetter S = ascii.S;
        public static readonly AsciiLetter T = ascii.T;
        public static readonly AsciiLetter U = ascii.U;
        public static readonly AsciiLetter V = ascii.V;
        public static readonly AsciiLetter W = ascii.W;
        public static readonly AsciiLetter X = ascii.X;
        public static readonly AsciiLetter Y = ascii.Y;
        public static readonly AsciiLetter Z = ascii.Z;

        public static readonly SyntaxRule LowercaseLetter
            = a | b | c | d | e | f | g | h | i | j | k | l | m |
              n | o | p | q | r | s | t | u | v | w | x | y | z;

        public static readonly SyntaxRule UppercaseLetter
            = A | B | C | D | E | F | G | H | I | J | K | L | M |
              N | O | P | Q | R | S | T | U | V | W | X | Y | Z;

        public static readonly SyntaxRule AnyLetter
            = LowercaseLetter | UppercaseLetter;

        public static implicit operator AsciiLetter(char c)
            => new AsciiLetter(c);


        AsciiLetter(char c)            
            : base(c.ToString())
        { }

        protected override AsciiLetter Define(string RuleName, IEnumerable<SyntaxRule> Terms, string Description)
            => new AsciiLetter(RuleName.First());
    }


}
