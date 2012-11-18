namespace ImageNet.Operations
{
    public interface IRotate
    {
        FluentImage Left(int degrees);
        FluentImage Left(RotateType rotateType);
        FluentImage Right(int degrees);
        FluentImage Right(RotateType rotateType);
    }
}
