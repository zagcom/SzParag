using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SzParag.Models
{
    public class Document
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public ICollection<Transaction> Transactions { get; set; }

    }
}