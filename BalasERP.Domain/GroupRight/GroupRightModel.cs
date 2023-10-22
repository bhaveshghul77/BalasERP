using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BalasERP.Domain
{
    public class GroupRightModel : BaseModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Group Name")]
        public int GroupId { get; set; }
        [Required]
        [DisplayName("Menu Name")]
        public int MenuId { get; set; }
        public bool Add { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }
        public bool View { get; set; }
        public string? GroupName { get; set; }
        public string? MenuName { get; set; }
        public string? AddRight { get; set; }
        public string? EditRight { get; set; }
        public string? DeleteRight { get; set; }
        public string? ViewRight { get; set; }
    }
}
