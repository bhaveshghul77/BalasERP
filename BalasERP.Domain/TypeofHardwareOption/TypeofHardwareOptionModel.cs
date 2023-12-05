using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BalasERP.Domain
{
    public class TypeofHardwareOptionModel : BaseModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Type of Backdata")]
        public int TypeofHardwareId { get; set; }
        public string? TypeofHardware { get; set; }
        [Required]
        [DisplayName("Type of Backdata Option")]
        public string? TypeofHardwareOption { get; set; }
    }
}
