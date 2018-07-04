//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Syntax
{
    using System;
    using Meta.Syntax;

    using static metacore;
    using static xprop_level;

    using sxc = contracts;
    using sx = SqlSyntax;
    

    partial class SqlSyntax
    {
        public class xprop_type   //: model<xprop_type>
        {
               
            public xprop_type()
            {
            }

            public xprop_type(xprop_level Level, IKeyword designator)
                : this()
            {
                this.Level = Level;
                this.LevelTypeName = designator?.KeywordName ?? string.Empty;
            }

            protected xprop_type(xprop_level Level, IKeyphrase designator)
                : this()
            {
                this.Level = Level;
                this.LevelTypeName = designator?.ToString() ?? string.Empty;
            }

            public xprop_level Level { get; }

            public string LevelTypeName { get; }

            public override string ToString()
                => $"{Level} {LevelTypeName}";
        }

        public sealed class xprop_level0_type : xprop_type
        {
            public xprop_type Database { get; }

            public xprop_level0_type Assembly { get; }

            public xprop_level0_type Contract { get; }

            public xprop_level0_type EventNotification { get; }

            public xprop_level0_type FileGroup { get; }

            public xprop_level0_type MessageType { get; }

            public xprop_level0_type PartitionFunction { get; }

            public xprop_level0_type PartitionScheme { get; }

            public xprop_level0_type RemoteServiceBinding { get; }

            public xprop_level0_type Route { get; }

            public xprop_level0_type PlanGuide { get; }

            public xprop_level0_type Schema { get; }

            public xprop_level0_type Service { get; }

            public xprop_level0_type User { get; }

            public xprop_level0_type DdlTrigger { get; }

            public xprop_level0_type()
            {
                Database = new xprop_type(Undefined, sx.DATABASE);
                Assembly = new xprop_level0_type(Level0, sx.ASSEMBLY);
                Contract = new xprop_level0_type(Level0, sx.CONTRACT);
                EventNotification = new xprop_level0_type(Level0, sx.EVENTNOTIFICATION);
                FileGroup = new xprop_level0_type(Level0, sx.FILEGROUP);
                MessageType = new xprop_level0_type(Level0, sx.MESSAGETYPE);
                PartitionFunction = new xprop_level0_type(Level0, sx.PARTITIONFUNCTION);
                PartitionScheme = new xprop_level0_type(Level0, sx.PARTITIONSCHEME);
                RemoteServiceBinding = new xprop_level0_type(Level0, sx.REMOTESERVICEBINDING);
                Route = new xprop_level0_type(Level0, sx.ROUTE);
                PlanGuide = new xprop_level0_type(Level0, sx.PLANGUIDE);
                Schema = new xprop_level0_type(Level0, sx.SCHEMA);
                Service = new xprop_level0_type(Level0, sx.SERVICE);
                User = new xprop_level0_type(Level0, sx.USER);
                DdlTrigger = new xprop_level0_type(Level0, sx.TRIGGER);

            }

            xprop_level0_type(xprop_level Level, IKeyphrase designator)
                : base(Level, designator)
            {
            }

            xprop_level0_type(xprop_level Level, IKeyword designator)
                : base(Level,  designator)
            {
            }
        }

        public sealed class xprop_level1_type : xprop_type
        {
            public xprop_level1_type Aggregate { get; }

            public xprop_level1_type Default { get; }

            public xprop_level1_type Function { get; }

            public xprop_level1_type LogicalFileName { get; }

            public xprop_level1_type Procedure { get; }

            public xprop_level1_type Queue { get; }

            public xprop_level1_type Sequence { get; }

            public xprop_level1_type Synonym { get; }

            public xprop_level1_type Table { get; }

            public xprop_level1_type Type { get; }

            public xprop_level1_type TableType { get; }

            public xprop_level1_type View { get;}

            public xprop_level1_type XmlSchemaCollection { get; }

            public xprop_level1_type()
            {
                Aggregate = new xprop_level1_type(Level1, sx.AGGREGATE);
                Default = new xprop_level1_type(Level1, sx.DEFAULT);
                Function = new xprop_level1_type(Level1, sx.FUNCTION);
                LogicalFileName = new xprop_level1_type(Level1, sx.LOGICAL_FILE_NAME);
                Procedure = new xprop_level1_type(Level1, sx.PROCEDURE);
                Queue = new xprop_level1_type(Level1, sx.QUEUE);
                Sequence = new xprop_level1_type(Level1, sx.SEQUENCE);
                Synonym = new xprop_level1_type(Level1, sx.SYNONYM);
                Table = new xprop_level1_type(Level1, sx.TABLE);
                Type = new xprop_level1_type(Level1, sx.TYPE);
                TableType = new xprop_level1_type(Level1, sx.TYPE);
                View = new xprop_level1_type(Level1, sx.VIEW);
                XmlSchemaCollection = new xprop_level1_type(Level1, sx.XMLSCHEMACOLLECTION);

            }
             xprop_level1_type(xprop_level Level, IKeyphrase designator)
                : base(Level, designator)
            {

            }
            xprop_level1_type(xprop_level Level, IKeyword designator)
                : base(Level, designator)
            {
            }

        }

        public sealed class xprop_level2_type : xprop_type
        {
            public xprop_type Column { get; }

            public xprop_type Constraint { get; }

            public xprop_type Index { get; }

            public xprop_type Parameter { get; }

            public xprop_type DmlTrigger { get; }

            public xprop_level2_type()
            {
                Column = new xprop_level2_type(Level2, sx.COLUMN);
                Constraint = new xprop_level2_type(Level2, sx.CONSTRAINT);
                Index = new xprop_level2_type(Level2, sx.INDEX);
                Parameter = new xprop_level2_type(Level2, sx.PARAMETER);
                DmlTrigger = new xprop_level2_type(Level2, sx.TRIGGER);

            }

            xprop_level2_type(xprop_level Level, IKeyword designator)
                : base(Level, designator)
            {
            }

        }
    }
}