using PaymentAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAPI.Domain.DTOs
{
    public class UserUpdateDTO
    {
        public required int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string CPF { get; set; }
        public UserType Type { get; set; }
    }
}
