using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessQueryParameters
{
    public class APODQueryParameters
    {
        public string Copyright { get; set; }

        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string? SortBy { get; set; }

        public string? SortOrder { get; set; }

        public int PageSize { get; set; } = 3;
        public int PageNumber { get; set; } = 1;
    }
}
