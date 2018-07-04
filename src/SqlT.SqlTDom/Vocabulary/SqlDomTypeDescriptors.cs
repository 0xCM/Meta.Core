//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Dom
{
    using System;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Types.SqlDom;

    using static metacore;

    using TSql = Microsoft.SqlServer.TransactSql.ScriptDom;


    public sealed class SqlDomTypeDescriptors : TypedItemList<SqlDomTypeDescriptors, SqlDomTypeDescriptor>
    {
        public static implicit operator SqlDomTypeDescriptors(SqlDomTypeDescriptor[] descriptors)
            => Create(descriptors);

        static IReadOnlySet<Type> InfrastructureTypes { get; }
            = roset(typeof(TSql.TSqlParser),
                typeof(TSql.TSqlFragmentVisitor),
                typeof(TSql.TSqlAuditEventGroupHelper),
                typeof(TSql.TSqlAuditEventTypeHelper),
                typeof(TSql.TSqlTriggerEventGroupHelper),
                typeof(TSql.TSqlTriggerEventTypeHelper),
                typeof(TSql.SqlScriptGenerator),
                typeof(TSql.SqlScriptGeneratorOptions)
                );

        static bool IsInfrastructureType(Type type)
            => InfrastructureTypes.Contains(type)
            || InfrastructureTypes.Any(t => type.IsSubclassOf(t));


        static ElementKind AssignElementType(ClrType type)
        {
            switch (type)
            {
                case ClrEnum e:
                    return ElementKind.Enum;
                case ClrClass c:
                    if (c.IsSublcassOf<TSql.TSqlStatement>())
                    {
                        if (c.Name.StartsWith("Alter"))
                            return ElementKind.AlterStatement;
                        else if (c.Name.StartsWith("Create"))
                            return ElementKind.CreateStatement;
                        else if (c.Name.StartsWith("Drop"))
                            return ElementKind.DropStatement;
                        else
                            return ElementKind.BasicStatement;
                    }

                    if (c.IsSublcassOf<TSql.Literal>())
                        return ElementKind.Literal;

                    if (c.IsSublcassOf<TSql.ScalarExpression>())
                        return ElementKind.ScalarExpression;

                    if (IsInfrastructureType(c))
                        return ElementKind.Infrastructure;

                    if (c.Name.EndsWith("Reference"))
                        return ElementKind.ElementReference;

                    if (c.Name.EndsWith("Expression"))
                        return ElementKind.NonscalarExpression;

                    if (c.Name.EndsWith("Option"))
                        return ElementKind.Option;

                    if (c.Name.EndsWith("Definition") || c.Name.EndsWith("Specification"))
                        return ElementKind.Definition;

                    if (c.Name.EndsWith("Predicate"))
                        return ElementKind.Predicate;

                    if (c.Name.EndsWith("Clause"))
                        return ElementKind.Clause;

                    if (c.Name.EndsWith("Action"))
                        return ElementKind.Action;

                    if (c.Name.EndsWith("Action"))
                        return ElementKind.Action;

                    if (c.Name.EndsWith("Identifier") || c.Name.EndsWith("Name"))
                        return ElementKind.Identifier;

                    if (c.Name.EndsWith("Type"))
                        return ElementKind.Classifier;

                    if (c.Name.EndsWith("80"))
                        return ElementKind.CompatibilityElement;

                    return ElementKind.None;

                default:
                    return ElementKind.None;
            }

        }

        static SqlDomTypeDescriptor CreateDescriptor(ClrType type)
            => new SqlDomTypeDescriptor(type, AssignElementType(type));

        static IEnumerable<SqlDomTypeDescriptor> SyntheticDescriptors
            => stream(new SqlDomTypeDescriptor(ClrType.Get<SqlDomPrimitive>(), ElementKind.Enum));

        public static SqlDomTypeDescriptors FromAssembly(ClrAssembly a)
            => Create(union(a.NamedPublicTypes.Select(t => CreateDescriptor(t)), SyntheticDescriptors));


        IReadOnlyDictionary<string, SqlDomTypeDescriptor> index;

        public SqlDomTypeDescriptors()
        {

        }

        protected override void Filled()
        {
            index = this.ToDictionary(x => x.SqlDomType.Name);
        }

        public SqlDomTypeDescriptor FindByDescribedType(ClrType type)
            => index[type.Name];



    }



}