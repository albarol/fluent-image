namespace ImageNet.Core.Operations
{
    public interface IRotate
    {
        ImageBuilder Left(int degrees);
        ImageBuilder Left(RotateType rotateType);
        ImageBuilder Right(int degrees);
        ImageBuilder Right(RotateType rotateType);
    }
}
