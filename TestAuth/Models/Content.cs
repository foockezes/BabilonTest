using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestAuth.Models
{
    public class Content
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public decimal Cost { get; set; }
        public DateTime Date { get; set; }
        public virtual User User { get; set; }
    }
}
