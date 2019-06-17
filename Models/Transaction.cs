using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SzParag.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Memo { get; set; }
        public decimal? Income { get; set; }
        public decimal? Outcome { get; set; }
        public string Category1 { get; set; }
        public string Category2 { get; set; }
        public string Category3 { get; set; }

    }
}
