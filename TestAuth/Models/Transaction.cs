using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAuth.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public decimal Sum { get; set; }
        public Guid WalletId { get; set; }
    }
}
