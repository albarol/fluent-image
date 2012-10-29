namespace ImageNet.Core.Operations
{
    public interface IFlip
    {
        ImageBuilder In(FlipType flipType);
    }
}
