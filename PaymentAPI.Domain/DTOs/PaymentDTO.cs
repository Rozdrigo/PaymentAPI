using PaymentAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAPI.Domain.DTOs
{
    public class PaymentDTO
    {
        public int Id { get; set; }
        [Required]
        public DateTime ExecutionDate { get; set; }
        [Required]
        public UserDTO Payer { get; set; }
        [Required]
        public UserDTO Payee { get; set; }
        [Required]
        public decimal Value { get; set; }
    }
}
