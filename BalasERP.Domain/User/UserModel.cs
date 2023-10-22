using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BalasERP.Domain
{
    public class UserModel : BaseModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Firstname")]
        public string? FirstName { get; set; }
        [Required]
        [DisplayName("Lastname")]
        public string? LastName { get; set; }
        [Required]
        [DisplayName("Address")]
        public string? Address { get; set; }
        [Required]
        [DisplayName("Description")]
        public string? Description { get; set; }
        [Required]
        [DisplayName("State Name")]
        public int StateId { get; set; }
        [Required]
        [DisplayName("City Name")]
        public int CityId { get; set; }
        [Required]
        [DisplayName("Zip Code")]
        public string? ZipCode { get; set; }
        [Required]
        [DisplayName("Mobile No")]
        public string? MobileNo { get; set; }
        [Required]
        [DisplayName("Username")]
        public string? UserName { get; set; }
        [Required]
        [DisplayName("Password")]
        public string? Password { get; set; }
        [Required]
        [DisplayName("Designation")]
        public string? Designation { get; set; }
        [Required]
        [DisplayName("Group Name")]
        public int GroupId { get; set; }
    }
}
