namespace ImageNet.Core.Filtering
{
    public interface IFiltering
    {
        ImageBuilder Add(params IFilter[] filter);
    }
}
