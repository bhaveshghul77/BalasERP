using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BalasERP.Domain
{
    public class DataInputModel : BaseModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Type of Hardware")]
        public string? DataInput { get; set; }
    }
}
