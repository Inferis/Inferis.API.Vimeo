using System.Collections.Generic;

namespace Inferis.API.Vimeo.Advanced.Responses
{
    public class Page<TItem> : List<TItem>
    {
        public Page(int pageNum, int perPage, int total)
        {
            PageNum = pageNum;
            PerPage = perPage;
            Total = total;
        }

        public int OnThisPage { get { return Count; } }
        public int PageNum { get; private set; }
        public int PerPage { get; private set; }
        public int Total { get; private set; }
    }
}
