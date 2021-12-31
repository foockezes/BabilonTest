using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TestAuth.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="Не указан Email")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Не указан Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
