namespace ImageNet.Filtering
{
    public class Range<T>
    {
        public Range(T min, T max)
        {
            this.Min = min;
            this.Max = max;
        } 
        
        public T Min { get; set; }
        public T Max { get; set; }
    }
}
