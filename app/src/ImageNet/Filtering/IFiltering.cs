namespace ImageNet.Filtering
{
    public interface IFiltering
    {
        FluentImage Add(params IFilter[] filter);
    }
}
