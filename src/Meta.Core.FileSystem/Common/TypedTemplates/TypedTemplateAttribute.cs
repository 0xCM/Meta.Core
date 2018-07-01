//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System.Reflection;
using System.Text;
using System.IO;

using static metacore;

public class TypedTemplateAttribute : Attribute
{
    public TypedTemplateAttribute(Type Subject = null)
    {
        ElementRole = TypedTemplate.ElementRole.Pattern;
        this.Subject = Subject;
    }

    public TypedTemplateAttribute(TypedTemplate.ElementRole role)
    {
        ElementRole = role;
    }

    public Option<Type> Subject { get; }

    public TypedTemplate.ElementRole ElementRole { get; }
}

