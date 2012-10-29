namespace ImageNet.Core.Filtering.Edges
{
    public interface IEdgeFilters
    {
        IFilter Quick();
        IFilter Homogenity(byte threshold);
        IFilter Enhance(byte threshold);
        IFilter Difference(byte threshold);
        IFilter DetectVertical();
        IFilter DetectHorizontal();
    }
}
