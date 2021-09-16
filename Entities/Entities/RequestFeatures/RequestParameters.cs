namespace Entities.RequestFeatures
{
    public abstract class RequestParameters
    {
        const int maxPageSize = 4;
        public int PageNumber { get; set; } = 1;

        private int pageSize = 2;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = (value > maxPageSize) ? maxPageSize : value; }
        }

        public string OrderBy { get; set; }

        public string Fields { get; set; }
    }
}
