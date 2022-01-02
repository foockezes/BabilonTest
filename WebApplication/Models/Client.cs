using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication
{
    public class Client
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string LastName { get; set; }
        public bool Identification { get; set; }
        public decimal Balance { get; set; } = 0;

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
