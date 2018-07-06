//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dac
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using SqlT.Models;

    using static SqlT.Syntax.SqlSyntax;
    using static metacore;

    using SqlDac = Microsoft.SqlServer.Dac;
    using DacM = Microsoft.SqlServer.Dac.Model;
    using DacX = Microsoft.SqlServer.Dac.Extensions.Prototype;

    public static class SqlDacX
    {
        public static SqlDacMessageContent MessageContent(this SqlDac.DacMessage Src)
            => new SqlDacMessageContent(Src.MessageType.ToString(), Src.Prefix, Src.Number, Src.Message);

        public static IReadOnlyList<T> GetDacObjects<T>(this DacX.TSqlTypedModel model)
            where T : DacX.ISqlModelElement => rolist(model.GetObjects<T>(DacM.DacQueryScopes.Default));

        public static IEnumerable<SqlElementDescriptor> GetSqlElementLineage(this DacM.TSqlObject subject)
        {
            if (subject != null)
            {

                var subjectType = SqlElementTypes.GetLookup().Find(subject.ObjectType.Name);
                var subjectName = subject.Name.FormatName();
                yield return new SqlElementDescriptor(subjectType, subjectName);

                var parent = subject.GetParent();
                if (parent != null)
                    foreach (var ancestor in GetSqlElementLineage(parent))
                        yield return ancestor;
            }            
        }

        public static IApplicationMessage ToAppMessage(this SqlDac.DacMessage message, object o = null)
        {
            var content = concat(message.MessageContent().ToString(), o?.ToString() ?? string.Empty);
            if (message.MessageType == SqlDac.DacMessageType.Error)
                return error(content);
            else if (message.MessageType == SqlDac.DacMessageType.Warning)
                return warn(content);
            else
                return inform(content);
        }

        public static IReadOnlyList<string> FormatNames(this DacX.ISqlColumnSource source)
            => source.Columns.Map(x => x.Name.SpecifyObjectName().UnqualifiedName);

        public static string FormatLiteralValue(this DacX.TSqlExtendedProperty subject)
        {
            var value = subject.Value;
            if (subject.Value.StartsWith("N'") && subject.Value.EndsWith("'"))
            {
                value = (value.Substring(2, subject.Value.Length - 3));
            }
            else if (value.StartsWith("'") && subject.Value.EndsWith("'"))
            {
                value = (subject.Value.Substring(1, subject.Value.Length - 1));
            }
            return value;
        }

        /// <summary>
        /// Gets the dac-specific package options
        /// </summary>
        /// <param name="package">The package model</param>
        /// <returns></returns>
        public static DacM.TSqlModelOptions GetDacOptions(this SqlPackage package)
            => new DacM.TSqlModelOptions
            {
                Containment 
                    = package.DatabaseOptions.containment_type.map(x => x, 
                        () => containment_types.NONE).ToDac(),

                RecoveryMode 
                    = package.DatabaseOptions.recovery_model.map(x => x, 
                        () => recovery_models.SIMPLE).ToDac(),

                ServiceBrokerOption 
                    = package.DatabaseOptions.service_broker_option.map(x => x, 
                        () => service_broker_options.DISABLE_BROKER).ToDac(),

                DbScopedConfigParameterSniffing 
                    = package.DatabaseOptions.parameter_sniffing.map(x => x.IsOn, 
                        () => (bool?)null)
            };
    }
}
