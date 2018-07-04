//-------------------------------------------------------------------------------------------
// OSS developed by Chris Moore and licensed via MIT: https://opensource.org/licenses/MIT
// This license grants rights to merge, copy, distribute, sell or otherwise do with it 
// as you like. But please, for the love of Zeus, don't clutter it with regions.
//-------------------------------------------------------------------------------------------
namespace SqlT.Workflow
{
    public class SqlTransformationStep 
    {

        public SqlTransformationStep(string StepName, string Label, string Description)
        {
            this.StepName = StepName;
            this.Label = Label;
            this.Description = Description;
        }

        public string StepName { get; }
        public string Label { get; }
        public string Description { get; }

        public override string ToString()
            => StepName;
    }

    public class SqlTransformationSteps : HostedFieldList<SqlTransformationStep, SqlTransformationSteps>
    {
        public SqlTransformationStep SourceSelection = new SqlTransformationStep(
            nameof(SourceSelection), "Source Record Selection", "Step during which records are selected from the source");

        public SqlTransformationStep SourceTransformation = new SqlTransformationStep(
            nameof(SourceTransformation), "Source Record Transformation", "Step during which selected source records are projected onto target records");

        public SqlTransformationStep TargetEmission = new SqlTransformationStep(
            nameof(TargetEmission), "Target Record Emission", "Step during which transformed source records are emitted to the target sink");


    }
}