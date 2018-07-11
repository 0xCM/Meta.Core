//-------------------------------------------------------------------------------------------
// MetaCore
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
class JsonEntity 
{

    public JsonEntity()
    {

    }

    public JsonEntity(string EntityId, string TypeUri, string Body)
    {
        this.EntityId = EntityId;
        this.EntityType = TypeUri;
        this.Body = Body;
    }

    public string EntityId { get; set; }

    public string EntityType { get; set; }

    public string Body { get; set; }
}
