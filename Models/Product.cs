using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SzParag.Models
{
    public class Product
    {
        public long Id { get; set; }
        public long StripCode { get; set; }
        public string Name { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
        public int Category1Id { get; set; }
        public Category1 Category1 { get; set; }
        public int Category2Id { get; set; }
        public Category2 Category2 { get; set; }
        public int? Category3Id { get; set; }
        public Category3 Category3 { get; set; }
        public int? ProducerId { get; set; }
        public Producer Producer { get; set; }

    }
}
