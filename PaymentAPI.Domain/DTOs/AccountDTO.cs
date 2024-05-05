using PaymentAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAPI.Domain.DTOs
{
    public class AccountDTO
    {
        public int Id { get; set; }
        [Required]
        public int Owner { get; set; }
        [Required]
        [DefaultValue(0)]
        public StatusAccount Status { get; set; }
        [Required]
        [DefaultValue(0)]
        public decimal Value { get; set; }
    }
}
