using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TestAuth.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Usercode { get; set; }
        public int? RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Content> Contents { get; set; }
    }
}