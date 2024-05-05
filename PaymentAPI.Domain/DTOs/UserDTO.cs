using PaymentAPI.Domain.Models;

namespace PaymentAPI.Domain.DTOs
{
    public class UserDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public UserType Type { get; set; }
    }
}
