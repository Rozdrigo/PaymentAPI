using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAPI.Domain.Models
{
    public enum StatusAccount
    {
        unblocked,
        blocked
    }
    public class Account
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("User")]
        public int Owner { get; set; }
        [Required]
        [DefaultValue(0)]
        public StatusAccount Status { get; set; }
        [Required]
        [DefaultValue(0)]
        public decimal Value { get; set; }
    }
}
