using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public class PageRequest : IPageRequest
    {
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public bool All { get; set; }
    }
}
