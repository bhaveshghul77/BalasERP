using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BalasERP.Domain
{
    public class BackdataModel : BaseModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Type of Backdata")]
        public int TypeofBackdataId { get; set; }
        public string? TypeofBackdata { get; set; }
        [Required]
        [DisplayName("Type of Backdata Option")]
        public int TypeofBackdataOptionId { get; set; }
        public string? TypeofBackdataOption { get; set; }
        [Required]
        [DisplayName("Backdata")]
        public string? Backdata { get; set; }
        public string? Description { get; set; }
        public double SqftCost { get; set; } = 0;
        public double Sqmt { get; set; } = 0;
        public double GenFurnitur { get; set; } = 0;
        public double Partitions { get; set; } = 0;
        public double BoughtOut { get; set; } = 0;
    }
}
