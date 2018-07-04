//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System.ComponentModel;

    public enum CompatibilityLevel : byte
    {
       
        [Identifier("90")]
        Sql90 = 90,
        [Identifier("100")]
        Sql100 = 100,
        [Identifier("110")]
        Sql110 = 110,
        [Identifier("120")]
        Sql120 = 120,
        [Identifier("130")]
        Sql130 = 130,
        [Identifier("140")]
        Sql140 = 140
    }


}