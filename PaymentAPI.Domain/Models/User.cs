using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PaymentAPI.Domain.Models
{
    public enum UserType
    {
        regular,
        shopkeeper
    }
    public class User
    {
        public int Id { get; set; }
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
        [StringLength(11)]
        public string CPF { get; set; }
        [DefaultValue(0)]
        public UserType Type { get; set; }
    }
}
