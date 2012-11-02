namespace ImageNet.Core.Filtering
{
    public interface IFiltering
    {
        FluentImage Add(params IFilter[] filter);
    }
}
