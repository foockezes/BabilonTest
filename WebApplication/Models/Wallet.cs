using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication
{
    public class Wallet
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public decimal Balance { get; set; }
        [Required]
        public Guid ClienId { get; set; }
        public virtual Client Client { get; set; }
    }
}
