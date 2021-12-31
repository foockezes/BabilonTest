using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public decimal Sum { get; set; }
        public Guid WalletId { get; set; }
        public virtual Client Client { get; set; }
    }
}
