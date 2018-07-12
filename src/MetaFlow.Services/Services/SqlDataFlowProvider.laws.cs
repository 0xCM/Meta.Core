//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{

    using System;

    using SqlT.Workflow;


    public interface ISqlDataFlowProvider
    {
        Option<ISqlDataFlow> CreateDataFlow(NodeLink Path, SystemUri Identifier);
        

        Option<ISqlDataFlow> FromType<F>(NodeLink Path);

    }


}


