//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using static metacore;

public static class ClrModelX
{
    /// <summary>
    /// Returns the defining system as determined by convention alignment
    /// </summary>
    /// <param name="a">The assembly to evaluate</param>
    /// <returns></returns>
    public static SystemIdentifier DefiningSystem(this ClrAssembly a)
        => a.ReflectedElement.DefiningSystem();

    /// <summary>
    /// Returns the defining system as determined by convention alignment
    /// </summary>
    /// <param name="t">A type defined in the assembly to evaluate</param>
    /// <returns></returns>
    public static SystemIdentifier DefiningSystem(this ClrType t)
        => t.ReflectedElement.DefiningSystem();

    public static Option<ClrMethodCallDescription>
        DescribeInvocation(this ClrInterfaceDescription i, string methodName, params (string paramName, string argValue)[] args)
    {
        var op = i.DescribeOperation(methodName).Require();
        var matches = from sp in op.Parameters
                      from arg in args
                      where arg.paramName == sp.Name
                      select (paramSpec: sp, paramValue: arg.argValue);

        var describedAgs = map(matches, m => new ClrMethodArgumentDescription(m.paramSpec, m.paramValue));
        return new ClrMethodCallDescription(op, describedAgs);
    }

    /// <summary>
    /// Produces the enum's structural specification
    /// </summary>
    /// <returns></returns>
    public static ClrStructureSpec.EnumSpec SpecifyStructure(this ClrEnum e)
        => new ClrStructureSpec.EnumSpec(
                Name: e.EnumName,
                AccessLevel: e.AccessLevel,
                UnderlyingType: e.GetLiteralType().GetReference(),
                Literals: e.Literals.Stream().Select(l => new
                    ClrStructureSpec.EnumLiteralSpec
                        (
                            DeclaringTypeName: e.EnumName,
                            Name: l.LiteralName,
                            LiteralValue: l.LiteralValue,
                            DeclarationOrder: (int?)null,
                            Documentation:
                                isNotBlank(l.Description)
                                ? new ClrStructureSpec.ElementDescription(l.Description)
                                : null
                        )),
                Documentation:
                    isNotBlank(e.Description)
                  ? new ClrStructureSpec.ElementDescription(e.Description)
                  : null
            );
}