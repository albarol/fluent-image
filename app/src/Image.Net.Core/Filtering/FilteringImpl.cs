namespace ImageNet.Core.Filtering
{
    using System.Collections.Generic;

    internal class FilteringImpl : IFiltering
    {
        private readonly ImageBuilder builder;

        public FilteringImpl(ImageBuilder builder)
        {
            this.builder = builder;
            this.Filters = new List<IFilter>();
        }

        internal List<IFilter> Filters { get; set; }

        public ImageBuilder Add(params IFilter[] filters)
        {
            this.Filters.AddRange(filters);
            return this.builder;
        }
    }
}
