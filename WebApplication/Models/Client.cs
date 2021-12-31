using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

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
        [Required]
        public int AccountCode { get; set; }

        
        public virtual ICollection<Wallet> Wallets { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
