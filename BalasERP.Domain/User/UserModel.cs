namespace BalasERP.Domain
{
    public class UserModel : BaseModel
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? Description { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public string? ZipCode { get; set; }
        public string? MobileNo { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Designation { get; set; }
        public int GroupId { get; set; }
    }
}
