//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
using System;
using System.Linq;

using static metacore;

public static partial class ClrStructureSpec
{

    /// <summary>
    /// Characterizes a using statement
    /// </summary>
    public class UsingSpec : ValueObject<UsingSpec>
    {
        public static implicit operator UsingSpec(string NamespaceName)
            => new UsingSpec(new ClrNamespaceName(NamespaceName));

        public static implicit operator UsingSpec(ClrNamespaceName NamespaceName)
            => new UsingSpec(NamespaceName);

        public UsingSpec(IClrElementName SubjectName, string AliasName, bool IsStatic, CodeDocumentationSpec Documentation)
        {
            this.SubjectName = SubjectName;
            this.IsStatic = IsStatic;
            this.Documentation = Documentation;
            this.AliasName = AliasName;
        }

        public UsingSpec(ClrNamespaceName NamespaceName)
        {
            this.IsStatic = false;
            this.SubjectName = NamespaceName;
            this.Documentation = null;
            this.AliasName = String.Empty;
        }

        public UsingSpec(IClrTypeName TypeName)
        {
            this.IsStatic = true;
            this.SubjectName = TypeName;
            this.Documentation = null;
            this.AliasName = String.Empty;
        }

        public UsingSpec(string AliasName, ClrNamespaceName NamespaceName)
        {
            this.AliasName = AliasName;
            this.IsStatic = false;
            this.SubjectName = NamespaceName;
            this.Documentation = null;
        }

        public UsingSpec(string AliasName, IClrTypeName TypeName)
        {
            this.AliasName = AliasName;
            this.IsStatic = true;
            this.SubjectName = TypeName;
            this.Documentation = null;
        }

        public IClrElementName SubjectName { get; }

        public string AliasName { get; }

        public bool IsStatic { get; }

        public Option<CodeDocumentationSpec> Documentation { get; }

        public bool IsAliased 
            => isNotBlank(AliasName);

        public override string ToString()
            => IsStatic ? $"using static {SubjectName};" : $"using {SubjectName};";
    }
}