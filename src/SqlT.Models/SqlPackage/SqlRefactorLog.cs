/*
 <?xml version="1.0" encoding="utf-8"?>
<Operations Version="1.0" xmlns="http://schemas.microsoft.com/sqlserver/dac/Serialization/2012/02">
  <Operation Name="Rename Refactor" Key="e5077961-8187-441b-aa40-cb8c3b245149" ChangeDateTime="11/21/2017 23:47:40">
    <Property Name="ElementName" Value="[OS].[ActiveCentersMaster].[IXNK_ActiveCentersMaster]" />
    <Property Name="ElementType" Value="SqlIndex" />
    <Property Name="ParentElementName" Value="[OS].[ActiveCentersMaster]" />
    <Property Name="ParentElementType" Value="SqlTable" />
    <Property Name="NewName" Value="[NKIX_ActiveCentersMaster]" />
  </Operation>
  <Operation Name="Rename Refactor" Key="7d2200cb-07f5-4eab-8280-f9777559888f" ChangeDateTime="11/21/2017 23:47:58">
    <Property Name="ElementName" Value="[OS].[ActiveCentersMaster].[IX_ActiveCentersMaster_ArchiveKey]" />
    <Property Name="ElementType" Value="SqlIndex" />
    <Property Name="ParentElementName" Value="[OS].[ActiveCentersMaster]" />
    <Property Name="ParentElementType" Value="SqlTable" />
    <Property Name="NewName" Value="[AKIX_ActiveCentersMaster]" />
  </Operation>
  <Operation Name="Move Schema" Key="a1d4444d-9ecf-4910-be4d-6950b814608c" ChangeDateTime="11/21/2017 23:49:36">
    <Property Name="ElementName" Value="[OS].[ActiveCentersMaster]" />
    <Property Name="ElementType" Value="SqlTable" />
    <Property Name="NewSchema" Value="XY" />
    <Property Name="IsNewSchemaExternal" Value="False" />
  </Operation>
</Operations>
*/
namespace SqlT.Models
{
    using SqlT.Core;
    
    public enum SqlRefactorKind
    {
        None = 0,
        Rename,
        MoveSchema
    }


    public interface ISqlRefactorStep
    {

    }

    public interface ISqlRefactorStep<N> : ISqlRefactorStep
        where N : SqlName<N>, new()
    {
        N RefactorSubject { get; }
    }

    

    public class SqlRefactorRenameStep<N>
    {
        public SqlRefactorRenameStep(N OldName, N NewName)
        {

            this.OldName = OldName;
            this.NewName = NewName;
        }

        public N OldName { get; }
        public N NewName { get; }

        public override string ToString()
            => $"{OldName} => {NewName}";
    }

    public abstract class SqlRefactorOp
    {

        protected SqlRefactorOp(SqlName ElementName, string ElementType)
        {
            this.ElementName = ElementName;
            this.ElementType = ElementType;
        }

        public SqlName ElementName { get; }
        
        /// <summary>
        /// <see cref="Syntax.SqlElementTypeNames"/>
        /// </summary>
        public string ElementType { get; }

    }


    public class SqlRefactorRename : SqlRefactorOp
    {
        public SqlRefactorRename(SqlName ParentElementName, string ParentElementType, SqlName ElementName, string ElementType, SqlName NewName)
            : base(ElementName, ElementType)
        {

            this.ParentElementName = ParentElementName;
            this.ParentElementType = ParentElementType;
            this.NewName = NewName;

        }


        public SqlName ParentElementName { get; }

        public string ParentElementType { get; }

        public SqlName NewName { get; }
    }


    public class SqlRefactorLogEntry
    {

    }

    public class SqlRefactorLog
    {
        public string XmlSchema { get; }
            = "http://schemas.microsoft.com/sqlserver/dac/Serialization/2012/02";
    }
}
