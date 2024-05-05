using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace PaymentAPI.Domain.Models
{
    public class Payment
    {
        public int Id { get; set; }
        [Required]
        public DateTime ExecutionDate { get; set; }
        [Required]
        [ForeignKey("User")]
        public int Payer { get; set; }
        [Required]
        [ForeignKey("User")]
        public int Payee { get; set; }
        [Required]
        public decimal Value { get; set; }
    }
}
