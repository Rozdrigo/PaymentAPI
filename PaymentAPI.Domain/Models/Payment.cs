using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace PaymentAPI.Domain.Models
{
    public class Payment
    {
        public int Id { get; set; }
        [Required]
        public DateTime ExecutionDate { get; set; }
        [Required]
        public User Payer { get; set; }
        [Required]
        public User Payee { get; set; }
        [Required]
        public decimal Value { get; set; }
    }
}
