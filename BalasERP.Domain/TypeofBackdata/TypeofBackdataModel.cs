using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BalasERP.Domain
{
    public class TypeofBackdataModel : BaseModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Type of Backdata")]
        public string? TypeofBackdata { get; set; }
    }
}
