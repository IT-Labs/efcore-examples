using System;

namespace Core
{
    public class Meta
    {
        public int TotalCount { get; set; }

        public int CurrentPage { get; set; } = 1;

        public int PageSize { get; set; } = 10;

        public bool All { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    }
}
