namespace ImageNet.Core.Operations
{
    public interface IFlip
    {
        FluentImage In(FlipType flipType);
    }
}
