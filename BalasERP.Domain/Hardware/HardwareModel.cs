using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BalasERP.Domain
{
    public class HardwareModel : BaseModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Type of Hardware")]
        public int TypeofHardwareId { get; set; }
        public string? TypeofHardware { get; set; }
        [Required]
        [DisplayName("Type of Hardware Option")]
        public int TypeofHardwareOptionId { get; set; }
        public string? TypeofHardwareOption { get; set; }
        public string? HardwareCode { get; set; }
        [Required]
        [DisplayName("Hardware")]
        public string? HardwareName { get; set; }
        public string? Specification { get; set; }
        public string? Description { get; set; }
        public double OptionValue { get; set; } = 0;
    }
}
