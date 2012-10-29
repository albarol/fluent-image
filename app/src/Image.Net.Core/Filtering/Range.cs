namespace ImageNet.Core.Filtering
{
    public class Range<T>
    {
        public Range(T min, T max)
        {
            Min = min;
            Max = max;
        } 
        
        public T Min { get; set; }
        public T Max { get; set; }
    }
}
