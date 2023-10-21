namespace BalasERP.Domain
{
    public class BaseModel
    {
        public int RowNo { get; set; }
        public int ActionBy { get; set; }
        public int ResponseCode { get; set; }
        public string? ActionName { get; set; }
    }
}
