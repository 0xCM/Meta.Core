//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace Meta.Core.Test
{
    using System;
    using System.Linq;

    using static metacore;
    using static operators;
    using static grammar;

    using Meta.Syntax;

    using UT = Microsoft.VisualStudio.TestTools.UnitTesting;


    public static class Nuget
    {


        public class Tokens
        {

            public static TokenRule add
                => describe(token(), "Adds the given package to a hierarchical source");

            public static TokenRule Expand
                => token();

            public static TokenRule Verbosity
                => token();

            public static TokenRule normal
                => token();

            public static TokenRule quiet
                => token();

            public static TokenRule detailed
                => token();

            public static TokenRule NonInteractive
                => token();

            public static TokenRule ConfigFile
                => token();

            public static TokenRule Source
                => token();


            public static TokenRule ForceEnglishOutput
                => describe(token(), "Forces the application to run using an invariant, English-based culture.");

            public static TokenRule config
                => describe(token(), "Gets or sets NuGet config values");

            public static TokenRule delete
                => describe(token(), "Deletes a package from the server");

            public static TokenRule init
                => describe(token(), "Adds all the packages from the <srcPackageSourcePath> to the hierarchical <destPackageSourcePath>");

        }

        public static Slot srcPackageSourcePath
            => slot();

        public static Slot dstPackageSourcePath
            => slot();

        public static Slot packagePath
            => slot();

        public static Slot folderBasePackageSource
            => slot();

        public static Slot config_file_path
            => slot();

        public static SyntaxRule Verbosity
            => define(Tokens.quiet
            | Tokens.normal
            | Tokens.detailed);


        public static SyntaxRule add_option
            => Tokens.Expand
            | Verbosity
            | Tokens.NonInteractive
            | Tokens.ConfigFile + maybe(config_file_path)
            | Tokens.ForceEnglishOutput
            ;

        public static SyntaxRule init_option
            => Tokens.Expand
            | Verbosity
            | Tokens.NonInteractive
            | Tokens.ConfigFile + maybe(config_file_path)
            | Tokens.ForceEnglishOutput            
            ;

        public static SyntaxRule Source
            => verbatim();

        /// <summary>
        /// Defines a verbatim rule that correlates with a typical command line switch
        /// </summary>
        /// <param name="name">The switch name</param>
        /// <returns></returns>
        public static SyntaxRule @switch(string name)
            => verbatim($"{ascii.Minus}{name}");

        /// <summary>
        /// Defines a verbatim rule that correlates with a typical command line switch
        /// </summary>
        /// <param name="name">The switch name</param>
        /// <returns></returns>
        public static SyntaxRule @switch(Token name)
            => verbatim($"{ascii.Minus}{name}");

        public static SyntaxRule add_command
            => define(Tokens.add + packagePath + @switch(Tokens.Source) + folderBasePackageSource + maybe(+add_option));

        public static SyntaxRule init_command
            => define(Tokens.init + srcPackageSourcePath + dstPackageSourcePath + maybe(+init_option));

        public static SyntaxRule command
            => define(
                add_command
              | init_command
                );
    }


    [UT.TestClass, UT.TestCategory("lang/grammar")]
    public class GrammarTest
    {
        
        [UT.TestMethod]
        public void Test01()
        {
            var add = Nuget.add_command;
            var text = add.ToString();
            var result = add.FillTypedSlot(new SlotValue(Nuget.config_file_path, "test"));

        }

    }


}