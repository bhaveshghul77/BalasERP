namespace BalasERP.Domain
{
    public class UserRightModel : BaseModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public int MenuId { get; set; }
        public bool Add { get; set; }
        public bool Edit { get; set; }
        public bool Delete { get; set; }
        public bool View { get; set; }

        public string? UserName { get; set; }
        public string? GroupName { get; set; }
        public string? MenuName { get; set; }

        public string? AddRight { get; set; }
        public string? EditRight { get; set; }
        public string? DeleteRight { get; set; }
        public string? ViewRight { get; set; }
    }
}
