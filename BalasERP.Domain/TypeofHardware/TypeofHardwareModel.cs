using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BalasERP.Domain
{
    public class TypeofHardwareModel : BaseModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Type of Hardware")]
        public string? TypeofHardware { get; set; }
    }
}
