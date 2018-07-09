//-------------------------------------------------------------------------------------------
// SqlT
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace SqlT.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    using SqlT.Core;
    using static SqlT.Syntax.SqlSyntax;

    using static metacore;

    public static class SqlPackageExtensions
    {
        static readonly XNamespace xNS = "http://schemas.microsoft.com/developer/msbuild/2003";

        static XElement xElement(string name, params object[] content)
            => new XElement(xNS + name, content);

        static XAttribute xAttrib(string name, object value)
            => new XAttribute(name, value);

        static XElement PropertyGroup(IEnumerable<XElement> properties)
            => new XElement(xNS + "PropertyGroup", properties);

        static XElement ItemGroup(IEnumerable<XElement> items)
            => new XElement(xNS + "ItemGroup", items);

        static XElement SqlCmdVariableItem(sql_cmd_variable variable)
            => xElement("SqlCmdVariable",
                xAttrib("Include", variable.Name),
                xElement("Value", variable.Value)
                );

        internal static IEnumerable<XElement> GetPropertyElements(this SqlPackageProfile p)
        {
            yield return xElement(nameof(p.TargetDatabaseName), $"{p.TargetDatabaseName}");

            yield return xElement(nameof(p.DeployScriptFileName), $"{p.DeployScriptFileName}");

            yield return xElement(nameof(p.TargetConnectionString), $"{p.TargetConnectionString}");

            if (p.IncludeCompositeObjects.HasValue)
                yield return xElement(nameof(p.IncludeCompositeObjects), $"{p.IncludeCompositeObjects}");

            if (p.BlockOnPossibleDataLoss.HasValue)
                yield return xElement(nameof(p.BlockOnPossibleDataLoss), $"{p.BlockOnPossibleDataLoss}");

            if (p.GenerateSmartDefaults.HasValue)
                yield return xElement(nameof(p.GenerateSmartDefaults), $"{p.GenerateSmartDefaults}");

            if (p.DropObjectsNotInSource.HasValue)
                yield return xElement(nameof(p.DropObjectsNotInSource), $"{p.DropObjectsNotInSource}");

            if (p.CreateNewDatabase.HasValue)
                yield return xElement(nameof(p.CreateNewDatabase), $"{p.CreateNewDatabase}");

            if (isNotBlank(p.AdditionalDeploymentContributorArguments))
                yield return xElement(nameof(p.AdditionalDeploymentContributorArguments), $"{p.AdditionalDeploymentContributorArguments}");

            if (p.DropConstraintsNotInSource.HasValue)
                yield return xElement(nameof(p.DropConstraintsNotInSource), $"{p.DropConstraintsNotInSource}");

            if (p.DropDmlTriggersNotInSource.HasValue)
                yield return xElement(nameof(p.DropDmlTriggersNotInSource), $"{p.DropDmlTriggersNotInSource}");

            if (p.DropExtendedPropertiesNotInSource.HasValue)
                yield return xElement(nameof(p.DropExtendedPropertiesNotInSource), $"{p.DropExtendedPropertiesNotInSource}");

            if (p.DropIndexesNotInSource.HasValue)
                yield return xElement(nameof(p.DropIndexesNotInSource), $"{p.DropIndexesNotInSource}");

            if (p.ScriptDatabaseOptions.HasValue)
                yield return xElement(nameof(p.ScriptDatabaseOptions), $"{p.ScriptDatabaseOptions}");

            if (p.DropRoleMembersNotInSource.HasValue)
                yield return xElement(nameof(p.DropRoleMembersNotInSource), $"{p.DropRoleMembersNotInSource}");

            if (p.DropPermissionsNotInSource.HasValue)
                yield return xElement(nameof(p.DropPermissionsNotInSource), $"{p.DropPermissionsNotInSource}");

            if (p.DropStatisticsNotInSource.HasValue)
                yield return xElement(nameof(p.DropStatisticsNotInSource), $"{p.DropStatisticsNotInSource}");

            if (p.IgnoreAnsiNulls.HasValue)
                yield return xElement(nameof(p.IgnoreAnsiNulls), $"{p.IgnoreAnsiNulls}");
        }

        public static string ToProfileXml(this SqlPackageProfile p)
        {
            var properties = p.GetPropertyElements().ToList();
            var items = map(p.SqlCmdVariables, SqlCmdVariableItem);

            var project = new XElement(xNS + "Project",
                new XAttribute("ToolsVersion", "15.0"),
                new XAttribute("xmlns", xNS),
                PropertyGroup(properties),
                ItemGroup(items)
                );
            var doc = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"), project);

            return doc.ToString();
        }
    }
}