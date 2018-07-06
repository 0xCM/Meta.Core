//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SqlT.Core;
    using SqlT.SqlSystem;
    using SqlT.Services;


    using static metacore;

    using ClrModel;
    using static ClrStructureSpec;
    using static ClrBehaviorSpec;

    static class FieldListSpecifier
    {


        static bool IsTableTypeList(this SqlFieldListDescription description)
            => isNotBlank(description.TableType);

        static SqlColumnIdentifier IndentifierColumn(this SqlFieldListDescription list)
            => new SqlColumnIdentifier(list.IdentifierColumn);

        /// <summary>
        /// Pulls the data from which field list items will be constructed
        /// </summary>
        /// <param name="gp">The generation profile</param>
        /// <param name="description">The field list description</param>
        /// <param name="fieldColumns"></param>
        /// <returns></returns>
        static Option<SqlDataFrame> FieldListData(this SqlFieldListGenerationProfile gp, 
            SqlFieldListDescription description, IReadOnlyList<SqlColumnName> fieldColumns)
        {
            var broker = new SqlConnectionString(gp.ConnectionString).GetClientBroker();
            return description.RowSourceType == GenerationRowSourceKind.View ?
                    broker.View(SqlViewName.Parse(description.RowSource)).Select(fieldColumns)
                            : broker.Table(SqlTableName.Parse(description.RowSource)).Select(fieldColumns);
        }

        /// <summary>
        /// Specifies a field list's name
        /// </summary>
        /// <param name="gp">The generation profile</param>
        /// <param name="description">The field list description</param>
        /// <returns></returns>
        static ClrClassName SpecifyListName(this SqlFieldListGenerationProfile gp,
            SqlFieldListDescription description)
                => new ClrClassName(description.ListName);

        /// <summary>
        /// Specifies the name of a field list's item item type
        /// </summary>
        /// <param name="gp">The generation profile</param>
        /// <param name="description">The field list description</param>
        /// <returns></returns>
        static ClrClassName SpecifyFieldTypeName(this SqlFieldListGenerationProfile gp,
            SqlFieldListDescription description)
                => isBlank(description.TypedIdentifierType) ?
                    new ClrClassName(SqlTypeName.Parse(description.TableType).UnqualifiedName)
                    : new ClrClassName(description.TypedIdentifierType);

        /// <summary>
        /// Specifies a field list's base type
        /// </summary>
        /// <param name="gp">The generation profile</param>
        /// <param name="description">The field list description</param>
        /// <returns></returns>
        static ClrTypeClosure SpecifyListBase(this SqlFieldListGenerationProfile gp,
            SqlFieldListDescription description)
                => new ClrTypeClosure(
                    ClrClassName.Define("TypedItemList"),
                        new TypeArgument(new TypeParameter("THost", 0), gp.SpecifyListName(description)),
                        new TypeArgument(new TypeParameter("TItem", 1), gp.SpecifyFieldTypeName(description))
                    );

        /// <summary>
        /// Specifies a field whose instances can be hydryated implicitly from a text identifier
        /// </summary>
        /// <param name="DeclaringTypeName"></param>
        /// <param name="FieldType"></param>
        /// <param name="subject"></param>
        /// <returns></returns>
        static FieldSpec SpecifyTypedIdentifierField(this ClrClassName DeclaringTypeName, ClrClassName FieldType, NamedValue subject)
            => new FieldSpec
            (
                 DeclaringTypeName,
                 Name: subject.Name,
                 FieldType: FieldType.CreateReference(),
                 AccessLevel: ClrAccessKind.Public,
                 IsStatic: true,
                 IsReadOnly: true,
                 Initializer: new LiteralValueSpec(toString(subject.Value))
            );

        /// <summary>
        /// Specifies the fields of a field list
        /// </summary>
        /// <param name="gp">The generation profile</param>
        /// <param name="description">The field list description</param>
        /// <param name="fieldColumns"></param>
        /// <returns></returns>
        static IEnumerable<FieldSpec> SpecifyListFields(this SqlFieldListGenerationProfile gp, 
            SqlFieldListDescription description, IReadOnlyList<SqlColumnName> fieldColumns)
        {
            var declaringType = gp.SpecifyListName(description);
            var fieldType = gp.SpecifyFieldTypeName(description);
            var frameOption = gp.FieldListData(description, fieldColumns);
            if (!frameOption)
                SystemConsole.Get().Write(frameOption.Message);
            else
            {
                var frame = frameOption.Require();
                var idColPos = frame.ColumnIndex(description.IndentifierColumn()) ?? 0;
                var idValColPos = isNotBlank(description.IdentifierValueColumn)
                        ? frame.ColumnIndex(new SqlColumnIdentifier(description.IdentifierValueColumn))
                        : null;

                foreach (var row in frame.Rows)
                {

                    var values = mapi(row, (i, v) => new NamedValue(frame.Columns[i], v));
                    var identifer = new ClrFieldName(toString(values[idColPos].Value));

                    if (description.IsTableTypeList())
                        yield return declaringType.SpecifyField
                            (
                                FieldName: identifer,
                                FieldType: fieldType,
                                Initializer: fieldType.SpecifyConstructorInvocation(values)
                            );
                    else
                    {
                        var idVal = values[idValColPos.Value];
                        var fieldValue = new NamedValue(identifer, idVal.Value);
                        yield return declaringType.SpecifyTypedIdentifierField(fieldType, fieldValue);
                    }
                }
            }
        }


        static ClassSpec SpecifyTypeTableFieldList(this  SqlFieldListGenerationProfile gp, 
            SqlFieldListDescription description, IReadOnlyList<SqlColumnName> fieldColumns)
        {
            var spec = new ClassSpec
                (
                    Name: gp.SpecifyListName(description),
                    Documentation: null,
                    AccessLevel: ClrAccessKind.Public,
                    BaseTypes: roitems(gp.SpecifyListBase(description)),
                    Members: rolist(gp.SpecifyListFields(description, fieldColumns))
                );
            return spec;
        }

        public static IEnumerable<ClassSpec> SpecifyFieldLists(this SqlFieldListGenerationProfile gp,
            ISystemViewProvider svp)
        {

            foreach (var l in gp.FieldLists)
            {
                if (l.IsTableTypeList())
                {
                    var ftn = SqlTypeName.Parse(l.TableType);
                    var types = svp.GetVirtualView<vTableType>().ToDictionary(x => x.TypeName);
                    if (types.Keys.Contains(ftn))
                        yield return gp.SpecifyTypeTableFieldList(l, map(types[ftn].Columns, c => new SqlColumnName(c.Name)));
                }
                else
                {
                    if (l.RowSourceType == GenerationRowSourceKind.View)
                    {
                        var views = svp.GetVirtualView<vView>().ToDictionary(x => x.ViewName);
                        var ftn = SqlViewName.Parse(l.RowSource);
                        if (views.Keys.Contains(ftn))
                            yield return gp.SpecifyTypeTableFieldList(l, map(views[ftn].Columns, c => new SqlColumnName(c.Name)));
                    }
                    else
                    {
                        var tables = svp.GetVirtualView<vTable>().ToDictionary(x => x.TableName);
                        var ftn = SqlTableName.Parse(l.RowSource);
                        if (tables.Keys.Contains(ftn))
                            yield return gp.SpecifyTypeTableFieldList(l, map(tables[ftn].Columns, c => new SqlColumnName(c.Name)));
                    }
                }
            }

        }
    }

}