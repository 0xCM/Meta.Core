//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Services
{
    using Meta.Core;
    using Meta.Models;
    using SqlT.Core;
    using SqlT.Models;   

    /// <summary>
    /// Defines SQL parser contract in terms of the model vocabulary
    /// </summary>
    public interface ISqlParser
    {
        /// <summary>
        /// Specifies the (configured) parser version
        /// </summary>
        SqlVersion ParserVersion { get; }

        /// <summary>
        /// Hydrates a <see cref="SqlSyntaxGraph"/> from a script
        /// </summary>
        /// <param name="script">The input script</param>
        /// <returns></returns>
        SqlSyntaxGraph ParseSyntaxGraph(ISqlScript script);

        /// <summary>
        /// Hydrates <see cref="IModel"/> specifications from a script
        /// </summary>
        /// <param name="script">The input script</param>
        /// <returns></returns>
        Lst<IModel> ParseSpecs(ISqlScript script);

        /// <summary>
        /// Segments batches from a <see cref="ISqlScript"/> into a <see cref="SqlBatchScript"/>
        /// </summary>
        /// <param name="script">The input script</param>
        /// <param name="parseSyntaxGraph">Specifies whether the syntax graph should also be parsed</param>
        /// <returns></returns>
        Option<SqlBatchScript> ParseBatches(ISqlScript script, bool parseSyntaxGraph = false);

        /// <summary>
        /// Specialized parser that extracts a body from a routine definition
        /// </summary>
        /// <param name="script">The input script</param>
        /// <returns></returns>
        Option<SqlParameterizedScript> ParseRoutineBody(ISqlScript script);

        /// <summary>
        /// Parses a type-specifid model element from a script
        /// </summary>
        /// <typeparam name="TSpec">The model element type</typeparam>
        /// <param name="script">The input script</param>
        /// <returns></returns>
        Option<TSpec> ParseSpec<TSpec>(ISqlScript script) 
            where TSpec : SqlModel<TSpec>;

        /// <summary>
        /// Parses an input list into a list of statements
        /// </summary>
        /// <param name="script">The input script</param>
        /// <returns></returns>
        Option<Lst<SqlStatementScript>> ParseStatements(ISqlScript script);

        /// <summary>
        /// Free-for-all random parsing
        /// </summary>
        /// <param name="script">The input script</param>
        /// <returns></returns>
        Option<object> ParseAny(ISqlScript script);                  
    }
}
