namespace Dsms.Repository.Models.Request
{
    public class BaseRequest
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Keywords { get; set; }
    }
}
