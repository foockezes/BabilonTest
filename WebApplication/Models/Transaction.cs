using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public decimal Sum { get; set; }
        public Guid ClientId { get; set; }
        public virtual Client Client { get; set; }
    }
}
