using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using PaymentAPI.Domain.Models;

namespace PaymentAPI.Domain.DTOs
{
    public class UserCreateDTO
    {
        [Required]
        [MinLength(10)]
        [MaxLength(1000)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [MinLength(10)]
        [MaxLength(1000)]
        public string Email { get; set; }
        [Required]
        [MinLength(10)]
        [MaxLength(1000)]
        public string Password { get; set; }
        [Required]
        [MinLength(11)]
        [RegularExpression(@"\d{11}")]
        public string CPF { get; set; }
        [DefaultValue(0)]
        public UserType Type { get; set; }
    }
}
