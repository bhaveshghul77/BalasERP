using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BalasERP.Domain
{
    public class MillimetreModel : BaseModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Type of Hardware")]
        public string? Millimetre { get; set; }
    }
}
