using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BalasERP.Domain
{
    public class LoginDTO
    {
        [Required]
        [DisplayName("UserName")]
        public string? UserName { get; set; }
        [Required]
        [DisplayName("Password")]
        public string? Password { get; set; }
    }
}
