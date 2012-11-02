namespace ImageNet.Core.Filtering
{
    using System.Collections.Generic;

    internal class FilterList : IFiltering
    {
        private readonly FluentImage builder;

        public FilterList(FluentImage builder)
        {
            this.builder = builder;
            this.Filters = new List<IFilter>();
        }

        internal List<IFilter> Filters { get; set; }

        public FluentImage Add(params IFilter[] filters)
        {
            this.Filters.AddRange(filters);
            return this.builder;
        }
    }
}
