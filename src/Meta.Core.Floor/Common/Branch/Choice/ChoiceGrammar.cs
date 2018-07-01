//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core
{
    using System;
    using System.Linq;

    public static class ChoiceGrammar
    {
        public static readonly string Entails = "=>";
        public static readonly string OfType = ":";
        public static readonly string And = "&";
        public static readonly string Or = "|";
        public static readonly string Between = "between";
    }
}