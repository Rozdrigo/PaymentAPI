using PaymentAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAPI.Domain.DTOs
{
    public class MakePaymentDTO
    {
        [Required]
        public int Payer { get; set; }
        [Required]
        public int Payee { get; set; }
        [Required]
        public decimal Value { get; set; }
    }
}
