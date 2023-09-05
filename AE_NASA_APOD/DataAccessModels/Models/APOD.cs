using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessModels.Models
{
    public class APOD
    {
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "The{0} must be between {1} and {2} characters long.")]
        public string Copyright { get; set; }
        public DateTime DateTime { get; set; }
        public string Explanation { get; set; }
        public string HdUrl { get; set; }
        public string MediaType { get; set; }
        public string ServiceVersion { get; set; }

        [StringLength(1000, MinimumLength = 1, ErrorMessage = "The{0} must be between {1} and {2} characters long.")]
        public string Title { get; set; }
        public string Url { get; set; }
    }
}
