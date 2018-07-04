namespace SqlT.Core
{
    /// <summary>
    /// See: https://msdn.microsoft.com/en-us/library/ms173760.aspx
    /// </summary>
    public enum SqlIndexType : byte
    {
        Heap = 0,
        Clustered = 1,
        Nonclustered = 2,
        XML = 3,
        Spatial = 4,
        ClusteredColumnStore = 5,
        NonclusteredColumnStore = 6,
        NonclusteredHash = 7
    }
}
