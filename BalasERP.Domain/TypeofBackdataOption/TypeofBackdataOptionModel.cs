using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BalasERP.Domain
{
    public class TypeofBackdataOptionModel : BaseModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Type of Backdata")]
        public int TypeofBackdataId { get; set; }
        public string? TypeofBackdata { get; set; }
        [Required]
        [DisplayName("Type of Backdata Option")]
        public string? TypeofBackdataOption { get; set; }
    }
}
